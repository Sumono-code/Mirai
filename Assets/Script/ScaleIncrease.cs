using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleIncrease : MonoBehaviour
{
    private bool isScaled = false;
    // 拡大倍率
    public Vector3 scaleIncrease = new Vector3(1.0f, 1.0f, 1.0f);
    // 元のサイズを保存
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ScaleIncrease");
        // 初期サイズを保存
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックを検知
        if (Input.GetMouseButtonDown(0)) // 0: 左クリック
        {
            // マウスの位置からRayを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            // Rayが当たったオブジェクトを判定
            if (Physics.Raycast(ray, out hit))
            {
                // このスクリプトがアタッチされているオブジェクトをクリックした場合
                if (hit.transform == transform)
                {
                    // サイズを切り替える
                    if (!isScaled)
                    {
                        Debug.Log("off");
                        StartCoroutine(SmoothScale(originalScale + scaleIncrease));
                        Debug.Log("on");
                    }

                    isScaled = !isScaled; // 状態を切り替える
                }
            }
        }
    }

    IEnumerator SmoothScale(Vector3 targetScale)
    {
        float duration = 0.5f; // 拡大にかける時間
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
