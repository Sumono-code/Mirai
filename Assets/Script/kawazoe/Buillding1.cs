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
        // scoreが一定に達した場合
        if (PlayerData.Instance.nMoney >= 1000)
        {
            Hitsumabushi.SetActive(true);
            Tebasaki.SetActive(true);
            Raival1.SetActive(true);

            Debug.Log("建築します！");
        }

    }
}