using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    // �g���K�[�ɐG�ꂽ�Ƃ��ɌĂяo�����
    private void OnTriggerEnter(Collider other)
    {
        // �q���[�}���^�O�̃I�u�W�F�N�g�ɔ�������
        if (other.CompareTag("Human"))
        {
            // �q���[�}���I�u�W�F�N�g���A�N�e�B�u�ɂ���i�����Ȃ�����j
            other.gameObject.SetActive(false);

            // �������͊��S�ɔj�󂷂�ꍇ
            // Destroy(other.gameObject);
        }
    }
}
