using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelRetry : MonoBehaviour {

    string LastLevel;

	// Use this for initialization
	void Start () {
        LastLevel = PlayerPrefs.GetString("Last Level");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        SceneManager.LoadScene(LastLevel);
    }
 
}
