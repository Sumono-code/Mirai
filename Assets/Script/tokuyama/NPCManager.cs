using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//壁もあつかうぞおおおおおおおおおおおおおおおおおおおおおおおおおおお

public class NPCManager : MonoBehaviour
{
    public GameObject GosuloliNPC;
    public GameObject KaigaiNPC;
    public GameObject SalaryNPC;
    public GameObject DancerNPC;
    public GameObject GodNPC;

    private int nInterval;  //ステージなどによってPopのインターバルは変わるのでそれ用
    private int nCntInterval = 0;  //インターバルカウント用

    public GameObject Wall;
    private Vector3 Lv2WallPos;
    private Vector3 Lv3WallPos;

    public List<GameObject> humans = new List<GameObject>();
    GameObject humanObj;                // リストに入れるよう

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
                //地面の手前の端と奥の端の座標 X座標です
                int StartPos = 0;
                float EndPos = Wall.transform.position.x - 2.0f;


                if ((PlayerData.Instance.nTime >= 60.0f && PlayerData.Instance.nTime <= 120.0f) ||        //モーニング
                     (PlayerData.Instance.nTime >= 360.0f && PlayerData.Instance.nTime <= 420.0f) ||        //昼
                     (PlayerData.Instance.nTime >= 720.0f && PlayerData.Instance.nTime <= 780.0f))          //夜
                {
                    //nInterval = 30;

                    // 川添調整
                    nInterval = 80;
                }
                else
                {
                    //nInterval = 60;

                    // 川添調整
                    nInterval = 140;
                }


                nCntInterval++;
                //ステージによって場合分け
                switch (PlayerData.Instance.nCurrentStage)
                {
                    case 1:
                        Wall.transform.position = Lv2WallPos;
                        break;

                    case 2:
                        Wall.transform.position = Lv3WallPos;
                        break;

                }

                //前か後ろかで場合分けてNPCを生成

                if (nCntInterval > nInterval)
                {
                    nCntInterval = 0;
                    int nRandom = Random.Range(0, 2);
                    int nCharaRandom; 
                    GameObject Chara = GosuloliNPC; //未割り当てになるので初期値にゴスロリ入れてるだけ
                    
                    switch (PlayerData.Instance.nCurrentStage)
                    {
                        case 0:
                            nCharaRandom= Random.Range(0, 3);
                            switch(nCharaRandom)
                            {
                                case 0:
                                    Chara = GosuloliNPC;
                                    break;
                                case 1:
                                    Chara = SalaryNPC;
                                    break;
                                case 2:
                                    Chara = DancerNPC;
                                    break;
                            }
                            break;
                        case 1:

                           nCharaRandom = Random.Range(0, 10);
                            if(nCharaRandom>=0 && nCharaRandom<=2)
                            {
                                nCharaRandom = 0;
                            }
                            else if (nCharaRandom >= 3 && nCharaRandom <= 5)
                            {
                                nCharaRandom = 1;
                            }
                            else if (nCharaRandom >= 5 && nCharaRandom <= 8)
                            {
                                nCharaRandom = 2;
                            }
                            else if (nCharaRandom ==9)
                            {
                                nCharaRandom = 3;
                            }
                            switch (nCharaRandom)
                            {
                                case 0:
                                    Chara = GosuloliNPC;
                                    break;
                                case 1:
                                    Chara = SalaryNPC;
                                    break;
                                case 2:
                                    Chara = DancerNPC;
                                    break;
                                case 3:
                                    Chara = KaigaiNPC;
                                    break;
                            }

                            break;

                        case 2:

                            nCharaRandom = Random.Range(0, 100);
                            if (nCharaRandom >= 0 && nCharaRandom <= 29)
                            {
                                nCharaRandom = 0;
                            }
                            else if (nCharaRandom >= 30 && nCharaRandom <= 59)
                            {
                                nCharaRandom = 1;
                            }
                            else if (nCharaRandom >= 60 && nCharaRandom <= 89)
                            {
                                nCharaRandom = 2;
                            }
                            else if (nCharaRandom >= 90 && nCharaRandom <= 96)
                            {
                                nCharaRandom = 4;
                            }
                            else if (nCharaRandom >= 97 && nCharaRandom <= 99)
                            {
                                nCharaRandom = 5;
                            }
                            switch (nCharaRandom)
                            {
                                case 0:
                                    Chara = GosuloliNPC;
                                    break;
                                case 1:
                                    Chara = SalaryNPC;
                                    break;
                                case 2:
                                    Chara = DancerNPC;
                                    break;
                                case 3:
                                    Chara = KaigaiNPC;
                                    break;
                                case 4:
                                    Chara = GodNPC;
                                    break;
                            }
                            break;

                    }


                    //
                    if (nRandom == 0)
                    {
                        humanObj = Instantiate(Chara, new Vector3(StartPos, -1, Random.Range(-3.0f, 13.0f)), Quaternion.Euler(0, 90, 0));
                        humans.Add(humanObj);
                    }
                    else
                    {
                        humanObj = Instantiate(Chara, new Vector3(EndPos, -1, Random.Range(-3.0f, 13.0f)), Quaternion.Euler(0, -90, 0));
                        humans.Add(humanObj);
                    }

                }
            }
        }
    }

    public void DestroyList(GameObject _human)
    {
        for(int i= 0; i < humans.Count; i++)
        {
            if(_human == humans[i].gameObject)
            {
                humans.RemoveAt(i);
            }
        }
    }
}