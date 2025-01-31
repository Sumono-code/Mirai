using UnityEngine;

public class OscillateRotation : MonoBehaviour
{
    private float startZAngle; // 回転の基準角度
    private bool rotatingToPositive = true; // 正の方向に回転しているかどうか
    public float rotationSpeed = 50f; // 回転速度 (度/秒)
    public float rotationLimit = 50f; // 回転範囲の限界 (±50度)

    void Start()
    {
        // 初期のZ軸回転角度を取得
        startZAngle = transform.eulerAngles.z;
    }

    void Update()
    {
        // 現在の角度を取得
        float currentZAngle = transform.eulerAngles.z;

        // Unityの回転は360度制限があるため、角度を-180度から180度に変換
        currentZAngle = NormalizeAngle(currentZAngle);

        // 基準角度との差分を計算
        float deltaAngle = currentZAngle - startZAngle;

        // 回転方向の判定
        if (rotatingToPositive && deltaAngle >= rotationLimit)
        {
            rotatingToPositive = false; // 負の方向に切り替える
        }
        else if (!rotatingToPositive && deltaAngle <= -rotationLimit)
        {
            rotatingToPositive = true; // 正の方向に切り替える
        }

        // 回転を適用
        float rotationStep = rotationSpeed * Time.deltaTime;
        if (!rotatingToPositive) rotationStep = -rotationStep;

        transform.Rotate(0, 0, rotationStep);
    }

    // 角度を-180度〜180度の範囲に正規化
    private float NormalizeAngle(float angle)
    {
        while (angle > 180f) angle -= 360f;
        while (angle < -180f) angle += 360f;
        return angle;
    }
}
