using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateOnScoreLv2 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // ���x���Q�ɒB�����ꍇ
        if (PlayerData.Instance.nCurrentStage == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
