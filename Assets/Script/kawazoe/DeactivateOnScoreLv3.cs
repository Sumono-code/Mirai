using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateOnScoreLv3 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // �X�R�A���ڕW�l�ɒB������I�u�W�F�N�g���A�N�e�B�u������
        if (PlayerData.Instance.nMoney >= 1200)
        {
            gameObject.SetActive(false);
        }
    }
}
