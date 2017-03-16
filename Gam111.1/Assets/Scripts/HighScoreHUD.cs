using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreHUD : MonoBehaviour {


    Text HighScoreText;

    int HighScore;

    // Use this for initialization
    void Start()
    {

        HighScoreText = gameObject.GetComponent<Text>();
        HighScore = PlayerPrefs.GetInt("High Score");

    }

    // Update is called once per frame
    void Update()
    {

        HighScoreText.text = HighScore.ToString();


    }
}
