using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ǂ���������������������������������������������������������������

public class NPCManager : MonoBehaviour
{
    public GameObject NPC_00;
    private int nInterval = 60;  //�X�e�[�W�Ȃǂɂ����Pop�̃C���^�[�o���͕ς��̂ł���p
    private int nCntInterval = 0;  //�C���^�[�o���J�E���g�p

    public GameObject Wall;
    private Vector3 Lv2WallPos;
    private Vector3 Lv3WallPos;

    // Start is called before the first frame update
    void Start()
    {
        Lv2WallPos = new Vector3(Wall.transform.position.x+35, Wall.transform.position.y, Wall.transform.position.z);
        Lv3WallPos = new Vector3(Wall.transform.position.x+70, Wall.transform.position.y, Wall.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //�n�ʂ̎�O�̒[�Ɖ��̒[�̍��W X���W�ł�
        int StartPos = 0;
        float EndPos = Wall.transform.position.x - 1.0f;


        if ((PlayerData.Instance.nTime >= 60.0f && PlayerData.Instance.nTime <= 120.0f) ||        //���[�j���O
             (PlayerData.Instance.nTime >= 360.0f && PlayerData.Instance.nTime <= 420.0f) ||        //��
             (PlayerData.Instance.nTime >= 720.0f && PlayerData.Instance.nTime <= 780.0f))          //��
        {
            nInterval = 90;
        }
        else
        {
            nInterval = 180;
        }


        nCntInterval++;
        //�X�e�[�W�ɂ���ďꍇ����
        switch (PlayerData.Instance.nCurrentStage)
        {

        }
        //�ꎞ�I
        if(PlayerData.Instance.nMoney>=1000)
        {
            Wall.transform.position =Lv2WallPos;
        }




        //�ꎞ�I

        if (nCntInterval > nInterval)
        {
            nCntInterval = 0;
            int nRandom = Random.Range(0, 2);

            if(nRandom == 0)
            {
                Instantiate(NPC_00, new Vector3(StartPos, -1, Random.Range(-1.0f, 11.0f)), Quaternion.Euler(0, 90, 0));
            }
            else
            {
                Instantiate(NPC_00, new Vector3(EndPos, -1, Random.Range(-1.0f, 11.0f)), Quaternion.Euler(0, -90, 0));
            }
            

        }

    }
}