using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillLog : MonoBehaviour
{
    SkillLogManager.SkillType skillType = SkillLogManager.SkillType.NoData;
    SkillLogManager.StoreName storeName = SkillLogManager.StoreName.NoData;

    // ���g�̉摜
    [SerializeField] Image myImage;

    // �q�I�u�W�F�N�g(���O)�̉摜
    [SerializeField] Image nameImage;

    public int alievTime = 0;   // �o�����Ă���̃J�E���g
    public bool Select = false;

    // �e�N�X�`��
    [SerializeField] Sprite Special1;
    [SerializeField] Sprite Special2;
    [SerializeField] Sprite Special3;
    [SerializeField] Sprite Special4;
    [SerializeField] Sprite Special5;

    [SerializeField] Sprite rivalSpecial1;
    [SerializeField] Sprite rivalSpecial2;

    [SerializeField] Sprite Hitsumabushi;
    [SerializeField] Sprite Kishimen;
    [SerializeField] Sprite Misokatsu;
    [SerializeField] Sprite TaiwanRamen;
    [SerializeField] Sprite Tebasaki;
    [SerializeField] Sprite Uirou;
    [SerializeField] Sprite rival;
    [SerializeField] Sprite Increase;

    // Start is called before the first frame update
    void Start()
    {
        myImage = this.gameObject.GetComponent<Image>();    // �ύX���鎩�gimage�擾
        nameImage = this.gameObject.transform.GetChild(0).GetComponent<Image>();    // �ύX����qimage�擾
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        alievTime++;
    }

    // �X�L�����O�̓��e�Z�b�g�֐�
    public void SetSkillLogDate(SkillLogManager.StoreName _storeName, SkillLogManager.SkillType _skillType)
    {
        // �f�[�^�Z�b�g
        storeName = _storeName;
        skillType = _skillType;

        // �摜�Z�b�g
        switch (storeName)
        {
            case SkillLogManager.StoreName.Hitumabushi:
                nameImage.sprite = Hitsumabushi;
                break;
            case SkillLogManager.StoreName.kisimen:
                nameImage.sprite = Kishimen;
                break;
            case SkillLogManager.StoreName.misokatu:
                nameImage.sprite = Misokatsu;
                break;
           case SkillLogManager.StoreName.TaiwanRamen:
                nameImage.sprite = TaiwanRamen;
                break;
            case SkillLogManager.StoreName.Tebasaki:
                nameImage.sprite = Tebasaki;
                break;
            case SkillLogManager.StoreName.uirou:
                nameImage.sprite = Uirou;
                break;
            case SkillLogManager.StoreName.rival1:
                nameImage.sprite = rival;
                break;
            case SkillLogManager.StoreName.rival2:
                nameImage.sprite = rival;
                break;
            case SkillLogManager.StoreName.NoData:

                break;
        }

        switch (skillType)
        {
            case SkillLogManager.SkillType.Special1:
                myImage.sprite = Special1;
                break;
            case SkillLogManager.SkillType.Special2:
                myImage.sprite = Special2;
                break;
            case SkillLogManager.SkillType.Special3:
                myImage.sprite = Special3;
                break;
            case SkillLogManager.SkillType.Special4:
                myImage.sprite = Special4;
                break;
            case SkillLogManager.SkillType.Special5:
                myImage.sprite = Special5;
                break;
            case SkillLogManager.SkillType.rivalSpecial1:
                myImage.sprite = rivalSpecial1;
                break;
            case SkillLogManager.SkillType.rivalSpecial2:
                myImage.sprite = rivalSpecial2;
                break;
            case SkillLogManager.SkillType.Increase:
                myImage.sprite = Increase;
                break;
            case SkillLogManager.SkillType.NoData:

                break;
        }
    }

}
