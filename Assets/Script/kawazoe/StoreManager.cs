using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public Vector3 scaleIncrease; // 拡大サイズ

    public GameObject MisokatuModel;
    public GameObject UirouModel;
    public GameObject HitsumabushiModel;
    public GameObject TebasakiModel;
    public GameObject TaiwanRamenModel;
    public GameObject KishimenModel;

    public int MisokatsuLevel = 1;  // 現在のレベル
    public int UirouLevel = 1;  // 現在のレベル
    public int HitsumabushiLevel = 1;  // 現在のレベル
    public int TebasakiLevel = 1;  // 現在のレベル
    public int TaiwanRamenLevel = 1;  // 現在のレベル
    public int KishimenLevel = 1;  // 現在のレベル

    private int maxLevel = 3; // 最大レベル

    [SerializeField]public TextMeshProUGUI MisokatsuGameLevel;
    [SerializeField]public TextMeshProUGUI UirouGameLevel;
    [SerializeField]public TextMeshProUGUI HitsumabushiGameLevel;
    [SerializeField]public TextMeshProUGUI TebasakiGameLevel;
    [SerializeField]public TextMeshProUGUI TaiwanRamenGameLevel;
    [SerializeField]public TextMeshProUGUI KishimenGameLevel;

    private EffectManager IncreaseOfCapitalEffectManager;         // 増資時のエフェクト
    private EffectManager Special1EffectManager;                  // 必殺技時のエフェクト1
    private EffectManager Special2EffectManager;                  // 必殺技時のエフェクト2

    public int IncreaseOfCapital = 0;

    public GameObject MisokatsuSpecialUi;
    public GameObject UirouSpecialUi;
    public GameObject HitsumabushiSpecialUi;
    public GameObject TebasakiSpecialUi;
    public GameObject TaiwanRamenSpecialUi;
    public GameObject KishimenSpecialUi;

    SpecialButtonAlphaController MisokatsuSpecial;
    SpecialButtonAlphaController UirouSpecial;
    SpecialButtonAlphaController HitsumabushiSpecial;
    SpecialButtonAlphaController TebasakiSpecial;
    SpecialButtonAlphaController TaiwanRamenSpecial;
    SpecialButtonAlphaController KishimenSpecial;

    PlayerData playerData;
    GameObject ManageData;


    // 横地追加-----------------------------------------------------------------------
    public GameObject skillLogManager;
    SkillLogManager SkillLogCs;

    // Start is called before the first frame update
    void Start()
    {
        SkillLogCs = skillLogManager.GetComponent<SkillLogManager>();

        IncreaseOfCapitalEffectManager = FindObjectOfType<EffectManager>();
        Special1EffectManager = FindObjectOfType<EffectManager>();
        Special2EffectManager = FindObjectOfType<EffectManager>();

        MisokatsuSpecial = MisokatsuSpecialUi.GetComponent<SpecialButtonAlphaController>();
        UirouSpecial = UirouSpecialUi.GetComponent<SpecialButtonAlphaController>();
        HitsumabushiSpecial = HitsumabushiSpecialUi.GetComponent<SpecialButtonAlphaController>();
        TebasakiSpecial = TebasakiSpecialUi.GetComponent<SpecialButtonAlphaController>();
        TaiwanRamenSpecial = TaiwanRamenSpecialUi.GetComponent<SpecialButtonAlphaController>();
        KishimenSpecial = KishimenSpecialUi.GetComponent<SpecialButtonAlphaController>();

        ManageData = GameObject.Find("ManageData");
        playerData = ManageData.GetComponent<PlayerData>();
    }
    //-----------------------------------------------------------------------------------

    private void Update()
    {
        MisokatsuGameLevel.text = MisokatsuLevel.ToString();
        UirouGameLevel.text = UirouLevel.ToString();
        HitsumabushiGameLevel.text = HitsumabushiLevel.ToString();
        TebasakiGameLevel.text = TebasakiLevel.ToString();
        TaiwanRamenGameLevel.text = TaiwanRamenLevel.ToString();
        KishimenGameLevel.text = KishimenLevel.ToString();
    }

    // 味噌カツ店増資
    public void OperateMisokatuScaleIncrease()
    {
        
        if (MisokatsuLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            MisokatsuLevel++;
            Debug.Log("Misokatuを増資します");

            Vector3 newScale = MisokatuModel.transform.localScale + scaleIncrease;
            MisokatuModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(MisokatuModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.misokatu, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }

    // 味噌カツ店必殺技
    public void OperateMisokatuSpecial()
    {
        if (MisokatsuSpecial.Possible)
        {
            Debug.Log("Misokatuが必殺技を使います");
            MisokatuModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(MisokatuModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(MisokatuModel.transform.position);

            MisokatsuSpecial.Possible = false;
        }
    }

    // ういろう店増資
    public void OperateUirouScaleIncrease()
    {
        if (UirouLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            UirouLevel++;
            Debug.Log("Uirouを増資します");

            Vector3 newScale = UirouModel.transform.localScale + scaleIncrease;
            UirouModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(UirouModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.uirou, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }

    // ういろう店必殺技
    public void OperateUirouSpecial()
    {
        if (UirouSpecial.Possible)
        {
            Debug.Log("Uirouが必殺技を使います");
            UirouModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(UirouModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(UirouModel.transform.position);

            UirouSpecial.Possible = false;
        }
    }

    // ひつまぶし店増資
    public void OperateHitsumabushiScaleIncrease()
    {
        if (HitsumabushiLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            HitsumabushiLevel++;
            Debug.Log("Hitsumabushiを増資します");

            Vector3 newScale = HitsumabushiModel.transform.localScale + scaleIncrease;
            HitsumabushiModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(HitsumabushiModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.Hitumabushi, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }

    // ひつまぶし店必殺技
    public void OperateHitshmabushiSpecial()
    {
        if (HitsumabushiSpecial.Possible)
        {
            Debug.Log("Hitsumabushiが必殺技を使います");
            HitsumabushiModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(HitsumabushiModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(HitsumabushiModel.transform.position);

            HitsumabushiSpecial.Possible = false;
        }
    }

    // 手羽先店増資
    public void OperateTebasakiScaleIncrease()
    {
        if (TebasakiLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            TebasakiLevel++;
            Debug.Log("TebasakiModelを増資します");

            Vector3 newScale = TebasakiModel.transform.localScale + scaleIncrease;
            TebasakiModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(TebasakiModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.Tebasaki, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }
    // 手羽先店必殺技
    public void OperateTebasakiSpecial()
    {
        if (TebasakiSpecial.Possible)
        {
            Debug.Log("TebasakiModelが必殺技を使います");
            TebasakiModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(TebasakiModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(TebasakiModel.transform.position);

            TebasakiSpecial.Possible = false;
        }
    }

    // 台湾ラーメン店増資
    public void OperateTaiwanRamenScaleIncrease()
    {
        if (TaiwanRamenLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            TaiwanRamenLevel++;
            Debug.Log("TaiwanRamenを増資します");

            Vector3 newScale = TaiwanRamenModel.transform.localScale + scaleIncrease;
            TaiwanRamenModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(TaiwanRamenModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.TaiwanRamen, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }

    // 台湾ラーメン店必殺技
    public void OperateTaiwanRamenSpecial()
    {
        if (TaiwanRamenSpecial.Possible)
        {
            Debug.Log("TaiwanRamenが必殺技を使います");
            TaiwanRamenModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(TaiwanRamenModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(TaiwanRamenModel.transform.position);

            TaiwanRamenSpecial.Possible = false;
        }
    }

    // きしめん店増資
    public void OperateKishimenScaleIncrease()
    {
        if (KishimenLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            KishimenLevel++;
            Debug.Log("Kishimenを増資します");

            Vector3 newScale = KishimenModel.transform.localScale + scaleIncrease;
            KishimenModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(KishimenModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.kisimen, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }

    // きしめん店必殺技
    public void OperateKishimenSpecial()
    {
        if (KishimenSpecial.Possible)
        {
            Debug.Log("Kishimenが必殺技を使います");
            KishimenModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(KishimenModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(KishimenModel.transform.position);

            KishimenSpecial.Possible = false;
        }
    }
}
