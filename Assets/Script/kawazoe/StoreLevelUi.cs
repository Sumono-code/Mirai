using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class StoreLevelUi : MonoBehaviour/*, IPointerEnterHandler, IPointerExitHandler*/
{
    [SerializeField] private TextMeshProUGUI levelText;
    public int level = 1;  // 現在のレベル
    public int maxLevel = 3; // 最大レベル

    //public float hoverScale; // ホバー時のスケール
    //public Vector2 hoverPositionOffset; // ホバー時の位置オフセット
    //public float animationSpeed = 10f; // アニメーション速度

    //private Vector3 originalScale; // 初期スケール
    //private Vector2 originalPosition; // 初期位置

    //private RectTransform rectTransform; // オブジェクトのRectTransform

    void Start()
    {
        // レベル表示を更新
        UpdateLevelText();
    }

    void Update()
    {
        // 常に最新のレベルを表示
        levelText.text = level.ToString();
    }

    // レベルアップボタンが押されたときに呼び出す
    public void OnLevelUpButtonClicked()
    {
        if (level < maxLevel)
        {
            level++;
            UpdateLevelText();
        }
    }

    // レベルテキストを更新
    private void UpdateLevelText()
    {
        levelText.text = level.ToString();
    }
}
