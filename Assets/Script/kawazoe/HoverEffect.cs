using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // �摜
    public RectTransform targetTransform;    // �g��E�ړ�����Ώ�
    public Image targetImage;                // �摜�؂�ւ��Ώ�
    public Sprite hoverSprite;               // �z�o�[���̉摜
    public Sprite defaultSprite;             // �f�t�H���g�摜
    public float scaleFactor;                // �g�嗦
    public Vector2 moveOffset;               // �ړ���
    public GameObject ScaleIncreaseButton;   // �\������{�^��
    public GameObject SpecialButton;
    public float animationSpeed = 20f;       // �A�j���[�V�������x

    private Vector3 ImageOriginalScale;
    private Vector2 ImageOriginalPosition;

    // Level
    private RectTransform LevelUiRectTransform; // �I�u�W�F�N�g��RectTransform

    public RectTransform levelUI;            // ���x��UI��RectTransform
    public float LevelUiScaleFactor; // �z�o�[���̃X�P�[��
    public Vector2 LevelUiMoveOffset; // �z�o�[���̈ʒu�I�t�Z�b�g

    private Vector3 LevelUiOriginalScale; // �����X�P�[��
    private Vector2 LevelUiOriginalPosition; // �����ʒu

    // ���n�ǉ�
    public GameObject GugeUi;   // �K�E�Z�Q�[�W

    void Start()
    {
        // �����l���L�^
        ImageOriginalScale = targetTransform.localScale;
        ImageOriginalPosition = targetTransform.anchoredPosition;

        LevelUiOriginalScale = levelUI.localScale;
        LevelUiOriginalPosition = levelUI.localPosition;

        LevelUiRectTransform = levelUI;

        // ������ԂŃ{�^�����\��
        ScaleIncreaseButton.SetActive(false);
        SpecialButton.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines(); // �A�j���[�V���������Z�b�g
        StartCoroutine(AnimateToState(ImageOriginalScale * scaleFactor, ImageOriginalPosition + moveOffset, hoverSprite, true));
        StartCoroutine(LevelUiAnimateToState(LevelUiOriginalScale * LevelUiScaleFactor, LevelUiOriginalPosition + LevelUiMoveOffset));

        targetTransform.transform.SetAsLastSibling();

        ScaleIncreaseButton.SetActive(true);
        SpecialButton.SetActive(true);

        // ���n�ǉ�
        GugeUi.SetActive(false);    // �K�E�Z�Q�[�W����
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines(); // �A�j���[�V���������Z�b�g
        StartCoroutine(AnimateToState(ImageOriginalScale, ImageOriginalPosition, defaultSprite, false));
        StartCoroutine(LevelUiAnimateToState(LevelUiOriginalScale, LevelUiOriginalPosition));

        ScaleIncreaseButton.SetActive(false);
        SpecialButton.SetActive(false);

        // ���n�ǉ�
        GugeUi.SetActive(true);    // �K�E�Z�Q�[�W�o��
    }

    private System.Collections.IEnumerator AnimateToState(Vector3 targetScale, Vector2 targetPosition, Sprite targetSprite, bool showButtons)
    {
        // �X���[�Y�Ɋg��E�ړ�
        while (Vector3.Distance(targetTransform.localScale, targetScale) > 0.01f ||
               Vector2.Distance(targetTransform.anchoredPosition, targetPosition) > 0.01f)
        {
            targetTransform.localScale = Vector3.Lerp(targetTransform.localScale, targetScale, Time.deltaTime * animationSpeed);
            targetTransform.anchoredPosition = Vector2.Lerp(targetTransform.anchoredPosition, targetPosition, Time.deltaTime * animationSpeed);
            yield return null;
        }

        // �ŏI�ʒu�ƃX�P�[����ݒ�
        targetTransform.localScale = targetScale;
        targetTransform.anchoredPosition = targetPosition;

        // �摜�ύX
        targetImage.sprite = targetSprite;
    }

    // �A�j���[�V��������
    private System.Collections.IEnumerator LevelUiAnimateToState(Vector3 targetScale, Vector3 targetPosition)
    {
        while (Vector3.Distance(LevelUiRectTransform.localScale, targetScale) > 0.01f ||
               Vector3.Distance(LevelUiRectTransform.localPosition, targetPosition) > 0.01f)
        {
            LevelUiRectTransform.localScale = Vector3.Lerp(LevelUiRectTransform.localScale, targetScale, Time.deltaTime * animationSpeed);
            LevelUiRectTransform.localPosition = Vector3.Lerp(LevelUiRectTransform.localPosition, targetPosition, Time.deltaTime * animationSpeed);
            yield return null;
        }

        // �ŏI�ʒu�ƃX�P�[�����m��
        LevelUiRectTransform.localScale = targetScale;
        LevelUiRectTransform.localPosition = targetPosition;
    }


}
