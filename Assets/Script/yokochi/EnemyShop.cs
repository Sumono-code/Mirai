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
        SpeedDownSkill
    }

    public int cooltime = 100;      // �K�E�Z�̃N�[���^�C��
    public int cooltimeCount = 0;   // �N�[���^�C���̃J�E���^

    public int speedDownSkillTime = 100;      // �X�s�[�h�_�E���̌��ʎ���
    public int skillTimeCount = 0;           // �N�[���^�C���̃J�E���^
    public EnemyStorState state = EnemyStorState.nomal;

    SkillLogManager SkillLogSc;

    // ��Y�ǉ�
    private EffectManager RivalSpecial1EffectManager;        // �K�E�Z���̃G�t�F�N�g1
    private EffectManager RivalSpecial2EffectManager;        // �K�E�Z���̃G�t�F�N�g2

    // Start is called before the first frame update
    void Start()
    {
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
                        else if (num >= 50 && num < 100)
                        {
                            state = EnemyStorState.SpeedDownSkill;
                            SkillLogSc.CreateSkillLog(SkillLogManager.StoreName.rival1, SkillLogManager.SkillType.rivalSpecial2);
                        }
                    }
                    break;
                case EnemyStorState.SpeedDownSkill:
                    SpeedDownSkill();
                    break;
                case EnemyStorState.BrainwashingSkill:
                    BrainwashingSkill();
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
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // ���݂���Human�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[
        human humanScript = null;
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjects�̗v�f�����[�v
            humanScript = humanObjects[i].GetComponent<human>();              // human�X�N���v�g�擾
            humanScript.speedDown = true;
        }

        skillTimeCount++;
        if (skillTimeCount > speedDownSkillTime)
        {
            if(humanScript != null) humanScript.speedDown = false;
            skillTimeCount = 0;
            state = EnemyStorState.nomal;

            // ��Y�ǉ�
            GameObject effect1 = RivalSpecial1EffectManager.SpawnRivalSpecial1Effect(
                        new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
            GameObject effect2 = RivalSpecial2EffectManager.SpawnRivalSpecial2Effect(
                            new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
        }

    }
}
