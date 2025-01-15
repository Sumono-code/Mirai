using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateOnScoreLv2 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // ƒŒƒxƒ‹‚Q‚É’B‚µ‚½ê‡
        if (PlayerData.Instance.nCurrentStage == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
