using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : MonoBehaviour
{
    float MinImpulse = 8.0f;
    
    float Health;
    GameController Game;
    PlayerController player;
    GameSoundManager Sounds;
    private void Awake()
    {
        transform.eulerAngles = new Vector3(-90, 0, 0);
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

        if (Health <= 0.0f)
        {
            Game.InstantiateRubble(transform.position);
            Game.InstantiateHealthPickup(transform.position);
            Sounds.PlayDestroySFX();
            Destroy(gameObject);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            
            var newforce = collision.impulse.magnitude;
            player.takeDamage(newforce);
            Health -= newforce;
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Bang");
            var force = collision.impulse.magnitude;
            Debug.Log("Collision  " + force);
            player.takeDamage(force);
             Sounds.PlayEnemySFX();
            if (force >= MinImpulse)
            {

                Game.InstantiateRubble(transform.position);
                Game.InstantiateHealthPickup(transform.position);
                Sounds.PlayDestroySFX();
                Destroy(gameObject);
            }

            if (force < MinImpulse)
            {
                Health -= collision.impulse.magnitude;
            }
        }
    }
}
