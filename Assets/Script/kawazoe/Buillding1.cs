using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buillding1 : MonoBehaviour
{
    public GameObject Hitsumabushi;
    public GameObject Tebasaki;
    public GameObject Raival1;
    public GameObject HitsumabushiUi;
    public GameObject TebasakiUi;

    void Start()
    {

    }

    void Update()
    {
        if (PlayerData.Instance.bGameStart)
        {
            // レベル２に達した場合
            if (PlayerData.Instance.nCurrentStage == 1)
            {
                Hitsumabushi.SetActive(true);
                Tebasaki.SetActive(true);
                Raival1.SetActive(true);
                HitsumabushiUi.SetActive(true);
                TebasakiUi.SetActive(true);
            }
        }
    }
}