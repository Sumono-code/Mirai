using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syachiCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Human")
        {
            GameObject obj = null;
            human humanCs = other.gameObject.GetComponent<human>();
            if (humanCs.GetState() == (int)human.human_state.brainwashing)
            {
                GameObject[] StoreObjects = GameObject.FindGameObjectsWithTag("Store");
                for (int i = 0; i < StoreObjects.Length; i++)
                { // humanObjects�̗v�f�����[�v
                    Store StoreScript = StoreObjects[i].GetComponent<Store>();              // human�X�N���v�g�擾
                    if (StoreScript.food == humanCs.GetFavoriteFood())
                    {
                        obj = StoreObjects[i].gameObject;
                    }
                }

                humanCs.SetTargetAllyStore(obj);
                humanCs.SetState(human.human_state.allyBrainwashing);
                //other.transform.eulerAngles = new Vector3(0, 90, 0);
                // ���]��Ԉڍs���ɓ��X�\�t���O���ύX�Ȃ��Ȃ���ɂȂ��@����Ȃ���X�t���O���ύX

                // �D���̃e�N�X�`���ύX
                GameObject favoriteObj = other.gameObject.transform.Find("favorite").gameObject;
                favorite favoriteCs = favoriteObj.GetComponent<favorite>();
                favoriteCs.SetFavoriteTex();
            }
        }
    }
}
