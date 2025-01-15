using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public Vector3 scaleIncrease; // Šg‘åƒTƒCƒY

    public GameObject MisokatuModel;
    public GameObject UirouModel;
    public GameObject HitsumabushiModel;
    public GameObject TebasakiModel;
    public GameObject TaiwanRamenModel;
    public GameObject KishimenModel;

    public int MisokatsuLevel = 1;  // Œ»İ‚ÌƒŒƒxƒ‹
    public int UirouLevel = 1;  // Œ»İ‚ÌƒŒƒxƒ‹
    public int HitsumabushiLevel = 1;  // Œ»İ‚ÌƒŒƒxƒ‹
    public int TebasakiLevel = 1;  // Œ»İ‚ÌƒŒƒxƒ‹
    public int TaiwanRamenLevel = 1;  // Œ»İ‚ÌƒŒƒxƒ‹
    public int KishimenLevel = 1;  // Œ»İ‚ÌƒŒƒxƒ‹

    private int maxLevel = 3; // Å‘åƒŒƒxƒ‹

    [SerializeField]public TextMeshProUGUI MisokatsuGameLevel;
    [SerializeField]public TextMeshProUGUI UirouGameLevel;
    [SerializeField]public TextMeshProUGUI HitsumabushiGameLevel;
    [SerializeField]public TextMeshProUGUI TebasakiGameLevel;
    [SerializeField]public TextMeshProUGUI TaiwanRamenGameLevel;
    [SerializeField]public TextMeshProUGUI KishimenGameLevel;

    private EffectManager IncreaseOfCapitalEffectManager;         // ‘‘‚ÌƒGƒtƒFƒNƒg
    private EffectManager Special1EffectManager;                  // •KE‹Z‚ÌƒGƒtƒFƒNƒg1
    private EffectManager Special2EffectManager;                  // •KE‹Z‚ÌƒGƒtƒFƒNƒg2

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


    // ‰¡’n’Ç‰Á-----------------------------------------------------------------------
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

    // –¡‘XƒJƒc“X‘‘
    public void OperateMisokatuScaleIncrease()
    {
        
        if (MisokatsuLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            MisokatsuLevel++;
            Debug.Log("Misokatu‚ğ‘‘‚µ‚Ü‚·");

            Vector3 newScale = MisokatuModel.transform.localScale + scaleIncrease;
            MisokatuModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(MisokatuModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.misokatu, SkillLogManager.SkillType.Increase);  // ‘‘ƒƒO¶¬(‰¡’n’Ç‰Á)
        }
    }

    // –¡‘XƒJƒc“X•KE‹Z
    public void OperateMisokatuSpecial()
    {
        if (MisokatsuSpecial.Possible)
        {
            Debug.Log("Misokatu‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
            MisokatuModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(MisokatuModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(MisokatuModel.transform.position);

            MisokatsuSpecial.Possible = false;
        }
    }

    // ‚¤‚¢‚ë‚¤“X‘‘
    public void OperateUirouScaleIncrease()
    {
        if (UirouLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            UirouLevel++;
            Debug.Log("Uirou‚ğ‘‘‚µ‚Ü‚·");

            Vector3 newScale = UirouModel.transform.localScale + scaleIncrease;
            UirouModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(UirouModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.uirou, SkillLogManager.SkillType.Increase);  // ‘‘ƒƒO¶¬(‰¡’n’Ç‰Á)
        }
    }

    // ‚¤‚¢‚ë‚¤“X•KE‹Z
    public void OperateUirouSpecial()
    {
        if (UirouSpecial.Possible)
        {
            Debug.Log("Uirou‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
            UirouModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(UirouModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(UirouModel.transform.position);

            UirouSpecial.Possible = false;
        }
    }

    // ‚Ğ‚Â‚Ü‚Ô‚µ“X‘‘
    public void OperateHitsumabushiScaleIncrease()
    {
        if (HitsumabushiLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            HitsumabushiLevel++;
            Debug.Log("Hitsumabushi‚ğ‘‘‚µ‚Ü‚·");

            Vector3 newScale = HitsumabushiModel.transform.localScale + scaleIncrease;
            HitsumabushiModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(HitsumabushiModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.Hitumabushi, SkillLogManager.SkillType.Increase);  // ‘‘ƒƒO¶¬(‰¡’n’Ç‰Á)
        }
    }

    // ‚Ğ‚Â‚Ü‚Ô‚µ“X•KE‹Z
    public void OperateHitshmabushiSpecial()
    {
        if (HitsumabushiSpecial.Possible)
        {
            Debug.Log("Hitsumabushi‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
            HitsumabushiModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(HitsumabushiModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(HitsumabushiModel.transform.position);

            HitsumabushiSpecial.Possible = false;
        }
    }

    // è‰Hæ“X‘‘
    public void OperateTebasakiScaleIncrease()
    {
        if (TebasakiLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            TebasakiLevel++;
            Debug.Log("TebasakiModel‚ğ‘‘‚µ‚Ü‚·");

            Vector3 newScale = TebasakiModel.transform.localScale + scaleIncrease;
            TebasakiModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(TebasakiModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.Tebasaki, SkillLogManager.SkillType.Increase);  // ‘‘ƒƒO¶¬(‰¡’n’Ç‰Á)
        }
    }
    // è‰Hæ“X•KE‹Z
    public void OperateTebasakiSpecial()
    {
        if (TebasakiSpecial.Possible)
        {
            Debug.Log("TebasakiModel‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
            TebasakiModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(TebasakiModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(TebasakiModel.transform.position);

            TebasakiSpecial.Possible = false;
        }
    }

    // ‘ä˜pƒ‰[ƒƒ““X‘‘
    public void OperateTaiwanRamenScaleIncrease()
    {
        if (TaiwanRamenLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            TaiwanRamenLevel++;
            Debug.Log("TaiwanRamen‚ğ‘‘‚µ‚Ü‚·");

            Vector3 newScale = TaiwanRamenModel.transform.localScale + scaleIncrease;
            TaiwanRamenModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(TaiwanRamenModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.TaiwanRamen, SkillLogManager.SkillType.Increase);  // ‘‘ƒƒO¶¬(‰¡’n’Ç‰Á)
        }
    }

    // ‘ä˜pƒ‰[ƒƒ““X•KE‹Z
    public void OperateTaiwanRamenSpecial()
    {
        if (TaiwanRamenSpecial.Possible)
        {
            Debug.Log("TaiwanRamen‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
            TaiwanRamenModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(TaiwanRamenModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(TaiwanRamenModel.transform.position);

            TaiwanRamenSpecial.Possible = false;
        }
    }

    // ‚«‚µ‚ß‚ñ“X‘‘
    public void OperateKishimenScaleIncrease()
    {
        if (KishimenLevel < maxLevel && PlayerData.Instance.nMoney >= IncreaseOfCapital)
        {
            KishimenLevel++;
            Debug.Log("Kishimen‚ğ‘‘‚µ‚Ü‚·");

            Vector3 newScale = KishimenModel.transform.localScale + scaleIncrease;
            KishimenModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            playerData.AddMoney(-IncreaseOfCapital);

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(KishimenModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.kisimen, SkillLogManager.SkillType.Increase);  // ‘‘ƒƒO¶¬(‰¡’n’Ç‰Á)
        }
    }

    // ‚«‚µ‚ß‚ñ“X•KE‹Z
    public void OperateKishimenSpecial()
    {
        if (KishimenSpecial.Possible)
        {
            Debug.Log("Kishimen‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
            KishimenModel.GetComponent<Store>().UseSkill();

            SoundManager.Instance.PlaySound("Special");

            GameObject Effect1 = Special1EffectManager.SpawnSpecial1Effect(KishimenModel.transform.position);
            GameObject Effect2 = Special2EffectManager.SpawnSpecial2Effect(KishimenModel.transform.position);

            KishimenSpecial.Possible = false;
        }
    }
}
