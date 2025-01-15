using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ScaleIncreaseButtonAlphaController : MonoBehaviour
{
    public Button targetButton; // 操作したいボタン
    public StoreManager StoreObj;
    private int currentValue = 0; // 現在の値

    StoreManager target;

    void Start()
    {
        target = StoreObj.GetComponent<StoreManager>();
        // 初期化：ボタンの透明度を薄く設定
        SetButtonAlpha(0.5f); // 50%透明
    }

    void Update()
    {
        // 数値が閾値を超えたらボタンを濃く表示
        if (PlayerData.Instance.nMoney >= target.IncreaseOfCapital)
        {
            SetButtonAlpha(1.0f); // 完全に不透明
        }
        else
        {
            SetButtonAlpha(0.5f); // 再び薄く表示
        }
    }

    // ボタンの透明度を設定する関数
    private void SetButtonAlpha(float alpha)
    {
        Color buttonColor = targetButton.image.color; // ボタンの色を取得
        buttonColor.a = alpha; // α値を変更
        targetButton.image.color = buttonColor; // ボタンに色を再設定
    }
}
