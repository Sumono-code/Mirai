using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 5f;      // �_�̈ړ����x
    private Vector3 initialPosition; // �_�̏����ʒu
    public float resetPositionX = -540f; // �ďo������X���W
    public float limitPositionX = 540f;  // �������ƂȂ�X���W

    void Start()
    {
        // �����ʒu���L��
        initialPosition = transform.position;
    }

    void Update()
    {
        // �_���E�����Ɉړ�
        transform.position += Vector3.right * speed * Time.deltaTime;

        // �_���w�肳�ꂽX���W�𒴂����獶����ďo��
        if (transform.position.x > limitPositionX)
        {
            Debug.Log("���܂���");
            transform.position = new Vector3(resetPositionX, initialPosition.y, initialPosition.z);
        }
    }
}
