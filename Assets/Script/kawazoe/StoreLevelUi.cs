using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class StoreLevelUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI levelText;
    public int level = 1;  // ���݂̃��x��
    public int maxLevel = 3; // �ő僌�x��

    public float hoverScale; // �z�o�[���̃X�P�[��
    public Vector2 hoverPositionOffset; // �z�o�[���̈ʒu�I�t�Z�b�g
    public float animationSpeed = 10f; // �A�j���[�V�������x

    private Vector3 originalScale; // �����X�P�[��
    private Vector2 originalPosition; // �����ʒu

    private RectTransform rectTransform; // �I�u�W�F�N�g��RectTransform

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // �����ʒu�ƃX�P�[����ۑ�
        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.localPosition;

        // ���x���\�����X�V
        UpdateLevelText();
    }

    void Update()
    {
        // ��ɍŐV�̃��x����\��
        levelText.text = level.ToString();
    }

    // ���x���A�b�v�{�^���������ꂽ�Ƃ��ɌĂяo��
    public void OnLevelUpButtonClicked()
    {
        if (level < maxLevel)
        {
            level++;
            UpdateLevelText();
        }
    }

    // �z�o�[���ɌĂяo�����
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines(); // �A�j���[�V���������Z�b�g
        StartCoroutine(AnimateToState(originalScale * hoverScale, originalPosition + hoverPositionOffset));
    }

    // �z�o�[�������ɌĂяo�����
    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines(); // �A�j���[�V���������Z�b�g
        StartCoroutine(AnimateToState(originalScale, originalPosition));
    }

    // �A�j���[�V��������
    private IEnumerator AnimateToState(Vector3 targetScale, Vector3 targetPosition)
    {
        while (Vector3.Distance(rectTransform.localScale, targetScale) > 0.01f ||
               Vector3.Distance(rectTransform.localPosition, targetPosition) > 0.01f)
        {
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, targetScale, Time.deltaTime * animationSpeed);
            rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition, targetPosition, Time.deltaTime * animationSpeed);
            yield return null;
        }

        // �ŏI�ʒu�ƃX�P�[�����m��
        rectTransform.localScale = targetScale;
        rectTransform.localPosition = targetPosition;
    }

    // ���x���e�L�X�g���X�V
    private void UpdateLevelText()
    {
        levelText.text = level.ToString();
    }
}
