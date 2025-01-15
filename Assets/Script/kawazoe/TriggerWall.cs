using UnityEngine;


public class TriggerWall : MonoBehaviour
{
    NPCManager NPCManagerSc;

    private void Start()
    {
        NPCManagerSc = GameObject.Find("ManageNPC").GetComponent<NPCManager>();
    }

    // �g���K�[�ɐG�ꂽ�Ƃ��ɌĂяo�����
    private void OnTriggerEnter(Collider other)
    {
        // �q���[�}���^�O�̃I�u�W�F�N�g�ɔ�������
        if (other.CompareTag("Human"))
        {
            NPCManagerSc.DestroyList(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
