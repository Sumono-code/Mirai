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
        // scoreが一定に達した場合
        if (PlayerData.Instance.nMoney >= 1200)
        {
            TaiwanRamen.SetActive(true);
            Kishimen.SetActive(true);
            Raival2.SetActive(true);

            Debug.Log("建築します！");
        }

    }
}