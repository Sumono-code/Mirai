using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillColli : MonoBehaviour
{
    GameObject parentObj;

    // Start is called before the first frame update
    void Start()
    {
        parentObj = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Human")
        {
            human humanCs = other.GetComponent<human>();
            if(humanCs.GetState() == (int)human.human_state.normal)
            {
                humanCs.SetFavoriteFood(parentObj.GetComponent<Store>().GetFoodType());
                humanCs.SetTargetAllyStore(parentObj);                             // �擾����human�X�N���v�g�̌����������̓X�����̐e�I�u�W�F�N�g�ɂ���
                humanCs.SetState(human.human_state.allyBrainwashing);              // �擾����human�X�N���v�g�̏�Ԃ�allyBrainwashing�ɏ�ԑJ��
            }
        }
    }
}
