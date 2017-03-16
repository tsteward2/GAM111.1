using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : MonoBehaviour
{

    float MinImpulse = 2.6f;

   
    float Health;

    GameController Game;
    PlayerController player;
     GameSoundManager Sounds;
    private void Awake()
    {
        Health = MinImpulse;
        Game = FindObjectOfType<GameController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();
        Sounds = FindObjectOfType<GameSoundManager>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(Health <= 0.0f)
        {
            Game.InstantiateRubble(transform.position);
            Game.InstantiateHealthPickup(transform.position);
            Sounds.PlayDestroySFX();
            Destroy(gameObject);
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Bang");
         var force = collision.impulse.magnitude;
            Sounds.PlayEnemySFX();

            player.takeDamage(force);
           Debug.Log("Collision  " + force);
            if (force >= MinImpulse)
            {
               
                Game.InstantiateRubble(transform.position);
                Game.InstantiateHealthPickup(transform.position);
                Sounds.PlayDestroySFX();
                Destroy(gameObject);
            }

            if(force < MinImpulse)
            {
                Health -= collision.impulse.magnitude;
            }
        }
    }
}