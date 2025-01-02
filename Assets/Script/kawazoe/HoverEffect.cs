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
    public float animationSpeed = 10f;       // �A�j���[�V�������x

    private Vector3 originalScale;
    private Vector2 originalPosition;

    void Start()
    {
        // �����l���L�^
        originalScale = targetTransform.localScale;
        originalPosition = targetTransform.anchoredPosition;

        // ������ԂŃ{�^�����\��
        ScaleIncreaseButton.SetActive(false);
        SpecialButton.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines(); // �A�j���[�V���������Z�b�g
        StartCoroutine(AnimateToState(originalScale * scaleFactor, originalPosition + moveOffset, hoverSprite, true));

        targetTransform.transform.SetAsLastSibling();

        ScaleIncreaseButton.SetActive(true);
        SpecialButton.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines(); // �A�j���[�V���������Z�b�g
        StartCoroutine(AnimateToState(originalScale, originalPosition, defaultSprite, false));

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

    }
}
