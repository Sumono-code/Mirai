using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveVal = 5.0f;    // �J�����̃X�s�[�h
    bool ableMove;                  // �J�����ړ��\�t���O

    // Start is called before the first frame update
    void Start()
    {
        ableMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ableMove == true)
        {
            Vector3 pos = transform.position;
            float val = Input.GetAxis("Mouse ScrollWheel");
            pos.x += val * moveVal;

            // x���W��-5�����ɂȂ�Ȃ��悤�ɐ���
            if (pos.x < -5)
            {
                pos.x = -5;
            }

            // x���W��130�ȏ�ɂȂ�Ȃ��悤�ɐ���
            if (pos.x > 130)
            {
                pos.x = 130;
            }


            transform.position = pos;
        }
    }
}