using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateOnScoreLv2 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // レベル２に達した場合
        if (PlayerData.Instance.nCurrentStage == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
