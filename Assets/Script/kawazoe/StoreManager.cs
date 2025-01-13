using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Vector3 scaleIncrease; // �g��T�C�Y

    public GameObject MisokatuModel;
    public GameObject UirouModel;
    public GameObject HitsumabushiModel;
    public GameObject TebasakiModel;
    public GameObject TaiwanRamenModel;
    public GameObject KishimenModel;

    private EffectManager IncreaseOfCapitalEffectManager;        // �������̃G�t�F�N�g
    private EffectManager SpecialEffectManager;                  // �K�E�Z���̃G�t�F�N�g

    // ���n�ǉ�-----------------------------------------------------------------------
    public GameObject skillLogManager;
    SkillLogManager SkillLogCs;

    // Start is called before the first frame update
    void Start()
    {
        SkillLogCs = skillLogManager.GetComponent<SkillLogManager>();

        IncreaseOfCapitalEffectManager = FindObjectOfType<EffectManager>();
        SpecialEffectManager = FindObjectOfType<EffectManager>();
    }
    //-----------------------------------------------------------------------------------

    // ���X�J�c�X����
    public void OperateMisokatuScaleIncrease()
    {
        Debug.Log("Misokatu�𑝎����܂�");

        Vector3 newScale = MisokatuModel.transform.localScale + scaleIncrease;
        MisokatuModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause"); 
        SoundManager.Instance.PlaySound("IncreaseOfCapital");

        GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(MisokatuModel.transform.position);

        SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.misokatu, SkillLogManager.SkillType.Increase);  // �������O����(���n�ǉ�)
    }

    // ���X�J�c�X�K�E�Z
    public void OperateMisokatuSpecial()
    {
        Debug.Log("Misokatu���K�E�Z���g���܂�");
        MisokatuModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(MisokatuModel.transform.position);
    }

    // �����낤�X����
    public void OperateUirouScaleIncrease()
    {
        Debug.Log("Uirou�𑝎����܂�");

        Vector3 newScale = UirouModel.transform.localScale + scaleIncrease;
        UirouModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause");
        SoundManager.Instance.PlaySound("IncreaseOfCapital");

        GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(UirouModel.transform.position);

        SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.uirou, SkillLogManager.SkillType.Increase);  // �������O����(���n�ǉ�)
    }

    // �����낤�X�K�E�Z
    public void OperateUirouSpecial()
    {
        Debug.Log("Uirou���K�E�Z���g���܂�");
        UirouModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(UirouModel.transform.position);
    }

    // �Ђ܂Ԃ��X����
    public void OperateHitshmabushiScaleIncrease()
    {
        Debug.Log("Hitsumabushi�𑝎����܂�");

        Vector3 newScale = HitsumabushiModel.transform.localScale + scaleIncrease;
        HitsumabushiModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause");
        SoundManager.Instance.PlaySound("IncreaseOfCapital");

        GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(HitsumabushiModel.transform.position);

        SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.Hitumabushi, SkillLogManager.SkillType.Increase);  // �������O����(���n�ǉ�)
    }

    // �Ђ܂Ԃ��X�K�E�Z
    public void OperateHitshmabushiSpecial()
    {
        Debug.Log("Hitsumabushi���K�E�Z���g���܂�");
        HitsumabushiModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(HitsumabushiModel.transform.position);
    }

    // ��H��X����
    public void OperateTebasakiScaleIncrease()
    {
        Debug.Log("TebasakiModel�𑝎����܂�");

        Vector3 newScale = TebasakiModel.transform.localScale + scaleIncrease;
        TebasakiModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause");
        SoundManager.Instance.PlaySound("IncreaseOfCapital");

        GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(TebasakiModel.transform.position);

        SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.Tebasaki, SkillLogManager.SkillType.Increase);  // �������O����(���n�ǉ�)
    }

    // ��H��X�K�E�Z
    public void OperateTebasakiSpecial()
    {
        Debug.Log("TebasakiModel���K�E�Z���g���܂�");
        TebasakiModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(TebasakiModel.transform.position);
    }

    // ��p���[�����X����
    public void OperateTaiwanRamenScaleIncrease()
    {
        Debug.Log("TaiwanRamen�𑝎����܂�");

        Vector3 newScale = TaiwanRamenModel.transform.localScale + scaleIncrease;
        TaiwanRamenModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause");
        SoundManager.Instance.PlaySound("IncreaseOfCapital");

        GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(TaiwanRamenModel.transform.position);

        SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.TaiwanRamen, SkillLogManager.SkillType.Increase);  // �������O����(���n�ǉ�)
    }

    // ��p���[�����X�K�E�Z
    public void OperateTaiwanRamenSpecial()
    {
        Debug.Log("TaiwanRamen���K�E�Z���g���܂�");
        TaiwanRamenModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(TaiwanRamenModel.transform.position);
    }

    // �����߂�X����
    public void OperateKishimenScaleIncrease()
    {
        Debug.Log("Kishimen�𑝎����܂�");

        Vector3 newScale = KishimenModel.transform.localScale + scaleIncrease;
        KishimenModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause");
        SoundManager.Instance.PlaySound("IncreaseOfCapital");

        GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(KishimenModel.transform.position);

        SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.kisimen, SkillLogManager.SkillType.Increase);  // �������O����(���n�ǉ�)
    }

    // �����߂�X�K�E�Z
    public void OperateKishimenSpecial()
    {
        Debug.Log("Kishimen���K�E�Z���g���܂�");
        KishimenModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(KishimenModel.transform.position);
    }
}
