using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
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

    public RectTransform levelUI;            // ���x��UI��RectTransform
    public float hoverScale; // �z�o�[���̃X�P�[��
    public Vector2 hoverPositionOffset; // �z�o�[���̈ʒu�I�t�Z�b�g

    private Vector3 originalScale; // �����X�P�[��
    private Vector2 originalPosition; // �����ʒu

    void Start()
    {
        // �����l���L�^
        ImageOriginalScale = targetTransform.localScale;
        ImageOriginalPosition = targetTransform.anchoredPosition;

        originalScale = levelUI.localScale;
        originalPosition = levelUI.localPosition;

        // ������ԂŃ{�^�����\��
        ScaleIncreaseButton.SetActive(false);
        SpecialButton.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines(); // �A�j���[�V���������Z�b�g
        StartCoroutine(AnimateToState(ImageOriginalScale * scaleFactor, ImageOriginalPosition + moveOffset, hoverSprite, true));

        StopAllCoroutines(); // �A�j���[�V���������Z�b�g
        StartCoroutine(AnimateToState(originalScale * hoverScale, originalPosition + hoverPositionOffset));

        targetTransform.transform.SetAsLastSibling();

        ScaleIncreaseButton.SetActive(true);
        SpecialButton.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines(); // �A�j���[�V���������Z�b�g
        StartCoroutine(AnimateToState(ImageOriginalScale, ImageOriginalPosition, defaultSprite, false));

        ScaleIncreaseButton.SetActive(false);
        SpecialButton.SetActive(false);
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

        //// ���x��UI�̈ʒu��ύX
        //if (levelUI != null)
        //{
        //    levelUI.anchoredPosition = targetPosition + levelUIOffset;
        //}
    }
}
