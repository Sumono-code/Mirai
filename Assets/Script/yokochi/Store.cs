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
        cancellationSkill,
        addMoney,
        EnemySkillDownTimeSkill,
    }

    public GameObject SkillColli;            // �͈͌^���]�X�L���̓����蔻��p�I�u�W�F
    public int cooltimeCount = 0;            // �N�[���^�C���̃J�E���^
    public int cooltime = 100;               // �K�E�Z�̃N�[���^�C��
    public int SmallBrainwashingSkillTime = 100;       // ���ʎ���
    public int skillTimeCount = 0;           // �N�[���^�C���̃J�E���^
    public StorState state = StorState.nomal;
    int addMoneyVal = 3000;            // �X�L���ő��₷����
    public int EneTimeDownVal = 100;

    PlayerData PLDataSc;

    bool cancellationFlag = false;
    public float cancellationPer = 50;
    public float brainwashingPer = 20;
    public float smallBrainwashingPer = 30;
    public float addMoneyPer = 30;



    SkillLogManager SkillLogSc;
    SkillLogManager.StoreName storeName;

    // Start is called before the first frame update
    void Start()
    {
        PLDataSc = GameObject.Find("ManageData").GetComponent<PlayerData>();
        SkillLogSc = GameObject.Find("ManageSkillLog").GetComponent<SkillLogManager>();

        // �ʓ|�������̂ł����ŃX�L�����O�̂Ȃ܂��Z�b�g
        switch (food)
        {
            case food_type.Misokatu:
                storeName = SkillLogManager.StoreName.misokatu;
                break;
            case food_type.Uirou:
                storeName = SkillLogManager.StoreName.uirou;
                break;
            case food_type.Hitsumabushi:
                storeName = SkillLogManager.StoreName.Hitumabushi;
                break;
            case food_type.Tebasaki:
                storeName = SkillLogManager.StoreName.Tebasaki;
                break;
            case food_type.TaiwanRamen:
                storeName = SkillLogManager.StoreName.TaiwanRamen;
                break;
            case food_type.Kishimen:
                storeName = SkillLogManager.StoreName.kisimen;
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerData.Instance.bGameStart)
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
                    if (skillTimeCount > SmallBrainwashingSkillTime)
                    {
                        SkillColli.SetActive(false);
                        skillTimeCount = 0;
                        state = StorState.nomal;
                    }

                    break;
                case StorState.cancellationSkill:
                    CancellationSkill();
                    state = StorState.nomal;
                    break;
                case StorState.addMoney:
                    PLDataSc.AddMoney(addMoneyVal);
                    state = StorState.nomal;
                    break;
                case StorState.EnemySkillDownTimeSkill:
                    EnemySkillDownTimeSkill();
                    state = StorState.nomal;

                    break;
            }
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

    void CancellationSkill()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("EnemyStore");
        EnemyShop enemyScript = null;
        for (int i = 0; i < enemyObjects.Length; i++)
        { // humanObjects�̗v�f�����[�v
            enemyScript = enemyObjects[i].GetComponent<EnemyShop>();              // human�X�N���v�g�擾
            enemyScript.Cancellation();
        }
        state = StorState.nomal;
    }

    public void UseSkill()
    {
        if (cooltimeCount >= cooltime)
        { // cooltime�����Ԃ��o������
            cooltimeCount = 0;
            int num = Random.Range(0, 100);

            // �X�s�[�h�����t���O
            float Per;
            float cancellation;
            GameObject[] EnemyObjects = GameObject.FindGameObjectsWithTag("EnemyStore");     // ���݂���enemysore�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[
            for (int i = 0; i < EnemyObjects.Length; i++)
            { // humanObjects�̗v�f�����[�v
                EnemyShop EnemyScript = EnemyObjects[i].GetComponent<EnemyShop>();              // �X�N���v�g�擾
                if (EnemyScript.state == EnemyShop.EnemyStorState.speedUpSkill || EnemyScript.state == EnemyShop.EnemyStorState.SpeedDownSkill)
                {
                    cancellationFlag = true;                
                }
            }
            if (cancellationFlag == true)
            {
                cancellation = cancellationPer;
                Per = 100 - cancellation;
            }
            else
            {
                Per = 100;
                cancellation = 0;
            }
            cancellationFlag = false;

            if (num >= 0 && num < cancellation)
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special3);
                state = StorState.cancellationSkill;
            }
            else if (num >= cancellation && num < cancellation + (Per * (smallBrainwashingPer / 100)))
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special4);
                state = StorState.SmallBrainwashingSkill;
                SkillColli.SetActive(true);
            }
            else if (num >= cancellation + (Per * (smallBrainwashingPer / 100)) && num < cancellation + (Per * (smallBrainwashingPer / 100)) + (Per * (brainwashingPer / 100)))
            {
                state = StorState.BrainwashingSkill;
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special1);
            }
            else if (num >= cancellation + (Per * (smallBrainwashingPer / 100)) + (Per * (brainwashingPer / 100)) && num < cancellation + (Per * (smallBrainwashingPer / 100)) + (Per * (brainwashingPer / 100)) + (Per * (addMoneyPer / 100)))
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special5);
                state = StorState.addMoney;
            }
            else if (num >= cancellation + (Per * (smallBrainwashingPer / 100)) + (Per * (brainwashingPer / 100)) + (Per * (addMoneyPer / 100)) && num < 100)
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special2);
                state = StorState.EnemySkillDownTimeSkill;
            }
        }
        else
        {
            Debug.Log("�܂��R�X�g���܂��ĂȂ����H");
        }
    }

    void EnemySkillDownTimeSkill()
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("EnemyStore");     // ���݂���Human�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[
        EnemyShop EnemyScript = null;
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjects�̗v�f�����[�v
            EnemyScript = humanObjects[i].GetComponent<EnemyShop>();              // human�X�N���v�g�擾
            EnemyScript.cooltimeCount -= EneTimeDownVal;

            if (EnemyScript.cooltimeCount < 0)
            {
                EnemyScript.cooltimeCount = 0;
            }
        }
    }
}