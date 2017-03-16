using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : MonoBehaviour {


    float MinImpulse = 1.0f;
   
    GameController Game;
    PlayerController player;
    GameSoundManager Sounds;

    private void Awake()
    {
        Game = FindObjectOfType<GameController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();
        Sounds = FindObjectOfType<GameSoundManager>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}




    private void OnCollisionEnter(Collision collision)
    {
       

      
        if (collision.gameObject.tag == "Player")
         { Debug.Log("Bang");
        var force = collision.impulse.magnitude;
         player.takeDamage(force);
            Sounds.PlayEnemySFX();

            if (force > MinImpulse)
            { 
                Game.InstantiateRubble(transform.position);
                Game.InstantiateHealthPickup(transform.position);
                Sounds.PlayDestroySFX();
                Destroy(gameObject);
            }
        }
    }
}
