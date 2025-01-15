//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneManage : MonoBehaviour
{

    public GameObject Cam;
    public GameObject Earth;
    public GameObject MAP;
    public GameObject FirstCube;
    public GameObject SecondCube;
    //�p�l��
    public Image BlackPanel;
    float fFade = 1.0f;
    float movespeed = 0.1f;
    float scalespeed = 0.0004f;
    //
    public GameObject DiaBox;

    //-------------------------------
    public Text talk;
    public string[] texts;
    int textNumber;
    string displayText;
    int textCharNumber;

    int TextSpeedCount=0;
    int TextSpeed=3;   //�傫����Γǂݏグ���x���Ȃ�
    int Interval = 0;

    public GameObject EarthPos;
    float fEarthR = 0.0f;
    public GameObject Shati;
    float fShatiR = 0.0f;
    //MaxImage
    public GameObject Max;

    //���n�̂���
    AudioSource audioSource;
    public AudioClip SE00;
    public AudioClip CurrentShowSE;
    public AudioClip RollSE;
    public AudioClip MoveSE;
    public AudioClip FirstBGM;
    public AudioClip SecondBGM;
    bool bUseDramRoll=false;
    //
    bool bShowMax=false;
    int nShowCount = 0;
    //
    public GameObject CurrentImage;
    //
   
    public Text CurrentScoreText;
    //
    int DramRollCount = 0;
    //
    bool bShowCurrentScore=false;
    //
    bool bUseMoveSE = false;
    // Start is called before the first frame update
    void Start()
    {
        BlackPanel.color = new Color(0, 0, 0, 1.0f);
        DiaBox.SetActive(false);
       // CurrentImage.SetActive(false);
        //���n�̂���
        audioSource = GetComponent<AudioSource>();
        audioSource.clip=FirstBGM;
        audioSource.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�t�F�[�h����
        fFade -= 0.01f;
        BlackPanel.color = new Color(0.0f, 0.0f, 0.0f, fFade);

        //��ڂ�Cube��������n�������������Ă���
        if (Cam.transform.position.z <= FirstCube.transform.position.z)
        {
            //MAP.gameObject.SetActive(false);
            if(Earth.transform.localScale.x>=0.04f)
            {
                Earth.transform.localScale = new Vector3(Earth.transform.localScale.x - scalespeed, Earth.transform.localScale.y - scalespeed, Earth.transform.localScale.z - scalespeed);
            }
        }

        //��ڂ�Cube�܂ňړ���if
        if (Cam.transform.position.z>=SecondCube.transform.position.z)
        {
            Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y, Cam.transform.position.z- movespeed);
        }
        else
        {
            if(bUseMoveSE==false)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(MoveSE);
                audioSource.clip = SecondBGM;
                audioSource.Play();
                bUseMoveSE = true;
            }

            //��]����
            if(fEarthR<=270)
            {
                EarthPos.transform.localEulerAngles = new Vector3(0, fEarthR, 0);
                fEarthR+=2.0f;
            }

            if (fShatiR <= 450)
            {
                Shati.transform.localEulerAngles = new Vector3(0, fShatiR, 0);
                fShatiR += 3.0f;
            }
            else
            {
                DiaBox.SetActive(true);

                //�e�L�X�g�n�̏���----

                TextSpeedCount++;
                if (TextSpeedCount % TextSpeed == 0)
                {

                    if (textCharNumber != texts[textNumber].Length)
                    {
                        displayText = displayText + texts[textNumber][textCharNumber];
                        textCharNumber = textCharNumber + 1;
                    }
                    else
                    {
                        if (textNumber != 2)
                        {

                            if (textNumber != texts.Length - 1)
                            {
                                if (Interval >= 15)//�ړ�
                                {//�ړ�
                                    Interval = 0;
                                    displayText = "";//�ړ�
                                    textCharNumber = 0;//�ړ�
                                    textNumber = textNumber + 1;//�ړ�
                                }
                                else
                                {
                                    Interval++;
                                }
                            }
                            else  //�S�Z���t�̍Ō�܂œ��B������else
                            {
                                if(bUseDramRoll==false)
                                {
                                    audioSource.Stop();
                                    audioSource.PlayOneShot(RollSE);
                                    bUseDramRoll = true;
                                }
                                int RandomNum=0;
                                TextSpeed = 1;
                                DramRollCount++;
                                if(DramRollCount<=300)
                                {
                                    RandomNum = Random.Range(1000, 10000);
                                }
                                else
                                {
                                    
                                    if(bShowCurrentScore==false)
                                    {
                                        audioSource.PlayOneShot(CurrentShowSE);
                                        bShowCurrentScore = true;
                                    }
                                    RandomNum = 1530;
                                    //RandomNum = PlayerData.Instance.nScore;
                                   // RandomNum = 7777;
                                }

                                CurrentScoreText.text = ""+RandomNum;
                                if (CurrentImage.transform.position.x>=960)
                                {
                                    CurrentImage.transform.position = new Vector3(CurrentImage.transform.position.x - 20.0f, CurrentImage.transform.position.y, 0);
                                }
                            }
                        }
                        else
                        {
                            TextSpeed = 1;
                            if (Max.transform.position.y >= 1100)   //���������Ă�̍���
                            {
                                Max.transform.position = new Vector3(Max.transform.position.x, Max.transform.position.y - 10.0f, 0);

                                if (bShowMax == false)
                                {
                                    bShowMax = true;
                                    audioSource.PlayOneShot(SE00);
                                }
                            }
                            else
                            {
                                nShowCount++;
                                if (nShowCount >= 240)
                                {
                                    Interval = 0;
                                    displayText = "";//�ړ�
                                    textCharNumber = 0;//�ړ�
                                    textNumber = textNumber + 1;//�ړ�
                                    TextSpeed = 3;
                                }
                            }
                        }
                    }

                    talk.GetComponent<Text>().text = displayText;
                }
                //����炷�鏈��
                float zRotation = Mathf.Sin(Time.time * 3.0f) * 20;
                Shati.transform.localEulerAngles = new Vector3(Shati.transform.localEulerAngles.x,fShatiR,zRotation);
                //�V�[���J��
                if (bShowCurrentScore == true && Input.GetKey(KeyCode.Return))
                {
                    PlayerData.Instance.Reset();
                    SceneManager.LoadScene("Title");
                }

            }

        }
    }


}
