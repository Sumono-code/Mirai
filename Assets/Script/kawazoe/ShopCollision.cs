using UnityEngine;

public class ShopCollision : MonoBehaviour
{
    public AudioClip collisionSound; // ���ʉ����w��
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

    // �Փˎ��ɌĂяo�����
    private void OnCollisionEnter(Collision collision)
    {
        // Player�^�O�̃I�u�W�F�N�g�ƏՓ˂����ꍇ
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    // �g���K�[���g�p����ꍇ
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}