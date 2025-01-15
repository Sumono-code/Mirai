using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillLogManager : MonoBehaviour
{
    public enum StoreName
    {
        misokatu,
        uirou,
        kisimen,
        Hitumabushi,
        TaiwanRamen,
        Tebasaki,
        rival1,
        rival2,
        NoData
    }

    public enum SkillType
    {
        Special1,
        Special2,
        Special3,
        Special4,
        Special5,
        rivalSpecial1,
        rivalSpecial2,
        rivalSpecial3,
        rivalSpecial4,
        Increase,
        NoData
    }

    public Object SkillLogObj;
    Vector3 position;
    public GameObject SkillLogParent;
    List<GameObject> SkillLogs = new List<GameObject>();
    public int destroyCount = 10;

    RectTransform size;

    public float slideSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        size = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            CreateSkillLog(StoreName.kisimen, SkillType.Special3);
        }

        for (int i = 0; i < SkillLogs.Count; i++)
        {
            SkillLog skillLogCs = SkillLogs[i].GetComponent<SkillLog>();    // �X�N���v�g�擾

            // �q�G�����L�[�ύX�p(���Ȃ苭��)
            skillLogCs.Select = false;
            SkillLogs[i].transform.SetSiblingIndex(i);

            // �ړ����� �ʓ|������
            Vector3 pos = SkillLogs[i].transform.position;
            
            if (0 > slideSpeed)
            {
                if (pos.x < transform.position.x + size.sizeDelta.x / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2)
                { // ���ړ�
                    pos.x -= slideSpeed;
                }
                if (pos.x >= transform.position.x + size.sizeDelta.x / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2)
                { // �c�ړ�
                    pos.x = transform.position.x + size.sizeDelta.x / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2;
                    if (pos.y < transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count))
                    { // ���ړ�
                        pos.y += Mathf.Abs(slideSpeed);
                    }
                    if (pos.y >= transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count))
                    {
                        pos.y = transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count);
                    }
                }
            }
            else
            {
                if (pos.x > transform.position.x - size.sizeDelta.x / 2 + SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2)
                { // ���ړ�
                    pos.x -= slideSpeed;
                }
                if (pos.x <= transform.position.x - size.sizeDelta.x / 2 + SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2)
                { // �c�ړ�
                    pos.x = transform.position.x - size.sizeDelta.x / 2 + SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2;
                    if (pos.y < transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count))
                    { // ���ړ�
                        pos.y += Mathf.Abs(slideSpeed);
                    }
                    if (pos.y >= transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count))
                    {
                        pos.y = transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count);
                    }
                }
            }

            SkillLogs[i].transform.position = pos;

            // �폜����
            if (skillLogCs.alievTime > destroyCount)
            {
                Destroy(SkillLogs[i]);  // ���O�폜
                SkillLogs.RemoveAt(i);  // ���X�g�v�f�폜
            }
        }

        //RaycastAll�̈����iPointerEventData�j�쐬
        PointerEventData pointData = new PointerEventData(EventSystem.current);

        //RaycastAll�̌��ʊi�[�pList
        List<RaycastResult> RayResult = new List<RaycastResult>();

        //PointerEventData�Ƀ}�E�X�̈ʒu���Z�b�g
        pointData.position = Input.mousePosition;
        //RayCast�i�X�N���[�����W�j
        EventSystem.current.RaycastAll(pointData, RayResult);

        foreach (RaycastResult result in RayResult)
        {
            if(result.gameObject.GetComponent<SkillLog>() != null)
            {
                result.gameObject.GetComponent<SkillLog>().Select = true;
            }
        }

        // �q�G�����L�[�X�V
        for (int i = 0; i < SkillLogs.Count; i++)
        {
            SkillLog skillLogCs = SkillLogs[i].GetComponent<SkillLog>();    // �X�N���v�g�擾

            if (skillLogCs.Select == true)
            {
                SkillLogs[i].transform.SetAsLastSibling();
            }
        }

    }

    // �X�L�����O�����֐�
    public void CreateSkillLog(StoreName storeName, SkillType skillType)
    {
        GameObject obj;

        // �X�L�����O�쐬
        obj = Instantiate(SkillLogObj, SkillLogParent.transform, false) as GameObject;

        // �X�L�����O�Ǘ����X�g�Ɋi�[
        SkillLogs.Add(obj);

        // �X�L�����O���Z�b�g
        obj.GetComponent<SkillLog>().SetSkillLogDate(storeName, skillType);
    }
}
