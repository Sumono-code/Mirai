using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShachiChange : MonoBehaviour
{
    // �؂�ւ���ʒu���w��
    public Vector3 positionA = new Vector3(-100, 0, -100); // �����ʒu
    public Vector3 positionB = new Vector3(22f, -0.2f, 5f); // �؂�ւ���

    // ���݂̏�Ԃ��Ǘ�
    private bool isAtPositionA = true;

    void Update()
    {
        // �G���^�[�L�[�������ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isAtPositionA)
            {
                transform.position = positionB; // �ʒuB�Ɉړ�
            }
            else
            {
                transform.position = positionA; // �ʒuA�Ɉړ�
            }

            // ��Ԃ𔽓]
            isAtPositionA = !isAtPositionA;
        }
    }
}
