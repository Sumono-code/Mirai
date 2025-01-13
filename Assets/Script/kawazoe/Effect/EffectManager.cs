using System.Collections;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private ObjectPool signBoardEffectPool;
    [SerializeField] private ObjectPool specialEffectPool;
    [SerializeField] private ObjectPool rivalSpecialEffectPool;
    [SerializeField] private ObjectPool establishmentEffectPool;
    [SerializeField] private ObjectPool shatihokoEffectPool;
    [SerializeField] private ObjectPool increaseOfCapitalEffectPool;

    public ObjectPool SignBoardEffectPool => signBoardEffectPool;
    public ObjectPool SpecialEffectPool => specialEffectPool;
    public ObjectPool RivalSpecialEffectPool => rivalSpecialEffectPool;
    public ObjectPool EstablishEffectPool => establishmentEffectPool;
    public ObjectPool ShatihokoEffectPool => shatihokoEffectPool;
    public ObjectPool IncreaseOfCapitalEffectPool => increaseOfCapitalEffectPool;

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnSignBoardEffect(Vector3 position)
    {
        GameObject fireEffect = signBoardEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnSignBoardEffectAfterTime(fireEffect, 1f)); // 例: 2秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnSignBoardEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば2秒後にエフェクトを戻す
        signBoardEffectPool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnSpecialEffect(Vector3 position)
    {
        GameObject fireEffect = specialEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnSpecialEffectAfterTime(fireEffect, 5f)); // 例: 5秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnSpecialEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば5秒後にエフェクトを戻す
        specialEffectPool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnRivalSpecialEffect(Vector3 position)
    {
        GameObject fireEffect = rivalSpecialEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnRivalSpecialEffectAfterTime(fireEffect, 5f)); // 例: 5秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnRivalSpecialEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば5秒後にエフェクトを戻す
        rivalSpecialEffectPool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnEstablishEffect(Vector3 position)
    {
        GameObject fireEffect = establishmentEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnEstablishEffectAfterTime(fireEffect, 1f)); // 例: 1秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnEstablishEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば1秒後にエフェクトを戻す
        establishmentEffectPool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnShatihokoEffect(Vector3 position)
    {
        GameObject fireEffect = shatihokoEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnShatihokoEffectAfterTime(fireEffect, 3f)); // 例: 3秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnShatihokoEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば3秒後にエフェクトを戻す
        shatihokoEffectPool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnIncreaseOfCapitalEffect(Vector3 position)
    {
        GameObject fireEffect = increaseOfCapitalEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnIncreaseOfCapitalEffectAfterTime(fireEffect, 2.5f)); // 例: 2.5秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnIncreaseOfCapitalEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば2.5秒後にエフェクトを戻す
        increaseOfCapitalEffectPool.ReturnEffect(effect);
    }
}
