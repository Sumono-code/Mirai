using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Shati : MonoBehaviour
{
    GameObject GUIManager;
    ManageGUI Managescript;


    // Start is called before the first frame update
    void Start()
    {
        GUIManager = GameObject.Find("ManageGUI");
        Managescript = GUIManager.GetComponent<ManageGUI>();
    }

    public void MouseClick()
    {
        Managescript.ClickShati();
    }
}
