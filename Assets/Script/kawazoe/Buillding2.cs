using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buillding2 : MonoBehaviour
{
    public GameObject TaiwanRamen;
    public GameObject Kishimen;
    public GameObject Raival2;

    void Start()
    {

    }

    void Update()
    {
        if (PlayerData.Instance.bGameStart)
        {
            // レベル３に達した場合
            if (PlayerData.Instance.nCurrentStage == 2)
            {
                TaiwanRamen.SetActive(true);
                Kishimen.SetActive(true);
                Raival2.SetActive(true);
            }
        }
    }
}