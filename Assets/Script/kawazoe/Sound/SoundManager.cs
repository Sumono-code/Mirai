using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;  // �V���O���g���C���X�^���X
    public AudioSource audioSource;      // AudioSource �R���|�[�l���g
    public AudioClip[] soundClips;      // �Đ��\�ȃT�E���h�̃��X�g

    void Awake()
    {
        // �V���O���g���p�^�[��: 1�̃C���X�^���X�̂�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // �V�[���J�ڌ���j�����Ȃ�
        }
        else
        {
            Destroy(gameObject);  // ���̃C���X�^���X�����݂���ꍇ�A���̃I�u�W�F�N�g���폜
        }

        // AudioSource �R���|�[�l���g���擾�܂��͒ǉ�
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // AudioSource �̐ݒ�
        audioSource.playOnAwake = false; // ���������ɉ���炳�Ȃ�
        audioSource.loop = false;        // �������[�v���Ȃ�
    }

    /// <summary>
    /// �T�E���h���Đ����郁�\�b�h
    /// </summary>
    /// <param name="clipName">�Đ�����T�E���h�̖��O</param>
    public void PlaySound(string clipName)
    {
        // �T�E���h�𖼑O�Ō���
        AudioClip clip = GetSoundClipByName(clipName);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);  // �T�E���h���Đ�
        }
        else
        {
            Debug.LogWarning("SoundManager: �T�E���h��������܂���: " + clipName);
        }
    }

    /// <summary>
    /// �T�E���h�̖��O����AudioClip����������w���p�[���\�b�h
    /// </summary>
    /// <param name="clipName">�T�E���h�̖��O</param>
    /// <returns>�Ή�����AudioClip</returns>
    private AudioClip GetSoundClipByName(string clipName)
    {
        foreach (var clip in soundClips)
        {
            if (clip.name == clipName)
            {
                return clip;
            }
        }
        return null;
    }
}
