using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Level1Click()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2Click()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3Click()
    {
        SceneManager.LoadScene("Level3");
    }

    public void BackButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
