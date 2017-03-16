using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevelButtonController : MonoBehaviour {

    string LastLevel;

	// Use this for initialization
	void Start () {
        LastLevel = PlayerPrefs.GetString("Last Level");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextLevelClick()
    {
        switch (LastLevel)
        {
            case "Level1":
                {
                    SceneManager.LoadScene("Level2");
                    break;
                }
            case "Level2":
                {
                    SceneManager.LoadScene("Level3");
                    break;
                }
        }
    }
}
