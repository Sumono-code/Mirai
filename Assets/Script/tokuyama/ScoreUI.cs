using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 川添　大文字に変えた
        ScoreText.text = " SCORE: " + PlayerData.Instance.nScore;
    }
}
