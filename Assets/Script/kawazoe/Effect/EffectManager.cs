using System.Collections;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private ObjectPool signBoardEffectPool;
    [SerializeField] private ObjectPool specialEffectPool;
    [SerializeField] private ObjectPool rivalSpecialEffectPool;
    [SerializeField] private ObjectPool establishmentEffectPool;

    public ObjectPool SignBoardEffectPool => signBoardEffectPool;
    public ObjectPool SpecialEffectPool => specialEffectPool;
    public ObjectPool RivalSpecialEffectPool => rivalSpecialEffectPool;
    public ObjectPool EstablishEffectPool => establishmentEffectPool;

    // �G�t�F�N�g���Ăяo���A���̌�߂�
    public GameObject SpawnSignBoardEffect(Vector3 position)
    {
        GameObject fireEffect = signBoardEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnSignBoardEffectAfterTime(fireEffect, 1f)); // ��: 2�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnSignBoardEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��2�b��ɃG�t�F�N�g��߂�
        signBoardEffectPool.ReturnEffect(effect);
    }

    // �G�t�F�N�g���Ăяo���A���̌�߂�
    public GameObject SpawnSpecialEffect(Vector3 position)
    {
        GameObject fireEffect = specialEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnSpecialEffectAfterTime(fireEffect, 5f)); // ��: 5�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnSpecialEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��5�b��ɃG�t�F�N�g��߂�
        specialEffectPool.ReturnEffect(effect);
    }

    // �G�t�F�N�g���Ăяo���A���̌�߂�
    public GameObject SpawnRivalSpecialEffect(Vector3 position)
    {
        GameObject fireEffect = rivalSpecialEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnRivalSpecialEffectAfterTime(fireEffect, 5f)); // ��: 5�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnRivalSpecialEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��5�b��ɃG�t�F�N�g��߂�
        rivalSpecialEffectPool.ReturnEffect(effect);
    }

    // �G�t�F�N�g���Ăяo���A���̌�߂�
    public GameObject SpawnEstablishEffect(Vector3 position)
    {
        GameObject fireEffect = establishmentEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnEstablishEffectAfterTime(fireEffect, 1f)); // ��: 1�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnEstablishEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��1�b��ɃG�t�F�N�g��߂�
        establishmentEffectPool.ReturnEffect(effect);
    }
}
