using UnityEngine;

public class OscillateRotation : MonoBehaviour
{
    private float startZAngle; // ��]�̊�p�x
    private bool rotatingToPositive = true; // ���̕����ɉ�]���Ă��邩�ǂ���
    public float rotationSpeed = 50f; // ��]���x (�x/�b)
    public float rotationLimit = 50f; // ��]�͈͂̌��E (�}50�x)

    void Start()
    {
        // ������Z����]�p�x���擾
        startZAngle = transform.eulerAngles.z;
    }

    void Update()
    {
        // ���݂̊p�x���擾
        float currentZAngle = transform.eulerAngles.z;

        // Unity�̉�]��360�x���������邽�߁A�p�x��-180�x����180�x�ɕϊ�
        currentZAngle = NormalizeAngle(currentZAngle);

        // ��p�x�Ƃ̍������v�Z
        float deltaAngle = currentZAngle - startZAngle;

        // ��]�����̔���
        if (rotatingToPositive && deltaAngle >= rotationLimit)
        {
            rotatingToPositive = false; // ���̕����ɐ؂�ւ���
        }
        else if (!rotatingToPositive && deltaAngle <= -rotationLimit)
        {
            rotatingToPositive = true; // ���̕����ɐ؂�ւ���
        }

        // ��]��K�p
        float rotationStep = rotationSpeed * Time.deltaTime;
        if (!rotatingToPositive) rotationStep = -rotationStep;

        transform.Rotate(0, 0, rotationStep);
    }

    // �p�x��-180�x�`180�x�͈̔͂ɐ��K��
    private float NormalizeAngle(float angle)
    {
        while (angle > 180f) angle -= 360f;
        while (angle < -180f) angle += 360f;
        return angle;
    }
}
