using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Vector3 scaleIncrease; // 拡大サイズ

    public GameObject MisokatuModel;
    public GameObject UirouModel;
    public GameObject HitsumabushiModel;
    public GameObject TebasakiModel;
    public GameObject TaiwanRamenModel;
    public GameObject KishimenModel;

    // 味噌カツ店増資
    public void OperateMisokatuScaleIncrease()
    {
        Debug.Log("Misokatuを増資します");

        Vector3 newScale = MisokatuModel.transform.localScale + scaleIncrease;
        MisokatuModel.transform.localScale = newScale;
    }

    // 味噌カツ店必殺技
    public void OperateMisokatuSpecial()
    {
        Debug.Log("Misokatuが必殺技を使います");

    }

    // ういろう店増資
    public void OperateUirouScaleIncrease()
    {
        Debug.Log("Uirouを増資します");

        Vector3 newScale = UirouModel.transform.localScale + scaleIncrease;
        UirouModel.transform.localScale = newScale;
    }

    // ういろう店必殺技
    public void OperateUirouSpecial()
    {
        Debug.Log("Uirouが必殺技を使います");

    }

    // ひつまぶし店増資
    public void OperateHitshmabushiScaleIncrease()
    {
        Debug.Log("Hitsumabushiを増資します");

        Vector3 newScale = HitsumabushiModel.transform.localScale + scaleIncrease;
        HitsumabushiModel.transform.localScale = newScale;
    }

    // ひつまぶし店必殺技
    public void OperateHitshmabushiSpecial()
    {
        Debug.Log("Hitsumabushiが必殺技を使います");

    }

    // 手羽先店増資
    public void OperateTebasakiScaleIncrease()
    {
        Debug.Log("TebasakiModelを増資します");

        Vector3 newScale = TebasakiModel.transform.localScale + scaleIncrease;
        TebasakiModel.transform.localScale = newScale;
    }

    // 手羽先店必殺技
    public void OperateTebasakiSpecial()
    {
        Debug.Log("TebasakiModelが必殺技を使います");

    }

    // 台湾ラーメン店増資
    public void OperateTaiwanRamenScaleIncrease()
    {
        Debug.Log("TaiwanRamenを増資します");

        Vector3 newScale = TaiwanRamenModel.transform.localScale + scaleIncrease;
        TaiwanRamenModel.transform.localScale = newScale;
    }

    // 台湾ラーメン店必殺技
    public void OperateTaiwanRamenSpecial()
    {
        Debug.Log("TaiwanRamenが必殺技を使います");

    }

    // きしめん店増資
    public void OperateKishimenScaleIncrease()
    {
        Debug.Log("Kishimenを増資します");

        Vector3 newScale = KishimenModel.transform.localScale + scaleIncrease;
        KishimenModel.transform.localScale = newScale;
    }

    // きしめん店必殺技
    public void OperateKishimenSpecial()
    {
        Debug.Log("Kishimenが必殺技を使います");

    }
}
