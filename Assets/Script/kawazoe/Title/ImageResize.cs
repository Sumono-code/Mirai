using UnityEngine;

public class ImageAutoResize : MonoBehaviour
{
    public RectTransform targetImage; // �g��E�k���Ώۂ�Image��RectTransform
    public Vector2 maxSize = new Vector2(300, 300); // �ő�T�C�Y
    public Vector2 minSize = new Vector2(100, 100); // �ŏ��T�C�Y
    public float speed = 80f; // �g��E�k���̃X�s�[�h
    private bool isGrowing = true; // �g�咆���k������

    void Update()
    {
        // ���݂̃T�C�Y���擾
        Vector2 currentSize = targetImage.sizeDelta;

        if (isGrowing)
        {
            // �g��
            currentSize += Vector2.one * speed * Time.deltaTime;
            if (currentSize.x >= maxSize.x || currentSize.y >= maxSize.y)
            {
                isGrowing = false; // �ő�T�C�Y�ɒB������k���ɐ؂�ւ�
            }
        }
        else
        {
            // �k��
            currentSize -= Vector2.one * speed * Time.deltaTime;
            if (currentSize.x <= minSize.x || currentSize.y <= minSize.y)
            {
                isGrowing = true; // �ŏ��T�C�Y�ɒB������g��ɐ؂�ւ�
            }
        }

        // �T�C�Y��K�p
        targetImage.sizeDelta = currentSize;
    }
}
