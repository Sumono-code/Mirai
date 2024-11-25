using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billding : MonoBehaviour
{
    public GameObject buildingPrefab;       // 建設する建物のPrefab
    private bool isConstructed = false;     // 建物が建設済みかどうか

    private void Update()
    {
        // ↓scoreが内部的に無いため、Eキーで代用

        // Eキーが押され、建物がまだ建設されていない場合
        if (Input.GetKeyDown(KeyCode.E) && !isConstructed)
        {
            ConstructBuilding();
        }
    }

    private void ConstructBuilding()
    {
        if (buildingPrefab != null)
        {
            // 現在の空き地の位置に建物を設置
            Instantiate(buildingPrefab, transform.position, Quaternion.identity);

            // 空き地のGameObjectを削除
            Destroy(gameObject);

            isConstructed = true;
        }
    }
}