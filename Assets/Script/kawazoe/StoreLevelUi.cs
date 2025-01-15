using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class StoreLevelUi : MonoBehaviour/*, IPointerEnterHandler, IPointerExitHandler*/
{
    [SerializeField] private TextMeshProUGUI levelText;
    public int level = 1;  // ���݂̃��x��
    public int maxLevel = 3; // �ő僌�x��

    //public float hoverScale; // �z�o�[���̃X�P�[��
    //public Vector2 hoverPositionOffset; // �z�o�[���̈ʒu�I�t�Z�b�g
    //public float animationSpeed = 10f; // �A�j���[�V�������x

    //private Vector3 originalScale; // �����X�P�[��
    //private Vector2 originalPosition; // �����ʒu

    //private RectTransform rectTransform; // �I�u�W�F�N�g��RectTransform

    void Start()
    {
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

    // ���x���e�L�X�g���X�V
    private void UpdateLevelText()
    {
        levelText.text = level.ToString();
    }
}
