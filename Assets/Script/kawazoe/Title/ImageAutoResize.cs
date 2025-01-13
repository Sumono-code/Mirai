using UnityEngine;

public class ImageResize : MonoBehaviour
{
    public RectTransform targetImage; // �g��E�k���Ώۂ�Image��RectTransform
    public Vector2 maxSize = new Vector2(600, 600); // �ő�T�C�Y
    public Vector2 minSize = new Vector2(100, 100); // �ŏ��T�C�Y

    // �T�C�Y��傫������
    public void IncreaseSize()
    {
        if (targetImage.sizeDelta.x < maxSize.x && targetImage.sizeDelta.y < maxSize.y)
        {
            Debug.Log("�g�債�܂�");
            targetImage.sizeDelta += new Vector2(50, 50); // 10x10���g��
        }
    }

    // �T�C�Y������������
    public void DecreaseSize()
    {
        if (targetImage.sizeDelta.x > minSize.x && targetImage.sizeDelta.y > minSize.y)
        {
            targetImage.sizeDelta -= new Vector2(50, 50); // 10x10���k��
        }
    }
}
