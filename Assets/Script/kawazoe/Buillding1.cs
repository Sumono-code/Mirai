using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buillding1 : MonoBehaviour
{
    public GameObject Hitsumabushi;
    public GameObject Tebasaki;
    public GameObject Raival1;

    void Start()
    {

    }

    void Update()
    {
        if (PlayerData.Instance.bGameStart)
        {
            // ���x���Q�ɒB�����ꍇ
            if (PlayerData.Instance.nCurrentStage == 1)
            {
                Hitsumabushi.SetActive(true);
                Tebasaki.SetActive(true);
                Raival1.SetActive(true);
            }
        }
    }
}