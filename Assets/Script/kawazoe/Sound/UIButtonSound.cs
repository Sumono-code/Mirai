using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public AudioClip clickSound;  // �Đ�����T�E���h
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource�R���|�[�l���g���擾�܂��͒ǉ�
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // �K�v�Ȃ�T�E���h�̐ݒ��ύX
        audioSource.playOnAwake = false; // �Đ��̓X�N���v�g����s��
        audioSource.loop = false;       // ���[�v�Đ����Ȃ�
    }

    // �{�^�����N���b�N���ꂽ�Ƃ��ɌĂ΂��֐�
    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound); // �T�E���h���Đ�
        }
    }
}
