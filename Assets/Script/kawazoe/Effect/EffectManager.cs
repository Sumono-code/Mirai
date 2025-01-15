using System.Collections;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private ObjectPool signBoardEffectPool;
    [SerializeField] private ObjectPool special1EffectPool;
    [SerializeField] private ObjectPool special2EffectPool;
    [SerializeField] private ObjectPool rivalSpecial1EffectPool;
    [SerializeField] private ObjectPool rivalSpecial2EffectPool;
    [SerializeField] private ObjectPool establishmentEffectPool;
    [SerializeField] private ObjectPool shatihokoEffect1Pool;
    [SerializeField] private ObjectPool shatihokoEffect2Pool;
    [SerializeField] private ObjectPool shatihokoEffect3Pool;
    [SerializeField] private ObjectPool shatihokoEffect4Pool;
    [SerializeField] private ObjectPool increaseOfCapitalEffectPool;

    public ObjectPool SignBoardEffectPool => signBoardEffectPool;
    public ObjectPool Special1EffectPool => special1EffectPool;
    public ObjectPool Special2EffectPool => special2EffectPool;
    public ObjectPool RivalSpecial1EffectPool => rivalSpecial1EffectPool;
    public ObjectPool RivalSpecial2EffectPool => rivalSpecial2EffectPool;
    public ObjectPool EstablishEffectPool => establishmentEffectPool;
    public ObjectPool ShatihokoEffect1Pool => shatihokoEffect1Pool;
    public ObjectPool ShatihokoEffect2Pool => shatihokoEffect2Pool;
    public ObjectPool ShatihokoEffect3Pool => shatihokoEffect3Pool;
    public ObjectPool ShatihokoEffect4Pool => shatihokoEffect4Pool;
    public ObjectPool IncreaseOfCapitalEffectPool => increaseOfCapitalEffectPool;

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
    public GameObject SpawnSpecial1Effect(Vector3 position)
    {
        GameObject fireEffect = special1EffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnSpecial1EffectAfterTime(fireEffect, 5f)); // ��: 5�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnSpecial1EffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��5�b��ɃG�t�F�N�g��߂�
        special1EffectPool.ReturnEffect(effect);
    }

    // �G�t�F�N�g���Ăяo���A���̌�߂�
    public GameObject SpawnSpecial2Effect(Vector3 position)
    {
        GameObject fireEffect = special2EffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnSpecial2EffectAfterTime(fireEffect, 5f)); // ��: 5�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnSpecial2EffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��5�b��ɃG�t�F�N�g��߂�
        special2EffectPool.ReturnEffect(effect);
    }

    // �G�t�F�N�g���Ăяo���A���̌�߂�
    public GameObject SpawnRivalSpecial1Effect(Vector3 position)
    {
        GameObject fireEffect = rivalSpecial1EffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnRivalSpecial1EffectAfterTime(fireEffect, 5f)); // ��: 5�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnRivalSpecial1EffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��5�b��ɃG�t�F�N�g��߂�
        rivalSpecial1EffectPool.ReturnEffect(effect);
    }

    public GameObject SpawnRivalSpecial2Effect(Vector3 position)
    {
        GameObject fireEffect = rivalSpecial2EffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnRivalSpecial2EffectAfterTime(fireEffect, 5f)); // ��: 5�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnRivalSpecial2EffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��5�b��ɃG�t�F�N�g��߂�
        rivalSpecial2EffectPool.ReturnEffect(effect);
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

    public GameObject SpawnShatihokoEffect1(Vector3 position)
    {
        GameObject fireEffect = shatihokoEffect1Pool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnShatihokoEffect1AfterTime(fireEffect, 8f)); // ��: 3�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnShatihokoEffect1AfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��3�b��ɃG�t�F�N�g��߂�
        shatihokoEffect1Pool.ReturnEffect(effect);
    }

    // �G�t�F�N�g���Ăяo���A���̌�߂�
    public GameObject SpawnShatihokoEffect2(Vector3 position)
    {
        GameObject fireEffect = shatihokoEffect2Pool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnShatihokoEffect2AfterTime(fireEffect, 10f)); // ��: 3�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnShatihokoEffect2AfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��3�b��ɃG�t�F�N�g��߂�
        shatihokoEffect2Pool.ReturnEffect(effect);
    }

    // �G�t�F�N�g���Ăяo���A���̌�߂�
    public GameObject SpawnShatihokoEffect3(Vector3 position)
    {
        GameObject fireEffect = shatihokoEffect3Pool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnShatihokoEffect3AfterTime(fireEffect, 10f)); // ��: 3�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnShatihokoEffect3AfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��3�b��ɃG�t�F�N�g��߂�
        shatihokoEffect3Pool.ReturnEffect(effect);
    }

    // �G�t�F�N�g���Ăяo���A���̌�߂�
    public GameObject SpawnShatihokoEffect4(Vector3 position)
    {
        GameObject fireEffect = shatihokoEffect4Pool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnShatihokoEffect4AfterTime(fireEffect, 8f)); // ��: 3�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnShatihokoEffect4AfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��3�b��ɃG�t�F�N�g��߂�
        shatihokoEffect4Pool.ReturnEffect(effect);
    }

    // �G�t�F�N�g���Ăяo���A���̌�߂�
    public GameObject SpawnIncreaseOfCapitalEffect(Vector3 position)
    {
        GameObject fireEffect = increaseOfCapitalEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnIncreaseOfCapitalEffectAfterTime(fireEffect, 2.5f)); // ��: 2.5�b��ɃG�t�F�N�g���v�[���ɖ߂�
        return fireEffect;
    }

    // �G�t�F�N�g���v�[���ɖ߂�
    private IEnumerator ReturnIncreaseOfCapitalEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // �Ⴆ��2.5�b��ɃG�t�F�N�g��߂�
        increaseOfCapitalEffectPool.ReturnEffect(effect);
    }
}
