using UnityEngine;

public class ScrollUI : MonoBehaviour
{
    public RectTransform uiElement; // �X�N���[����������UI
    public float scrollSpeed = 200f; // �X�N���[�����x
    public float resetThreshold = -1000f; // ���[�ɓ��B�����Ƃ��̈ʒu
    public float startOffset = 1000f; // �ďo�����̈ʒu�i�E�[�j

    void Update()
    {
        // ���݈ʒu�����Ɉړ�
        uiElement.anchoredPosition += Vector2.left * scrollSpeed * Time.deltaTime;

        // �w�肵���ʒu�𒴂����烊�Z�b�g
        if (uiElement.anchoredPosition.x < resetThreshold)
        {
            uiElement.anchoredPosition = new Vector2(startOffset, uiElement.anchoredPosition.y);
        }
    }
}
