using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageResult : MonoBehaviour
{
    public GameObject EndText;
    public Image BlackPanel;

    public GameObject StoreUI;
    public GameObject UI00;
    public GameObject UI01;
    public GameObject UI02;
    public GameObject UI03;
    public GameObject UI04;
   

    private Vector3 txtpos;
    private float FadeAlfa;
    // Start is called before the first frame update
    void Start()
    {
        txtpos = EndText.transform.position;
        BlackPanel.color = new Color(0,0,0,0);
        FadeAlfa = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerData.Instance.bShowResult)
        {
            StoreUI.SetActive(false);
            UI00.SetActive(true);
            UI01.SetActive(false);
            UI02.SetActive(false);
            UI03.SetActive(false);
            UI04.SetActive(false);
           
            if (txtpos.y >= 400)
            {
                txtpos = new Vector3(txtpos.x, txtpos.y - 20.0f, txtpos.z);
            }
            else
            {
                FadeAlfa += 0.005f;
                BlackPanel.color = new Color(0, 0, 0, FadeAlfa);
            }

            EndText.transform.position = txtpos;
        }
       
    }
}
