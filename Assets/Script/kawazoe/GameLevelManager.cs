using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText; // TextMeshProUGUI コンポーネント
    public int level = 1;  // 現在のレベル
    public int maxLevel = 3; // 最大レベル

    void Start()
    {
        // 初期レベルを表示
        UpdateLevelUI();
    }

    void Update()
    {
        
    }

    public void LevelUp()
    {
        // レベルUIを更新
        UpdateLevelUI();
    }
    //public void MisokatsuLevelUp()
    //{
    //    // レベルUIを更新
    //    UpdateLevelUI();
    //}
    //public void UirouLevelUp()
    //{
    //    // レベルUIを更新
    //    UpdateLevelUI();
    //}
    //public void HitsumabushiLevelUp()
    //{
    //    // レベルUIを更新
    //    UpdateLevelUI();
    //}
    //public void TebasakiLevelUp()
    //{
    //    // レベルUIを更新
    //    UpdateLevelUI();
    //}
    //public void TaiwanRamenLevelUp()
    //{
    //    // レベルUIを更新
    //    UpdateLevelUI();
    //}
    //public void KishimenLevelUp()
    //{
    //    // レベルUIを更新
    //    UpdateLevelUI();
    //}

    void UpdateLevelUI()
    {
        // UIテキストに現在のレベルを表示
        levelText.text = "Level: " + level;
    }
}
