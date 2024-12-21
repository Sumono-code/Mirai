using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText; // TextMeshProUGUI �R���|�[�l���g
    public int score = 0;  // ���݂̃X�R�A
    public int level = 1;  // ���݂̃��x��
    public int maxLevel = 3; // �ő僌�x��
    public int[] scoreThresholds = { 0, 1000, 1200 }; // ���x���A�b�v��臒l

    void Start()
    {
        // �������x����\��
        UpdateLevelUI();
        score = PlayerData.Instance.nMoney;
    }

    void Update()
    {
        // �X�R�A�̃e�X�g�p: �L�[�������ƃX�R�A��������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(100);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;

        // ���x�����X�R�A�ɉ����čX�V
        CheckLevelUp();
    }

    void CheckLevelUp()
    {
        // ���݂̃X�R�A��臒l�𒴂����烌�x���A�b�v
        for (int i = 0; i < scoreThresholds.Length; i++)
        {
            if (score >= scoreThresholds[i] && level < i + 1)
            {
                level = i + 1;
                if (level > maxLevel)
                {
                    level = maxLevel;
                }

                // ���x��UI���X�V
                UpdateLevelUI();
            }
        }
    }

    void UpdateLevelUI()
    {
        // UI�e�L�X�g�Ɍ��݂̃��x����\��
        levelText.text = "Level: " + level;
    }
}
