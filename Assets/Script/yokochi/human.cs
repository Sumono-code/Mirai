using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class human : MonoBehaviour
{
    List<Material> childMr = new List<Material>();    // �S�Ă̎q�I�u�W�F�N�g�̃}�e���A���i�[���Ă��炢����

    public enum human_state // �l�̏��
    {
        normal,         // �m�[�}�����
        eat,            // �H�����
        brainwashing,   // ���](�G�K�E)
        allyBrainwashing,   // ���](�����K�E)
        Destroy,        // �ޓX
    }

    // �D���͏o�X���Ă���X�̒����烉���_���Őݒ肳���
    private Store.food_type favorite;
    Vector3 pos;
    public float speed;
    GameObject ManageData;
    PlayerData script;
    GameObject child;                               // favorite�I�u�W�F

    bool bCanStore = false;

    int state = (int)human_state.normal;        // �l�̏��(���ŏ�����normal)
    int eatCunt = 0;                            // �H�����ԃJ�E���^
    public int eatTime;                         // �H���ɂ����鎞��
    public int DestroyTime;                     // ���ł���܂ł̎���         
    public float speedUpBuf;                         // �H���ɂ����鎞��
    public float speedDownDeBuf;                     // ���ł���܂ł̎���     
    public int addMoneyVal = 200;

    MeshRenderer mr;          // �������p

    GameObject EnemyTarget;
    GameObject AllyTarget;

    public bool speedUp = false;
    public bool speedDown = false;
    float speedBuf = 1.0f;

    Vector3 popPos;

    // ��Y�ǉ�
    bool eat = false;
    // Human�I�u�W�F�N�g�Ɏq�Ƃ��Ď�������G�t�F�N�g
    [SerializeField] public GameObject rivalSpecialEffect;     // ���]���̃G�t�F�N�g
    private EffectManager effectManager;        // �Ŕ������̃G�t�F�N�g

    NPCManager NPCManagerSc;

    //���R
    private Vector3 HozonVec;
    public Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        NPCManagerSc = GameObject.Find("ManageNPC").GetComponent<NPCManager>();
        ManageData = GameObject.Find("ManageData");
        script = ManageData.GetComponent<PlayerData>();

        mr = GetComponent<MeshRenderer>();      // �������p(�}�e���A�����擾�H)

        // �o�����Ă���X�����ׂĎ擾
        GameObject[] StoreObjects = GameObject.FindGameObjectsWithTag("Store");     // ���݂���Store�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[

        // ���̂Ȃ�����D���������_���ɐݒ�
        if (StoreObjects.Length != 0)
        {
            int num;
            if(script.nCurrentStage != 0 && transform.position.x < 20)
            {
                num = Random.Range(2, StoreObjects.Length);
            }
            else
            {
                num = Random.Range(0, StoreObjects.Length);
            }

            Store storeCs = StoreObjects[num].GetComponent<Store>();
            favorite = storeCs.GetFoodType();
        }

        child = transform.Find("favorite").gameObject;

        GetAllChildMr();        // �S�Ă̎q�I�u�W�F�N�g�̃}�e���A�����擾���Ċi�[

        popPos = this.gameObject.transform.position;

        // ��Y�ǉ�
        effectManager = FindObjectOfType<EffectManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //���R�ǉ�If��
        if (PlayerData.Instance.bGameStart == true)
        {
            pos = transform.position;

            // �Ƃ肠����Y���W�����ȉ��Ȃ����
            if (this.transform.position.y < -1.0f)
            {
                NPCManagerSc.DestroyList(this.gameObject);
                Destroy(this.gameObject);
            }

            switch (state)
            {
                case (int)human_state.normal:
                    // �ړ�����(���ʂɈړ�)
                    Moveforward();
                    break;
                case (int)human_state.eat:          // �H����
                    eatCunt++;
                    for (int i = 0; i < childMr.Count; i++)
                    {
                        childMr[i].color = mr.material.color - new Color32(0, 0, 0, (byte)(255));
                    }
                    if (eatCunt > eatTime)
                    { // ��莞�ԐH��������
                        for (int i = 0; i < childMr.Count; i++)
                        {
                            childMr[i].color = mr.material.color - new Color32(0, 0, 0, (byte)(0));
                        }

                        //Debug.Log("unnti");
                        eatCunt = 0;
                        state = (int)human_state.Destroy;                               // �ޓX��ԂɑJ��
                        if (this.gameObject.transform.position.z > 0)
                        {
                            this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0); // �v���C���[���o���Ɍ�����
                        }
                        else
                        {
                            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0); // �v���C���[���o���Ɍ�����
                        }

                    }
                    break;
                case (int)human_state.Destroy:      // �ޓX���
                                                    // �ړ�����(���ʂɈړ�)
                    Moveforward();

                    for (int i = 0; i < childMr.Count; i++)
                    {
                        childMr[i].color = mr.material.color - new Color32(0, 0, 0, (byte)(mr.material.color.a + 5));
                    }

                    mr.material.color = mr.material.color - new Color32(0, 0, 0, (byte)(mr.material.color.a + 5));  // �����ɂ��Ă���
                    NPCManagerSc.DestroyList(this.gameObject);
                    Destroy(this.gameObject, DestroyTime);                                                           // ��莞�Ԍo������E��


                    // ��Y�ǉ���������
                    if (!eat)
                    {
                        SoundManager.Instance.PlaySound("GetMoney");     // ��Y�@�T�E���h�ǉ�����
                        SoundManager.Instance.PlaySound("gratitude");     // ��Y�@�T�E���h�ǉ�����
                        eat = true;
                        //���R
                        Vector3 pos = new Vector3(transform.position.x, transform.position.y+8, transform.position.z);
                        GameObject ScoreText = canvas.transform.GetChild(0).gameObject;
                        ScoreText.GetComponent<Text>().text = "" + addMoneyVal;
                        if(addMoneyVal>=0)
                        {
                            ScoreText.GetComponent<Text>().text = "+" + addMoneyVal;
                            ScoreText.GetComponent<Text>().color= Color.black;
                        }
                        else
                        {
                            ScoreText.GetComponent<Text>().text = "-" + addMoneyVal;
                            ScoreText.GetComponent<Text>().color = Color.red;
                        }
                        Instantiate(canvas,pos,Quaternion.identity,transform);
                        //GameObject ScoreText = canvas.transform.GetChild(0).gameObject;
                        //ScoreText.GetComponent<Text>().text = "" + addMoneyVal;
                        //ScoreText.GetComponent<Text>().text = "" + addMoneyVal;

                        //�����܂œ��R
                    }
                    
                    // �����܂�

                    break;
                case (int)human_state.brainwashing: // ���]���
                    this.transform.LookAt(EnemyTarget.transform);   // �ړI�̓X�̕���������
                                                                    // ���ʂɈړ�
                    Moveforward();

                    // ��Y�ǉ�
                    rivalSpecialEffect.SetActive(true);

                    break;
                case (int)human_state.allyBrainwashing: // ���]���
                    this.transform.LookAt(AllyTarget.transform);   // �ړI�̓X�̕���������
                                                                   // ���ʂɈړ�
                    Moveforward();

                    break;
            }
        }
    }


    // �v���C���[���̓����蔻��
    void OnCollisionEnter(Collision collision)
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (state == (int)human_state.normal)
        {

            // ��
            if (other.gameObject.tag == "wall")
            {
                this.gameObject.transform.eulerAngles = HozonVec;
                bCanStore = false;
            }

            // �W���H
            if (other.gameObject.tag == "backMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
                bCanStore = true;
                SoundManager.Instance.PlaySound("Attack");     // ��Y�@�T�E���h�ǉ�����
            }
            if (other.gameObject.tag == "leftMarker")
            {
                //���R�ǉ�
                HozonVec = this.gameObject.transform.eulerAngles;
                //���R�ǉ����I���

                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                bCanStore = true;

                SoundManager.Instance.PlaySound("Attack");     // ��Y�@�T�E���h�ǉ�����
                GameObject Effect = effectManager.SpawnSignBoardEffect(transform.position);

            }
            if (other.gameObject.tag == "rightMarker")
            {
                //���R�ǉ�
                HozonVec = this.gameObject.transform.eulerAngles;
                //���R�ǉ����I���

                this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                bCanStore = true;
                SoundManager.Instance.PlaySound("Attack");     // ��Y�@�T�E���h�ǉ�����
                GameObject Effect = effectManager.SpawnSignBoardEffect(transform.position);
            }
            if (other.gameObject.tag == "frontMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
                bCanStore = true;
                // Debug.Log("hitfront");
                SoundManager.Instance.PlaySound("Attack");     // ��Y�@�T�E���h�ǉ�����
            }

            if (other.gameObject.tag == "Store" && bCanStore == true)
            { // �X�ɓ���������
                state = (int)human_state.eat;       // �H����ԂɑJ��
                Destroy(child);
                script.AddMoney(addMoneyVal);       // �������Z

                // ��Y��������
                //script.AddScore(150);               // �X�R�A���Z
            }
            else if (other.gameObject.tag == "EnemyStore" && bCanStore == true)
            { // �G�̓X����������
                state = (int)human_state.eat;       // �H����ԂɑJ��
                addMoneyVal = (-addMoneyVal);
                script.AddScore(addMoneyVal);      // �X�R�A���Z

                Destroy(child);
            }
        }

        if (state == (int)human_state.brainwashing && other.gameObject.name == EnemyTarget.name)
        { // ���]��Ԃ��ړI�̓G�̓X�ɓ���������
            //Debug.Log("e store");
            state = (int)human_state.eat;       // �H����ԂɑJ��

            addMoneyVal = (-addMoneyVal);
            script.AddScore(addMoneyVal);      // �X�R�A���Z

            Destroy(child);

            // ��Y�ǉ�
            rivalSpecialEffect.SetActive(false);
        }

        if (state == (int)human_state.allyBrainwashing && other.gameObject.name == AllyTarget.name)
        { // ���]��Ԃ��ړI�̖����̓X�ɓ���������
            //Debug.Log("e store");
            script.AddMoney(addMoneyVal);       // �������Z

            // ��Y��������
            //script.AddScore(150);               // �X�R�A���Z


            state = (int)human_state.eat;       // �H����ԂɑJ��
            Destroy(child);
        }
    }

    // ��ԑJ�ڊ֐�
    public void SetState(human_state _state)
    {
        state = (int)_state;
        if (_state == human_state.brainwashing) child.GetComponent<favorite>().SetBrainwashingTex();
        if (_state == human_state.allyBrainwashing) child.GetComponent<favorite>().SetFavoriteTex();
    }

    // ��Ԏ擾�֐�
    public int GetState()
    {
        return state;
    }

    // �G�̌������X�Z�b�g�֐�
    public void SetTargetEnemyStore(GameObject _target)
    {
        EnemyTarget = _target;
    }
    public void SetTargetAllyStore(GameObject _target)
    {
        AllyTarget = _target;
    }

    public Store.food_type GetFavoriteFood()
    {
        return favorite;
    }
    public void SetFavoriteFood(Store.food_type _food)
    {
        favorite = _food;
    }

    // �q�}�e���A���擾�֐�
    public void GetAllChildMr()
    {
        List<GameObject> childbjects = new List<GameObject>();

        // �e�I�u�W�F�N�g��Transform���炷�ׂĂ̎q�I�u�W�F�N�g�i�q�̎q�̎q��...�j���擾
        GetChildren(this.gameObject, ref childbjects);

        for (int i = 0; i < childbjects.Count; i++)
        {
            // �q�I�u�W�F�N�g��Transform���擾
            Transform childTransform = childbjects[i].GetComponent<Transform>();

            if (childTransform != null)
            {
                // �q�I�u�W�F�N�g��Renderer���擾
                Renderer childRenderer = childTransform.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    if (childbjects[i].GetComponent<SkinnedMeshRenderer>() != null)   // �K��
                    {
                        var mat = Resources.Load<Material>("Materials/mat");
                        var mats = childbjects[i].GetComponent<SkinnedMeshRenderer>().materials;
                        for (int j = 0; j < childbjects[i].GetComponent<SkinnedMeshRenderer>().materials.Length; j++)
                        {
                            childMr.Add(mats[j]);
                        }
                    }
                    else
                    {
                        childMr.Add(childRenderer.material);
                    }

                    // �q�I�u�W�F�N�g��Material���i�[
                    //childMr.Add(childRenderer.material);
                }
            }
        }
    }

    //�q�v�f���擾���ă��X�g�ɒǉ�
    public void GetChildren(GameObject obj, ref List<GameObject> allChildren)
    {
        Transform children = obj.GetComponentInChildren<Transform>();
        //�q�v�f�����Ȃ���ΏI��
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            allChildren.Add(ob.gameObject);
            GetChildren(ob.gameObject, ref allChildren);
        }
    }

    public void HitLv3(Store.food_type food)
    {
        favorite= food;
        child.GetComponent<favorite>().SetFavoriteTex();
        addMoneyVal = addMoneyVal * 3;
    }

    void Moveforward()
    {
        if(speedUp == true && speedDown == false)
        {
            speedBuf = speedUpBuf;
        }
        else if(speedUp == false && speedDown == true)
        {
            speedBuf = speedDownDeBuf;
        }
        else if (speedUp == true && speedDown == true)
        {
            speedBuf = -speedDownDeBuf + speedUpBuf;
        }
        else
        {
            speedBuf = 1.0f;
        }

        pos += transform.forward * speed * speedBuf;
        transform.position = pos;
        transform.position = new Vector3(transform.position.x, popPos.y, transform.position.z);
    }
}