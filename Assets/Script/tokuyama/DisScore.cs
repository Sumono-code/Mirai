using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisScore : MonoBehaviour
{
   // Color OriginColor;
    // Start is called before the first frame update
    void Start()
    {
       // OriginColor = this.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerData.Instance.bGameStart)
        {
            // OriginColor.a -= 0.01f;
            Color color = gameObject.GetComponent<Text>().color;
            color.a -= 0.02f;
            gameObject.GetComponent<Text>().color = color;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);
        }
    }
}
