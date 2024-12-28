using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilldingData : MonoBehaviour
{
    public GameObject prefab; // ���ƂȂ�Prefab
    public List<GameObject> BuilldingPrefabList = new List<GameObject>(); // �����N���[�����Ǘ����郊�X�g

    public Vector3 scaleIncrease = new Vector3(0.5f, 0.5f, 0.5f); // �g��T�C�Y

    public GameObject selectedModel = null; // ���ݑI�𒆂̃��f��
    public bool IsScale = false;            // �����\��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (selectedModel != null && IsScale)
        {
            Vector3 newScale = selectedModel.transform.localScale + scaleIncrease;
            selectedModel.transform.localScale = newScale;
            //SmoothScale(newScale);
            Debug.Log($"���f�� {selectedModel.name} �̃X�P�[����ύX���܂���: {newScale}");

            // ������
            selectedModel = null;
            IsScale = false;
        }

        // ���X�g�̏�Ԃ����O�Ŋm�F
        //LogPrefabList();
    }

    public void AddBuillding()
    {
        BuilldingPrefabList.Add(prefab);
    }

    public void LogPrefabList()
    {
        Debug.Log($"���݂�Prefab���X�g�̓��e�i{BuilldingPrefabList.Count} ���j�F");
        for (int i = 0; i < BuilldingPrefabList.Count; i++)
        {
            Debug.Log($"���X�g[{i}] = {BuilldingPrefabList[i].name}, Position: {BuilldingPrefabList[i].transform.position}");
        }
    }

    public bool Contains(GameObject obj)
    {
        return BuilldingPrefabList.Contains(obj);
    }

    // �g������X�ɂ������������A�֐�����肭�@�\���Ȃ��̂łƂ肠���������B��

    //IEnumerator SmoothScale(Vector3 targetScale)
    //{
    //    float duration = 0.5f;      // �g��ɂ����鎞��
    //    Vector3 startScale = selectedModel.transform.localScale;
    //    float elapsedTime = 0f;

    //    while (elapsedTime < duration)
    //    {
    //        selectedModel.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    selectedModel.transform.localScale = targetScale;
    //}
}


