using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    // �g���K�[�ɐG�ꂽ�Ƃ��ɌĂяo�����
    private void OnTriggerEnter(Collider other)
    {
        // �q���[�}���^�O�̃I�u�W�F�N�g�ɔ�������
        if (other.CompareTag("Human"))
        {
            Destroy(other.gameObject);
        }
    }
}
