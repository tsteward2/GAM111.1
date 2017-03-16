using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    GameController GameStats;
    PlayerController PlayerStats;
    TriggerControl PlayerReactions;
    //HealthBar
    public float healthDisplay = 1;
    public float CurrentHealth;
    float maxHealth;
    //Scoring
    int CurrentScore;
    int HighScore;
    int TotalScore;

    //Material timers
    public float TimeDisplaymaterialEffect;

    

	// Use this for initialization
	void Awake () {

        GameStats = GameObject.FindObjectOfType<GameController>();
        PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();
        PlayerReactions = PlayerStats.GetComponentInChildren<TriggerControl>();

        maxHealth = PlayerStats.MaxLife;
    }
	
	// Update is called once per frame
	void Update () {
        CurrentHealth = PlayerStats.Life;
        TimeDisplaymaterialEffect = PlayerReactions.TimeDisplay;
        healthDisplay = CurrentHealth / maxHealth;

		
	}


    void saveScore()
    {

    }



}
