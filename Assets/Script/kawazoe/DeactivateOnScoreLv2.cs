using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateOnScoreLv2 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // �X�R�A���ڕW�l�ɒB������I�u�W�F�N�g���A�N�e�B�u������
        if (PlayerData.Instance.nMoney >= 1000)
        {
            gameObject.SetActive(false);
        }
    }
}
