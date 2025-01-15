using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ScaleIncreaseButtonAlphaController : MonoBehaviour
{
    public Button targetButton; // ���삵�����{�^��
    public StoreManager StoreObj;
    private int currentValue = 0; // ���݂̒l

    StoreManager target;

    void Start()
    {
        target = StoreObj.GetComponent<StoreManager>();
        // �������F�{�^���̓����x�𔖂��ݒ�
        SetButtonAlpha(0.5f); // 50%����
    }

    void Update()
    {
        // ���l��臒l�𒴂�����{�^����Z���\��
        if (PlayerData.Instance.nMoney >= target.IncreaseOfCapital)
        {
            SetButtonAlpha(1.0f); // ���S�ɕs����
        }
        else
        {
            SetButtonAlpha(0.5f); // �Ăє����\��
        }
    }

    // �{�^���̓����x��ݒ肷��֐�
    private void SetButtonAlpha(float alpha)
    {
        Color buttonColor = targetButton.image.color; // �{�^���̐F���擾
        buttonColor.a = alpha; // ���l��ύX
        targetButton.image.color = buttonColor; // �{�^���ɐF���Đݒ�
    }
}
