using UnityEngine;

public class ClickToShowUI : MonoBehaviour
{
    // �\������UI�I�u�W�F�N�g
    public GameObject uiPanel;

    private GameObject ManageData;
    public BuilldingData builldingData;

    void Start()
    {
        ManageData = GameObject.Find("ManageData");
        builldingData = ManageData.GetComponent<BuilldingData>();

        // �V�[�����œ����UI�I�u�W�F�N�g���������Đݒ�
        if (uiPanel == null)
        {
            GameObject gameObject1 = GameObject.Find("UiToShopCanvas");
            uiPanel = gameObject1;
            Debug.Log("UIPanel ��������܂����B");
        }

        if (uiPanel == null)
        {
            Debug.LogError("UIPanel ��������܂���B�X�N���v�g�Ŏ����ݒ肷�邩�AInspector �Őݒ肵�Ă��������B");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.Log("�N���b�N�͎󂯕t���Ă��܂��I");

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    builldingData.selectedModel = hit.transform.gameObject;
                    uiPanel.GetComponent<CanvasGroup>().alpha = 1.0f; // UI��\������
                    Debug.Log("���f���ɓ������Ă��܂��I");
                }
            }
        }

        if (builldingData.selectedModel == null || Input.GetMouseButtonDown(1))
        {
            uiPanel.GetComponent<CanvasGroup>().alpha = 0f;
            builldingData.selectedModel = null;
            //Debug.Log("alhpa�l��ύX���܂����I");
        }
    }
}

