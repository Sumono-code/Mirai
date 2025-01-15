using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;        ��Y��������

public class EnemyShop : MonoBehaviour
{
    public enum EnemyStorState
    {
        nomal,
        BrainwashingSkill,
        SpeedDownSkill,
        SubtractionMoneySkill,
        speedUpSkill,
    }

    public int cooltime = 100;      // �K�E�Z�̃N�[���^�C��
    public int cooltimeCount = 0;   // �N�[���^�C���̃J�E���^

    public int speedSkillTime = 100;      // �X�s�[�h�_�E���̌��ʎ���
    public int skillTimeCount = 0;           // �N�[���^�C���̃J�E���^
    public EnemyStorState state = EnemyStorState.nomal;
    int SubtractionMoney = 1000;

    SkillLogManager SkillLogSc;
    NPCManager NPCManagerSc;

    // ��Y�ǉ�
    private EffectManager RivalSpecial1EffectManager;        // �K�E�Z���̃G�t�F�N�g1
    private EffectManager RivalSpecial2EffectManager;        // �K�E�Z���̃G�t�F�N�g2

    GameObject ManageData;
    PlayerData script;

    // Start is called before the first frame update
    void Start()
    {
        ManageData = GameObject.Find("ManageData");
        script = ManageData.GetComponent<PlayerData>();
        NPCManagerSc = GameObject.Find("ManageNPC").GetComponent<NPCManager>();
        SkillLogSc = GameObject.Find("ManageSkillLog").GetComponent<SkillLogManager>();

        // ��Y�ǉ�
        RivalSpecial1EffectManager = FindObjectOfType<EffectManager>();
        RivalSpecial2EffectManager = FindObjectOfType<EffectManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerData.Instance.bGameStart)
        {
            // ��Y���������@�X�y�[�X�L�[����������count��cooltime�ȏ�ɂ���

            if (cooltimeCount > cooltime)
            { // cooltime�����Ԃ��o������
              //BrainwashingSkill();

                // SpeedDownSkill();
            }

            switch (state)
            {
                case EnemyStorState.nomal:
                    cooltimeCount++;
                    if (cooltimeCount > cooltime)
                    { // cooltime�����Ԃ��o������
                        cooltimeCount = 0;
                        int num = Random.Range(0, 100);
                        if (num >= 0 && num < 50)
                        {
                            state = EnemyStorState.BrainwashingSkill;
                            SkillLogSc.CreateSkillLog(SkillLogManager.StoreName.rival1, SkillLogManager.SkillType.rivalSpecial1);
                        }
                        else if (num >= 50 && num < 70)
                        {
                            state = EnemyStorState.SpeedDownSkill;
                            SkillLogSc.CreateSkillLog(SkillLogManager.StoreName.rival1, SkillLogManager.SkillType.rivalSpecial2);
                        }
                        else if (num >= 70 && num < 80)
                        {
                            state = EnemyStorState.SubtractionMoneySkill;
                            SkillLogSc.CreateSkillLog(SkillLogManager.StoreName.rival1, SkillLogManager.SkillType.rivalSpecial3);
                        }
                        else if (num >= 80 && num < 100)
                        {
                            state = EnemyStorState.speedUpSkill;
                            SkillLogSc.CreateSkillLog(SkillLogManager.StoreName.rival1, SkillLogManager.SkillType.rivalSpecial4);
                        }
                    }
                    break;
                case EnemyStorState.SpeedDownSkill:
                    SpeedDownSkill();
                    break;
                case EnemyStorState.BrainwashingSkill:
                    BrainwashingSkill();
                    break;
                case EnemyStorState.SubtractionMoneySkill:
                    SubtractionMoneySkill();
                    break;
                case EnemyStorState.speedUpSkill:
                    SpeedUpSkill();
                    break;
            }
        }
    }


    void BrainwashingSkill()
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // ���݂���Human�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjects�̗v�f�����[�v
            human humanScript = humanObjects[i].GetComponent<human>();              // human�X�N���v�g�擾
            if (humanScript.GetState() == (int)human.human_state.normal)
            { // �擾����humanScript�̏�Ԃ�normal�Ȃ�
                humanScript.SetTargetEnemyStore(this.gameObject);                   // �擾����human�X�N���v�g�̌������G�̓X�����̃I�u�W�F�N�g�ɂ���
                humanScript.SetState(human.human_state.brainwashing);               // �擾����human�X�N���v�g�̏�Ԃ�brainwashing�ɏ�ԑJ��
            }
        }

        state = EnemyStorState.nomal;

        // ��Y�ǉ�
        GameObject effect1 = RivalSpecial1EffectManager.SpawnRivalSpecial1Effect(
                        new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
        GameObject effect2 = RivalSpecial2EffectManager.SpawnRivalSpecial2Effect(
                        new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
    }

    void SpeedDownSkill()
    {
        for (int i = 0; i < NPCManagerSc.humans.Count; i++)
        { // humanObjects�̗v�f�����[�v
            NPCManagerSc.humans[i].GetComponent<human>().speedDown = true;
        }

        skillTimeCount++;
        if (skillTimeCount > speedSkillTime)
        {
            for (int i = 0; i < NPCManagerSc.humans.Count; i++)
            { // humanObjects�̗v�f�����[�v
                NPCManagerSc.humans[i].GetComponent<human>().speedDown = false;
            }
            skillTimeCount = 0;
            state = EnemyStorState.nomal;

            // ��Y�ǉ�
            GameObject effect1 = RivalSpecial1EffectManager.SpawnRivalSpecial1Effect(
                        new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
            GameObject effect2 = RivalSpecial2EffectManager.SpawnRivalSpecial2Effect(
                            new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
        }

    }

    void SubtractionMoneySkill()
    {
        script.AddMoney(-SubtractionMoney);
        state = EnemyStorState.nomal;

        // ��Y�ǉ�
        GameObject effect1 = RivalSpecial1EffectManager.SpawnRivalSpecial1Effect(
                        new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
        GameObject effect2 = RivalSpecial2EffectManager.SpawnRivalSpecial2Effect(
                        new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
    }

    void SpeedUpSkill()
    {
        for (int i = 0; i < NPCManagerSc.humans.Count; i++)
        { // humanObjects�̗v�f�����[�v
            NPCManagerSc.humans[i].GetComponent<human>().speedUp = true;
        }

        skillTimeCount++;
        if (skillTimeCount > speedSkillTime)
        {
            for (int i = 0; i < NPCManagerSc.humans.Count; i++)
            { // humanObjects�̗v�f�����[�v
                NPCManagerSc.humans[i].GetComponent<human>().speedUp = false;
            }
            skillTimeCount = 0;
            state = EnemyStorState.nomal;

            // ��Y�ǉ�
            GameObject effect1 = RivalSpecial1EffectManager.SpawnRivalSpecial1Effect(
                            new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
            GameObject effect2 = RivalSpecial2EffectManager.SpawnRivalSpecial2Effect(
                            new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
        }

    }

    // �X�s�[�h�n�X�L������
    public void Cancellation()
    {
        if (EnemyStorState.SpeedDownSkill == state || EnemyStorState.speedUpSkill == state)
        {
            for (int i = 0; i < NPCManagerSc.humans.Count; i++)
            { // humanObjects�̗v�f�����[�v
                NPCManagerSc.humans[i].GetComponent<human>().speedDown = false;
                NPCManagerSc.humans[i].GetComponent<human>().speedUp = false;
            }

            skillTimeCount = 0;
            state = EnemyStorState.nomal;

        }
    }
}
