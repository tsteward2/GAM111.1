using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreController : MonoBehaviour {

    GameController Gamestats;

    int Score = 0;

    Text CurrentScoreDisplay;
    

	// Use this for initialization
	void Start () {


        Gamestats = GameObject.FindObjectOfType<GameController>();

        CurrentScoreDisplay = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

        Score = Gamestats.score;

        CurrentScoreDisplay.text = (Score.ToString());
		
	}
}
