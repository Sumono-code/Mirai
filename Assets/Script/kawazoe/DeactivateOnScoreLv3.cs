using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateOnScoreLv3 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // ���x���R�ɒB�����ꍇ
        if (PlayerData.Instance.nCurrentStage == 2)
        {
            gameObject.SetActive(false);
        }
    }
}
