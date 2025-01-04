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
        Debug.Log("����܂���");

        // Player�^�O�̃I�u�W�F�N�g�ƏՓ˂����ꍇ
        if (collision.gameObject.CompareTag("Human"))
        {
            audioSource.PlayOneShot(collisionSound);
            Debug.Log("�Ă΂�܂���");
        }
    }

    // �g���K�[���g�p����ꍇ
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            Debug.Log("�Ă΂�܂���");
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
