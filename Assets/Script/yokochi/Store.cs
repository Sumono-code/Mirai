using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{ 
    public enum food_type
    {
        Misokatu,
        Uirou,
        Hitsumabushi,
        Tebasaki,
        TaiwanRamen,
        Kishimen,
    }

    public food_type food;

    public enum StorState
    {
        nomal,
        BrainwashingSkill,
        SmallBrainwashingSkill,
        SpeedUpSkill,
        addMoney
    }

    public GameObject SkillColli;            // �͈͌^���]�X�L���̓����蔻��p�I�u�W�F
    public int cooltimeCount = 0;            // �N�[���^�C���̃J�E���^
    public int cooltime = 100;               // �K�E�Z�̃N�[���^�C��
    public int speedUpSkillTime = 100;       // �X�s�[�h�_�E���̌��ʎ���
    public int SmallBrainwashingSkillTime = 100;       // �X�s�[�h�_�E���̌��ʎ���
    public int skillTimeCount = 0;           // �N�[���^�C���̃J�E���^
    public StorState state = StorState.nomal;
    public int addMoneyVal = 500;            // �X�L���ő��₷����

    PlayerData PLDataSc;

    // Start is called before the first frame update
    void Start()
    {
        PLDataSc = GameObject.Find("ManageData").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        switch (state)
        {
            case StorState.nomal:
                cooltimeCount++;
                if (cooltimeCount >= cooltime)
                {
                    cooltimeCount = cooltime;
                }

                break;
            case StorState.BrainwashingSkill:
                BrainwashingSkill();
                state = StorState.nomal;
                break;
            case StorState.SmallBrainwashingSkill:
                skillTimeCount++;
                if(skillTimeCount > SmallBrainwashingSkillTime)
                {
                    SkillColli.SetActive(false);
                    skillTimeCount = 0;
                    state = StorState.nomal;
                }
                break;
            case StorState.SpeedUpSkill:
                SpeedUpSkill();
                state = StorState.nomal;
                break;
            case StorState.addMoney:
                PLDataSc.AddMoney(addMoneyVal);
                state = StorState.nomal;
                break;
        }

    }

    public food_type GetFoodType()
    {
        return food;
    }

    void BrainwashingSkill()
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // ���݂���Human�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjects�̗v�f�����[�v
            human humanScript = humanObjects[i].GetComponent<human>();              // human�X�N���v�g�擾
            if (humanScript.GetState() == (int)human.human_state.normal)
            { // �擾����humanScript�̏�Ԃ�normal�Ȃ�
                humanScript.SetFavoriteFood(food);
                humanScript.SetTargetAllyStore(this.gameObject);                   // �擾����human�X�N���v�g�̌����������̓X�����̃I�u�W�F�N�g�ɂ���
                humanScript.SetState(human.human_state.allyBrainwashing);          // �擾����human�X�N���v�g�̏�Ԃ�allyBrainwashing�ɏ�ԑJ��
            }
        }

        state = StorState.nomal;
    }

    void SpeedUpSkill()
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // ���݂���Human�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[
        human humanScript = null;
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjects�̗v�f�����[�v
            humanScript = humanObjects[i].GetComponent<human>();              // human�X�N���v�g�擾
            humanScript.speedUp = true;
        }

        skillTimeCount++;
        if (skillTimeCount > speedUpSkillTime)
        {
            if (humanScript != null) humanScript.speedUp = false;
            skillTimeCount = 0;
            state = StorState.nomal;
        }
    }

    public void UseSkill()
    {
        if (cooltimeCount >= cooltime)
        { // cooltime�����Ԃ��o������
            cooltimeCount = 0;
            int num = Random.Range(0, 100);
            if (num >= 0 && num < 25)
            {
                state = StorState.BrainwashingSkill;
            }
            else if (num >= 20 && num < 50)
            {
                state = StorState.SmallBrainwashingSkill;
                SkillColli.SetActive(true);
            }
            else if (num >= 50 && num < 80)
            {
                state = StorState.SpeedUpSkill;
            }
            else if (num >= 80 && num < 100)
            {
                state = StorState.addMoney;
            }
        }
        else
        {
            Debug.Log("�܂��R�X�g���܂��ĂȂ����H");
        }
    }
}
