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

    // ���X�J�c�X����
    public void OperateMisokatuScaleIncrease()
    {
        Debug.Log("Misokatu�𑝎����܂�");

        Vector3 newScale = MisokatuModel.transform.localScale + scaleIncrease;
        MisokatuModel.transform.localScale = newScale;
    }

    // ���X�J�c�X�K�E�Z
    public void OperateMisokatuSpecial()
    {
        Debug.Log("Misokatu���K�E�Z���g���܂�");

    }

    // �����낤�X����
    public void OperateUirouScaleIncrease()
    {
        Debug.Log("Uirou�𑝎����܂�");

        Vector3 newScale = UirouModel.transform.localScale + scaleIncrease;
        UirouModel.transform.localScale = newScale;
    }

    // �����낤�X�K�E�Z
    public void OperateUirouSpecial()
    {
        Debug.Log("Uirou���K�E�Z���g���܂�");

    }

    // �Ђ܂Ԃ��X����
    public void OperateHitshmabushiScaleIncrease()
    {
        Debug.Log("Hitsumabushi�𑝎����܂�");

        Vector3 newScale = HitsumabushiModel.transform.localScale + scaleIncrease;
        HitsumabushiModel.transform.localScale = newScale;
    }

    // �Ђ܂Ԃ��X�K�E�Z
    public void OperateHitshmabushiSpecial()
    {
        Debug.Log("Hitsumabushi���K�E�Z���g���܂�");

    }

    // ��H��X����
    public void OperateTebasakiScaleIncrease()
    {
        Debug.Log("TebasakiModel�𑝎����܂�");

        Vector3 newScale = TebasakiModel.transform.localScale + scaleIncrease;
        TebasakiModel.transform.localScale = newScale;
    }

    // ��H��X�K�E�Z
    public void OperateTebasakiSpecial()
    {
        Debug.Log("TebasakiModel���K�E�Z���g���܂�");

    }

    // ��p���[�����X����
    public void OperateTaiwanRamenScaleIncrease()
    {
        Debug.Log("TaiwanRamen�𑝎����܂�");

        Vector3 newScale = TaiwanRamenModel.transform.localScale + scaleIncrease;
        TaiwanRamenModel.transform.localScale = newScale;
    }

    // ��p���[�����X�K�E�Z
    public void OperateTaiwanRamenSpecial()
    {
        Debug.Log("TaiwanRamen���K�E�Z���g���܂�");

    }

    // �����߂�X����
    public void OperateKishimenScaleIncrease()
    {
        Debug.Log("Kishimen�𑝎����܂�");

        Vector3 newScale = KishimenModel.transform.localScale + scaleIncrease;
        KishimenModel.transform.localScale = newScale;
    }

    // �����߂�X�K�E�Z
    public void OperateKishimenSpecial()
    {
        Debug.Log("Kishimen���K�E�Z���g���܂�");

    }
}
