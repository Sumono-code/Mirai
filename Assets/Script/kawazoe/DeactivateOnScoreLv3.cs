using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateOnScoreLv3 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // レベル３に達した場合
        if (PlayerData.Instance.nCurrentStage == 2)
        {
            gameObject.SetActive(false);
        }
    }
}
