using UnityEngine;

public class ShopCollision : MonoBehaviour
{
    public AudioClip collisionSound1; // ���ʉ����w��
    public AudioClip collisionSound2; // ���ʉ����w��
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource �R���|�[�l���g���擾�܂��͒ǉ�
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void PlayCollisionSounds()
    {
        // ���ʉ��������_���ɍĐ�����
        AudioClip clipToPlay = Random.value > 0.5f ? collisionSound1 : collisionSound2;
        audioSource.PlayOneShot(clipToPlay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            PlayCollisionSounds();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            PlayCollisionSounds();
        }
    }
}
