using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    // �J�ڂ���V�[�������w��
    public string targetSceneName;

    void Update()
    {
        // �}�E�X�̍��N���b�N�����m
        if (Input.GetMouseButtonDown(0))
        {
            // �V�[����ύX
            ChangeScene();
        }
    }

    // �V�[����ύX���郁�\�b�h
    void ChangeScene()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("Target scene name is not set.");
        }
    }
}
