using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> effectPool = new Queue<GameObject>();
    public GameObject effectPrefab;
    public int poolSize = 10;

    private void Start()
    {
        // �v�[����������
        for (int i = 0; i < poolSize; i++)
        {
            GameObject effect = Instantiate(effectPrefab);
            effect.SetActive(false);
            effectPool.Enqueue(effect);
        }
    }

    // �G�t�F�N�g���擾���ĕ\��
    public GameObject GetEffect(Vector3 position, Quaternion rotation)
    {
        GameObject effect;

        // �v�[���ɃG�t�F�N�g������΁A������g�p
        if (effectPool.Count > 0)
        {
            effect = effectPool.Dequeue();
        }
        else
        {
            // �v�[������̏ꍇ�A�V�����G�t�F�N�g���C���X�^���X��
            effect = Instantiate(effectPrefab, position, rotation);
        }

        // �ʒu�Ɖ�]��ݒ�
        effect.transform.position = position;
        effect.transform.rotation = rotation;
        effect.SetActive(true);  // �G�t�F�N�g��\��

        return effect;
    }

    // �g�p��A�G�t�F�N�g���v�[���ɖ߂�
    public void ReturnEffect(GameObject effect)
    {
        effect.SetActive(false);  // �G�t�F�N�g���\���ɂ���
        effectPool.Enqueue(effect); // �v�[���ɖ߂�
    }
}
