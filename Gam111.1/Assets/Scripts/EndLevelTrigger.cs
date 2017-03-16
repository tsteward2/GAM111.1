using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour {


    GameController GameScript;
    TriggerControl Player;

	// Use this for initialization
	void Start () {
        GameScript = FindObjectOfType<GameController>();
		Player =  GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<TriggerControl>();
    }
	
	// Update is called once per frame
	void Update () {

        if(Player.TotemCount == 4)
        {
            GameScript.LoadNextlevelComplete();
        }
		
	}
}
