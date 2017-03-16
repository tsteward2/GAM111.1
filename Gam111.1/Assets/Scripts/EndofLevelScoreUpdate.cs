using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndofLevelScoreUpdate : MonoBehaviour {

    Text ScoreDisplay;

    int score; 
	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt("Score");
        ScoreDisplay = gameObject.GetComponent<Text>();


	}
	
	// Update is called once per frame
	void Update () {

        ScoreDisplay.text ="Level Score:   " + score.ToString();
	}
}
