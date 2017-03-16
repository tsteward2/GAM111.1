using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int score = 0;
    public float time = 0.0f;
    public float CurrentHealth; 

    public GameObject RubblePrefab;
    public GameObject GrazeSpark;
    PlayerController PlayerControl;


    //GamePickUps

    public GameObject AirTotem;
    public GameObject WaterTotem;
    public GameObject EarthTotem;
    public GameObject FireTotem;
    GameObject[] TotemPickUps;
    public bool[] PickedUp;

    public GameObject healthPickUp;

    //CurrentScene
    string CurrentSceneName;

    //Level Controller
   public GameObject[] HazardSpawns;
    GameObject[] EnemySpawns;
    GameObject[] TotemSpawns;

    public GameObject[] Hazards;
    public GameObject[] Enemies;
    



	// Use this for initialization
	void Awake () {
        PickedUp = new bool[] { false, false, false, false };
        CurrentSceneName = SceneManager.GetActiveScene().name;
        PlayerControl = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();
        TotemPickUps = new GameObject[] { AirTotem, WaterTotem, FireTotem, EarthTotem };
        HazardSpawns = GameObject.FindGameObjectsWithTag("HazardMarker");
        EnemySpawns = GameObject.FindGameObjectsWithTag("EnemyMarker");
        TotemSpawns = GameObject.FindGameObjectsWithTag("TotemMarker");
       
		
	}
    private void Start()
    {
        LoadEnemies(); LoadHazards(); LoadTotems();
        //load total score for game
     if(CurrentSceneName == "Level1")
        {
            score = 0;
            PlayerPrefs.SetInt("Score", 0);
        }
     if(CurrentSceneName != "Level1")
        {
            score = PlayerPrefs.GetInt("Score");
        }

    }

    // Update is called once per frame
    void Update () {

        LoadNextScene();
        
	}

    void LoadTotems()
    {
        foreach(GameObject totempoint in TotemSpawns)
        {
            switch (totempoint.name)
            {
                case "EarthMarker":
                    {
                        Instantiate(EarthTotem, totempoint.transform.position, Quaternion.identity);
                        break;
                    }
                case "WaterMarker":
                    {
                        Instantiate(WaterTotem, totempoint.transform.position, Quaternion.identity);
                        break;
                    }
                case "FireMarker":
                    {
                        Instantiate(FireTotem, totempoint.transform.position, Quaternion.identity);
                        break;
                    }
                case "AirMarker":
                    {
                        Instantiate(AirTotem, totempoint.transform.position, Quaternion.identity);
                        break;
                    }
            }
        }

    }

    void LoadEnemies()
    {
        foreach(GameObject Location in EnemySpawns)
        {
            int i = Random.Range(0, (Enemies.Length ));
            Instantiate(Enemies[i], Location.transform.position, Quaternion.identity);
        }
    }

    void LoadHazards()
    {
        foreach (GameObject Location in HazardSpawns)
        {
            int i = Random.Range(0, (Hazards.Length ));
            Instantiate(Hazards[i], Location.transform.position, Quaternion.identity);
        }
    }



    //UpdateScore if past level 1

     public void LoadNextlevelComplete() { 

                var HealthBonusFactor = (PlayerControl.Life / PlayerControl.MaxLife) + 1;
                var newScore = Mathf.RoundToInt(score * HealthBonusFactor);
                score = newScore;
                var HighScore = PlayerPrefs.GetInt("High Score");
                PlayerPrefs.SetString("Last Level", CurrentSceneName);
                PlayerPrefs.SetInt("Score", score);
            if (score > HighScore)
                {
                    PlayerPrefs.SetInt("High Score", score);
                    
                }
            if (CurrentSceneName != "Level3")
            {
               
                SceneManager.LoadScene("NextLevel");
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        
}
    public void LoadNextScene()
    {
     

        //Game Over at 0 health
        var newHealth = PlayerControl.Life;

        CurrentHealth = newHealth;

        if(CurrentHealth <= 0)
        {
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene("GameOver");
        }

       
    }

    //check if all totems collected
    public bool AllTotemsCollected()
    {
        
        for (int i = 0; i < PickedUp.Length; ++i)
        {
            if(PickedUp[i] == false)
            {
                return false;
            }
        }

        return true;

    }
    //Spawn Health
    public void InstantiateHealthPickup(Vector3 location)
    {

        var RandomHealth = Random.Range(0, 100);
        var ChanceToSpawn = 60;

        if(RandomHealth < ChanceToSpawn)
        {
            var newLoc = location + new Vector3(0, 0.1f, 0);
         Instantiate(healthPickUp, newLoc, Quaternion.identity);
        }

    } 


    //Rubble
    public void InstantiateRubble(Vector3 Objectposition)
    {
        Instantiate(RubblePrefab, Objectposition, Quaternion.identity);
        score += 50;
    }



    public void InstantiateGrazeSpark(Vector3 Location)
    {
        Instantiate(GrazeSpark, Location, Quaternion.identity);
        score -= 1;
    }
}
