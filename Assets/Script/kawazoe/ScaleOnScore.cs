using UnityEngine;

public class ScaleOnScore : MonoBehaviour
{
    public float targetScore = 1000f;    // �X�P�[����ύX����X�R�A��臒l
    public float nextScore = 1000f;
    public Vector3 scaleIncrease = new Vector3(0.4f, 0.4f, 0f); // ���݂̃X�P�[���ɉ��Z����l

    private int Level = 1;

    private void Update()
    {
        // �X�R�A�����l�ɒB������X�P�[���𑝉�
        if (PlayerData.Instance.nScore >= targetScore && Level < 3)
        {
            // ���݂̃X�P�[���ɉ��Z
            transform.localScale += scaleIncrease;

            // ���̃��x���ɍ������X�R�A�l�ɕύX����
            targetScore += nextScore;

            Level++;

            if (Level == 3)
            {
                // �ʒu�̕ύX
                transform.position = new Vector3(transform.position.x, transform.position.y + 70f, transform.position.z);
            }

        }
    }
}