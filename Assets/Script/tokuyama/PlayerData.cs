using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public int nMoney = 777;  // 初期のお金
    public int nScore = 0;  // 初期のScore
    public float nTime = 0;    //時間管理  時計とか表示する時用
    //ステージ管理用   ステージ→発展度のこと
    public int nCurrentStage = 0;  
    public int nMaxStage = 3;

    //透明にしてとか言われた処理(キレそう)のために用意するもの
    //汚くなるのでここからで分ける
    public int nSumMoney = 0;
    public float nCountFade = 0;    //透明度   
    private float nFadeSpeed = 0.006f;
    public bool bAppear=false;

    //とりあえずで世界のSTOP系のやつ
    public bool bShowResult = false;
    public bool bNextLevel = false;
    public bool bUseEneULT = false;
    public bool bUseMyULT = false;

    void Awake()
    {
        // シングルトン
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        nTime+=0.1f;


        if (bAppear)
        {
            nCountFade-=nFadeSpeed;

            if (nCountFade <= 0)
            {
                nMoney += nSumMoney;
                nSumMoney = 0;
                bAppear = false;
                nCountFade = 0; //いらんけど一応
            }
        }

       //Scoreに応じてステージレベルが変化する処理

        if(nCurrentStage == 0 && nScore>=300) 
        {
            nCurrentStage = 1;
            bNextLevel = true;
        }

        if (nCurrentStage == 1 && nScore >= 600)
        {
            nCurrentStage = 2;
            bNextLevel = true;
        }
        //時間が来てResultの表示
        if(nTime >= 180) 
        {
            bShowResult = true;
        }
        Debug.Log(nCurrentStage);
    }


    // お金を増やすメソッド
    public void AddMoney(int amount)
    {
        nSumMoney += amount;
        bAppear = true;
        nCountFade = 1;   //透明度   
    }

    public void AddScore(int amount)
    {
        nScore += amount;
    }
}
