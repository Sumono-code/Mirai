using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] soundEffects; // ���ʉ����i�[����z��
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // ���ʉ����Đ����郁�\�b�h
    public void PlaySound(int index)
    {
        if (index >= 0 && index < soundEffects.Length)
        {
            audioSource.PlayOneShot(soundEffects[index]);
        }
        else
        {
            Debug.LogWarning("�w�肳�ꂽ���ʉ��C���f�b�N�X�������ł��B");
        }
    }
}
