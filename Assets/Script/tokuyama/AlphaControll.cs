using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaControll : MonoBehaviour
{
    public Material material;
    bool bMax=false;
    float speed = 0.004f;
    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // �A���t�@�l��ύX���ē�����
        Color color = material.color;

        if(bMax==false)
        {
            color.a += speed;
            if(color.a>=0.35f)
            {
                bMax = true;
            }
        }
        else
        {
            color.a -= speed;
            if (color.a <= 0)
            {
                bMax = false;
            }
        }
        

        material.color = color;
    }
}
