using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    public Button investButton;  // �����{�^��
    public Button specialButton; // �K�E�Z�{�^��

    private GameObject ManageData;
    private BuilldingData builldingData;

    void Start()
    {
        ManageData = GameObject.Find("ManageData");
        builldingData = ManageData.GetComponent<BuilldingData>();

        // �{�^���ɃN���b�N�C�x���g��ݒ�
        if (investButton != null)
        {
            investButton.onClick.AddListener(HandleInvestButton);
        }
        else
        {
            Debug.LogError("investButton ���ݒ肳��Ă��܂���B");
        }

        if (specialButton != null)
        {
            specialButton.onClick.AddListener(HandleSpecialButton);
        }
        else
        {
            Debug.LogError("specialButton ���ݒ肳��Ă��܂���B");
        }

    }

    // �����{�^�����N���b�N���ꂽ�Ƃ��̏���
    void HandleInvestButton()
    {
        if (builldingData.selectedModel != null)
        {
            builldingData.IsScale = true;
        }
    }

    // �K�E�Z�{�^�����N���b�N���ꂽ�Ƃ��̏���
    void HandleSpecialButton()
    {
        // �K�E�Z�̃A�N�V�����������ɋL�q
        Debug.Log("�K�E�Z�����I");
        // �K�v�ɉ����ē���ȃA�N�V������ǉ�
    }

}
