using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText; // TextMeshProUGUI �R���|�[�l���g
    public int level = 1;  // ���݂̃��x��
    public int maxLevel = 3; // �ő僌�x��

    void Start()
    {
        // �������x����\��
        UpdateLevelUI();
    }

    void Update()
    {
        
    }

    public void LevelUp()
    {
        // ���x��UI���X�V
        UpdateLevelUI();
    }
    //public void MisokatsuLevelUp()
    //{
    //    // ���x��UI���X�V
    //    UpdateLevelUI();
    //}
    //public void UirouLevelUp()
    //{
    //    // ���x��UI���X�V
    //    UpdateLevelUI();
    //}
    //public void HitsumabushiLevelUp()
    //{
    //    // ���x��UI���X�V
    //    UpdateLevelUI();
    //}
    //public void TebasakiLevelUp()
    //{
    //    // ���x��UI���X�V
    //    UpdateLevelUI();
    //}
    //public void TaiwanRamenLevelUp()
    //{
    //    // ���x��UI���X�V
    //    UpdateLevelUI();
    //}
    //public void KishimenLevelUp()
    //{
    //    // ���x��UI���X�V
    //    UpdateLevelUI();
    //}

    void UpdateLevelUI()
    {
        // UI�e�L�X�g�Ɍ��݂̃��x����\��
        levelText.text = "Level: " + level;
    }
}
