using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Data;

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

    //��������v���r���[�̓��ꕨ
    private GameObject PreViewObject;

    int nChoiceOb=-1;  //0=kanban00 , 1=kanban01,  2=kanban02,  3=�V���`�z�R


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerData.Instance.bShowResult == false)
        {
            nCntInterval++;
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
                    }

                }

                //�ݒu�O���ォ�œ����蔻��Ɣ�������if
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
        PreViewObject = Instantiate(Kanban00_Preview, new Vector3(-10, 0, 0), Quaternion.Euler(0, 0, 0));
    }


}
