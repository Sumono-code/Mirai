using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateOnScoreLv3 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // ƒŒƒxƒ‹‚R‚É’B‚µ‚½ê‡
        if (PlayerData.Instance.nCurrentStage == 2)
        {
            gameObject.SetActive(false);
        }
    }
}
