using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GugeUI : MonoBehaviour
{
    public GameObject storeObj;         // ���X�̃I�u�W�F�N�g
    Store store;                        // �X�g�A�X�N���v�g
    EnemyShop EneStore;                 // �G�X�g�A�X�N���v�g
    bool AllyCheck = true;              // �G�������̓X�����ʗp(true:���� false:�G

    // �e�N�X�`��
    [SerializeField] Sprite UpGauge1;
    [SerializeField] Sprite UpGauge2;
    [SerializeField] Sprite UpGauge3;
    [SerializeField] Sprite UpGauge4;
    [SerializeField] Sprite UpGauge5;
    [SerializeField] Sprite UpGauge6;
    [SerializeField] Sprite UpGauge7;
    [SerializeField] Sprite UpGauge8;
    [SerializeField] Sprite UpGauge9;
    [SerializeField] Sprite UpGauge10;
    [SerializeField] Sprite UpGauge11;

    [SerializeField] Image myImage;     // image�ύX�p

    void Start()
    {
        // �X�̃X�N���v�g�擾
        store = storeObj.GetComponent<Store>();     // ����
        if(store == null)
        {
            EneStore = storeObj.GetComponent<EnemyShop>();  // �G
            AllyCheck = false;            
        }

        myImage = this.gameObject.GetComponent<Image>();    // �ύX����image�擾
    }

    void FixedUpdate()
    {
        float GaugePoint = 0;

        // �X�̃N�[���^�C���̐��l�擾���Ċ����v�Z
        if (AllyCheck == true)
        { // ����
            GaugePoint = (float)(store.cooltimeCount) / (float)(store.cooltime) * 100;
        }
        else
        { // �G
            GaugePoint = (float)(EneStore.cooltimeCount) / (float)(EneStore.cooltime) * 100;
        }

        // �����ɉ����ĉ摜�ύX
        if (GaugePoint >= 0 && GaugePoint <= 9)
        {
            myImage.sprite = UpGauge1;
        }
        else if (GaugePoint >= 10 && GaugePoint <= 19)
        {
            myImage.sprite = UpGauge2;
        }
        else if (GaugePoint >= 20 && GaugePoint <= 29)
        {
            myImage.sprite = UpGauge3;
        }
        else if (GaugePoint >= 30 && GaugePoint <= 39)
        {
            myImage.sprite = UpGauge4;
        }
        else if (GaugePoint >= 40 && GaugePoint <= 49)
        {
            myImage.sprite = UpGauge5;
        }
        else if (GaugePoint >= 50 && GaugePoint <= 59)
        {
            myImage.sprite = UpGauge6;
        }
        else if (GaugePoint >= 60 && GaugePoint <= 69)
        {
            myImage.sprite = UpGauge7;
        }
        else if (GaugePoint >= 70 && GaugePoint <= 79)
        {
            myImage.sprite = UpGauge8;
        }
        else if (GaugePoint >= 80 && GaugePoint <= 89)
        {
            myImage.sprite = UpGauge9;
        }
        else if (GaugePoint >= 90 && GaugePoint <= 99)
        {
            myImage.sprite = UpGauge10;
        }
        else if (GaugePoint >= 100)
        {
            myImage.sprite = UpGauge11;
        }
    }
}

