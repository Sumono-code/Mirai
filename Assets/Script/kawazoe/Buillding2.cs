using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buillding2 : MonoBehaviour
{
    public GameObject TaiwanRamen;
    public GameObject Kishimen;
    public GameObject Raival2;
    public GameObject TaiwanRamenUi;
    public GameObject KishimenUi;

    void Start()
    {

    }

    void Update()
    {
        if (PlayerData.Instance.bGameStart)
        {
            // ÉåÉxÉãÇRÇ…íBÇµÇΩèÍçá
            if (PlayerData.Instance.nCurrentStage == 2)
            {
                TaiwanRamen.SetActive(true);
                Kishimen.SetActive(true);
                Raival2.SetActive(true);
                TaiwanRamenUi.SetActive(true);
                KishimenUi.SetActive(true);
            }
        }
    }
}