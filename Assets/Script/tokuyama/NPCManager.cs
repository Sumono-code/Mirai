using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ǂ���������������������������������������������������������������

public class NPCManager : MonoBehaviour
{
    public GameObject GosuloliNPC;
    public GameObject KaigaiNPC;
    public GameObject SalaryNPC;
    public GameObject DancerNPC;
    public GameObject GodNPC;

    private int nInterval;  //�X�e�[�W�Ȃǂɂ����Pop�̃C���^�[�o���͕ς��̂ł���p
    private int nCntInterval = 0;  //�C���^�[�o���J�E���g�p

    public GameObject Wall;
    private Vector3 Lv2WallPos;
    private Vector3 Lv3WallPos;

    // Start is called before the first frame update
    void Start()
    {
        Lv2WallPos = new Vector3(Wall.transform.position.x+30, Wall.transform.position.y, Wall.transform.position.z);
        Lv3WallPos = new Vector3(Wall.transform.position.x+70, Wall.transform.position.y, Wall.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerData.Instance.bGameStart == true)
        {
            if (PlayerData.Instance.bShowResult == false)
            {
                //�n�ʂ̎�O�̒[�Ɖ��̒[�̍��W X���W�ł�
                int StartPos = 0;
                float EndPos = Wall.transform.position.x - 2.0f;


                if ((PlayerData.Instance.nTime >= 60.0f && PlayerData.Instance.nTime <= 120.0f) ||        //���[�j���O
                     (PlayerData.Instance.nTime >= 360.0f && PlayerData.Instance.nTime <= 420.0f) ||        //��
                     (PlayerData.Instance.nTime >= 720.0f && PlayerData.Instance.nTime <= 780.0f))          //��
                {
                    //nInterval = 30;

                    // ��Y����
                    nInterval = 80;
                }
                else
                {
                    //nInterval = 60;

                    // ��Y����
                    nInterval = 140;
                }


                nCntInterval++;
                //�X�e�[�W�ɂ���ďꍇ����
                switch (PlayerData.Instance.nCurrentStage)
                {
                    case 1:
                        Wall.transform.position = Lv2WallPos;
                        break;

                    case 2:
                        Wall.transform.position = Lv3WallPos;
                        break;

                }

                //�O����납�ŏꍇ������NPC�𐶐�

                if (nCntInterval > nInterval)
                {
                    nCntInterval = 0;
                    int nRandom = Random.Range(0, 2);
                    int nCharaRandom = Random.Range(0, 5);  //
                    GameObject Chara = GosuloliNPC; //�����蓖�ĂɂȂ�̂ŏ����l�ɃS�X��������Ă邾��
                    switch (nCharaRandom)
                    {
                        case 0:
                            Chara = GosuloliNPC;
                            break;
                        case 1:
                            Chara = KaigaiNPC;
                            break;

                        case 2:
                            Chara = SalaryNPC;
                            break;

                        case 3:
                            Chara = DancerNPC;
                            break;

                        case 4:
                            Chara = GodNPC;
                            break;
                    }

                    if (nRandom == 0)
                    {
                        Instantiate(Chara, new Vector3(StartPos, -1, Random.Range(-3.0f, 13.0f)), Quaternion.Euler(0, 90, 0));
                    }
                    else
                    {
                        Instantiate(Chara, new Vector3(EndPos, -1, Random.Range(-3.0f, 13.0f)), Quaternion.Euler(0, -90, 0));
                    }


                }
            }
        }
    }
}