using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Data;
using UnityEngine.SceneManagement;

public class ManageGUI : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 currentPosition = Vector3.zero;

    private bool bCanSet = false;
    private bool bHitGrand = false;
    private int nInterval = 5;
    private int nCntInterval = 0;
    //�Ŕn��Object�܂Ƃ�

    public GameObject Kanban00_Left;
    public GameObject Kanban00_Right;
    public GameObject Kanban00_Preview;
    public GameObject Kanban01_Left;
    public GameObject Kanban01_Right;
    public GameObject Kanban02_Left;
    public GameObject Kanban02_Right;
    public GameObject Shatihoko;
    public GameObject Shatihoko_Preview;
    //
    public GameObject PeekUI;
    //��������v���r���[�̓��ꕨ
    private GameObject PreViewObject;

    int nChoiceOb=-1;  //0=kanban00 , 1=kanban01,  2=kanban02,  3=�V���`�z�R


    // ��Y�ǉ�
    private EffectManager signBoardEffectManager;        // �Ŕݒu���̃G�t�F�N�g
    private EffectManager shatihokoEffect1Manager;        // ���Ⴟ�ق��ݒu���̃G�t�F�N�g1
    private EffectManager shatihokoEffect2Manager;        // ���Ⴟ�ق��ݒu���̃G�t�F�N�g2
    private EffectManager shatihokoEffect3Manager;        // ���Ⴟ�ق��ݒu���̃G�t�F�N�g3
    private EffectManager shatihokoEffect4Manager;        // ���Ⴟ�ق��ݒu���̃G�t�F�N�g4


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        // ��Y�ǉ�
        signBoardEffectManager = FindObjectOfType<EffectManager>();
        shatihokoEffect1Manager = FindObjectOfType<EffectManager>();
        shatihokoEffect2Manager = FindObjectOfType<EffectManager>();
        shatihokoEffect3Manager = FindObjectOfType<EffectManager>();
        shatihokoEffect4Manager = FindObjectOfType<EffectManager>();
        //
        PeekUI.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetKeyDown(KeyCode.Return)))
        {
            SceneManager.LoadScene("Title");
        }


        if (PlayerData.Instance.bGameStart)
        {


            if (PlayerData.Instance.bShowResult == false)
            {
                nCntInterval++;
                //�s�[�N�^�C���\��

                if ((PlayerData.Instance.nTime >= 60.0f && PlayerData.Instance.nTime <= 120.0f) ||        //���[�j���O
                     (PlayerData.Instance.nTime >= 360.0f && PlayerData.Instance.nTime <= 420.0f) ||        //��
                     (PlayerData.Instance.nTime >= 720.0f && PlayerData.Instance.nTime <= 780.0f))          //��
                {
                    PeekUI.SetActive(true);
                }
                else
                {
                    PeekUI.SetActive(false);
                }


                if (bCanSet)
                {
                    var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                    var raycastHitList = Physics.RaycastAll(ray);

                    bHitGrand = false;
                    //�}�E�X����n�`��Pos���v�Z
                    for (int i = 0; i < raycastHitList.Length; i++)
                    {
                        if (raycastHitList[i].collider.tag == "Grand")
                        {
                            var distance = Vector3.Distance(mainCamera.transform.position, raycastHitList[i].point);
                            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
                            currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
                            currentPosition.y = 0;
                            //�}�E�X���n�ʏ�ɂ��������ǂ���
                            bHitGrand = true;
                            PreViewObject.transform.position = currentPosition;
                        }
                    }




                    if (nChoiceOb == 0)
                    {
                        //�ݒu���\�ȏ�Ԃ� [��] �N���b�N��������
                        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && nCntInterval > nInterval)
                        {
                            Destroy(PreViewObject);
                            if (bHitGrand == true)
                            {
                                Instantiate(Kanban00_Left, currentPosition, Quaternion.Euler(0, 0, 0));
                            }
                            nCntInterval = 0;
                            bCanSet = false;
                            nChoiceOb = -1;

                            // ��Y�ǉ�
                            GameObject effect = signBoardEffectManager.SpawnEstablishEffect(currentPosition);
                            SoundManager.Instance.PlaySound("InstallationLv1");
                        }

                        //�ݒu���\�ȏ�Ԃ� [�E] �N���b�N��������
                        if ((Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)) && nCntInterval > nInterval)
                        {
                            Destroy(PreViewObject);
                            if (bHitGrand == true)
                            {
                                Instantiate(Kanban00_Right, currentPosition, Quaternion.Euler(0, 0, 0));
                            }
                            nCntInterval = 0;
                            bCanSet = false;
                            nChoiceOb = -1;

                            // ��Y�ǉ�
                            GameObject effect = signBoardEffectManager.SpawnEstablishEffect(currentPosition);
                            SoundManager.Instance.PlaySound("InstallationLv1");
                        }

                    }
                    else if (nChoiceOb == 1)
                    {
                        //�ݒu���\�ȏ�Ԃ� [��] �N���b�N��������
                        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && nCntInterval > nInterval)
                        {
                            Destroy(PreViewObject);
                            if (bHitGrand == true)
                            {
                                Instantiate(Kanban01_Left, currentPosition, Quaternion.Euler(0, 0, 0));
                            }
                            nCntInterval = 0;
                            bCanSet = false;
                            nChoiceOb = -1;

                            // ��Y�ǉ�
                            GameObject effect = signBoardEffectManager.SpawnEstablishEffect(currentPosition);
                            SoundManager.Instance.PlaySound("InstallationLv2");
                        }

                        //�ݒu���\�ȏ�Ԃ� [�E] �N���b�N��������
                        if ((Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)) && nCntInterval > nInterval)
                        {
                            Destroy(PreViewObject);
                            if (bHitGrand == true)
                            {
                                Instantiate(Kanban01_Right, currentPosition, Quaternion.Euler(0, 0, 0));
                            }
                            nCntInterval = 0;
                            bCanSet = false;
                            nChoiceOb = -1;

                            // ��Y�ǉ�
                            GameObject effect = signBoardEffectManager.SpawnEstablishEffect(currentPosition);
                            SoundManager.Instance.PlaySound("InstallationLv2");
                        }

                    }
                    else if (nChoiceOb == 2)
                    {
                        //�ݒu���\�ȏ�Ԃ� [��] �N���b�N��������
                        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && nCntInterval > nInterval)
                        {
                            Destroy(PreViewObject);
                            if (bHitGrand == true)
                            {
                                Instantiate(Kanban02_Left, currentPosition, Quaternion.Euler(0, 0, 0));
                            }
                            nCntInterval = 0;
                            bCanSet = false;
                            nChoiceOb = -1;

                            // ��Y�ǉ�
                            GameObject effect = signBoardEffectManager.SpawnEstablishEffect(currentPosition);
                            SoundManager.Instance.PlaySound("InstallationLv3");
                        }

                        //�ݒu���\�ȏ�Ԃ� [�E] �N���b�N��������
                        if ((Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)) && nCntInterval > nInterval)
                        {
                            Destroy(PreViewObject);
                            if (bHitGrand == true)
                            {
                                Instantiate(Kanban02_Right, currentPosition, Quaternion.Euler(0, 0, 0));
                            }
                            nCntInterval = 0;
                            bCanSet = false;
                            nChoiceOb = -1;

                            // ��Y�ǉ�
                            GameObject effect = signBoardEffectManager.SpawnEstablishEffect(currentPosition);
                            SoundManager.Instance.PlaySound("InstallationLv3");
                        }

                    }
                    else if (nChoiceOb == 3)
                    {
                        //�ݒu���\�ȏ�Ԃ� [��] �N���b�N��������
                        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && nCntInterval > nInterval)
                        {
                            Destroy(PreViewObject);
                            if (bHitGrand == true)
                            {
                                Instantiate(Shatihoko, currentPosition, Quaternion.Euler(0, 0, 0));
                            }
                            nCntInterval = 0;
                            bCanSet = false;
                            nChoiceOb = -1;

                            // ��Y�ǉ�
                            GameObject effect = shatihokoEffect1Manager.SpawnShatihokoEffect1(
                                new Vector3(currentPosition.x, currentPosition.y - 20.0f, currentPosition.z));

                            GameObject effect14 = shatihokoEffect4Manager.SpawnShatihokoEffect4(currentPosition);
                            GameObject effect15 = shatihokoEffect2Manager.SpawnShatihokoEffect2(Camera.main.transform.position);

                            GameObject effect1 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 10.0f, currentPosition.y + 30.0f, currentPosition.z));
                            GameObject effect2 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 8.0f, currentPosition.y + 28.0f, currentPosition.z));
                            GameObject effect3 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 6.0f, currentPosition.y + 26.0f, currentPosition.z));
                            GameObject effect4 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 11.0f, currentPosition.y + 33.0f, currentPosition.z));
                            GameObject effect5 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 15.0f, currentPosition.y + 20.0f, currentPosition.z));
                            GameObject effect6 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 1.0f, currentPosition.y + 15.0f, currentPosition.z));
                            GameObject effect7 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 2.0f, currentPosition.y + 18.0f, currentPosition.z));

                            GameObject effect8 = shatihokoEffect3Manager.SpawnShatihokoEffect3(
                                new Vector3(currentPosition.x - 10.0f, currentPosition.y + 30.0f, currentPosition.z));
                            GameObject effect9 = shatihokoEffect3Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 8.0f, currentPosition.y + 28.0f, currentPosition.z));
                            GameObject effect10 = shatihokoEffect3Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 12.0f, currentPosition.y + 32.0f, currentPosition.z));
                            GameObject effect11 = shatihokoEffect3Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 15.0f, currentPosition.y + 35.0f, currentPosition.z));
                            GameObject effect12 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 1.0f, currentPosition.y + 15.0f, currentPosition.z));
                            GameObject effect13 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 2.0f, currentPosition.y + 18.0f, currentPosition.z));

                            SoundManager.Instance.PlaySound("Shatihoko");
                        }

                        //�ݒu���\�ȏ�Ԃ� [�E] �N���b�N��������
                        if ((Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)) && nCntInterval > nInterval)
                        {
                            Destroy(PreViewObject);
                            if (bHitGrand == true)
                            {
                                Instantiate(Shatihoko, currentPosition, Quaternion.Euler(0, 0, 0));
                            }
                            nCntInterval = 0;
                            bCanSet = false;
                            nChoiceOb = -1;

                            // ��Y�ǉ�
                            GameObject effect = shatihokoEffect1Manager.SpawnShatihokoEffect1(
                                new Vector3(currentPosition.x, currentPosition.y - 20.0f, currentPosition.z));

                            GameObject effect14 = shatihokoEffect4Manager.SpawnShatihokoEffect4(currentPosition);
                            GameObject effect15 = shatihokoEffect2Manager.SpawnShatihokoEffect2(Camera.main.transform.position);

                            GameObject effect1 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 10.0f, currentPosition.y + 30.0f, currentPosition.z));
                            GameObject effect2 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 8.0f, currentPosition.y + 28.0f, currentPosition.z));
                            GameObject effect3 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 6.0f, currentPosition.y + 26.0f, currentPosition.z));
                            GameObject effect4 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 11.0f, currentPosition.y + 33.0f, currentPosition.z));
                            GameObject effect5 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 15.0f, currentPosition.y + 20.0f, currentPosition.z));
                            GameObject effect6 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 1.0f, currentPosition.y + 15.0f, currentPosition.z));
                            GameObject effect7 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 2.0f, currentPosition.y + 18.0f, currentPosition.z));

                            GameObject effect8 = shatihokoEffect3Manager.SpawnShatihokoEffect3(
                                new Vector3(currentPosition.x - 10.0f, currentPosition.y + 30.0f, currentPosition.z));
                            GameObject effect9 = shatihokoEffect3Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 8.0f, currentPosition.y + 28.0f, currentPosition.z));
                            GameObject effect10 = shatihokoEffect3Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 12.0f, currentPosition.y + 32.0f, currentPosition.z));
                            GameObject effect11 = shatihokoEffect3Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 15.0f, currentPosition.y + 35.0f, currentPosition.z));
                            GameObject effect12 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 1.0f, currentPosition.y + 15.0f, currentPosition.z));
                            GameObject effect13 = shatihokoEffect2Manager.SpawnShatihokoEffect2(
                                new Vector3(currentPosition.x - 2.0f, currentPosition.y + 18.0f, currentPosition.z));


                            SoundManager.Instance.PlaySound("Shatihoko");
                        }

                    }

                    //�ݒu�O���ォ�œ����蔻��Ɣ�������if
                }
            }
        }
    }
    public void ClickKanban00()
    {
        if (bCanSet == true) { return; }
        nChoiceOb = 0;
        bCanSet = true;
        //�v���r���[�����ɑ��
        PreViewObject = Instantiate(Kanban00_Preview, new Vector3(-10, 0, 0), Quaternion.Euler(0, 0, 0));
      
    }

    public void ClickKanban01()
    {
        if (bCanSet == true) { return; }
        nChoiceOb = 1;
        bCanSet = true;
        //�v���r���[�����ɑ��
        PreViewObject = Instantiate(Kanban00_Preview, new Vector3(-10, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void ClickKanban02()
    {
        if (bCanSet == true) { return; }
        nChoiceOb = 2;
        bCanSet = true;
        //�v���r���[�����ɑ��
        PreViewObject = Instantiate(Kanban00_Preview, new Vector3(-10, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void ClickShati()
    {
        if (bCanSet == true) { return; }
        nChoiceOb = 3;
        bCanSet = true;
        //�v���r���[�����ɑ��
        PreViewObject = Instantiate(Shatihoko_Preview, new Vector3(-10, 0, 0), Quaternion.Euler(0, 0, 0));
    }


}
