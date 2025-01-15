using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SpecialButtonAlphaController : MonoBehaviour
{
    public Button targetButton; // ���삵�����{�^��
    public GameObject StoreObj;
    private int currentValue = 0; // ���݂̒l

    Store target;

    public bool Possible = false;

    void Start()
    {
        target = StoreObj.GetComponent<Store>();
        // �������F�{�^���̓����x�𔖂��ݒ�
        SetButtonAlpha(0.5f); // 50%����
    }

    void Update()
    {
        // ���l��臒l�𒴂�����{�^����Z���\��
        if (target.cooltimeCount >= target.cooltime)
        {
            Possible = true;
            SetButtonAlpha(1.0f); // ���S�ɕs����
        }
        else
        {
            Possible = false;
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
