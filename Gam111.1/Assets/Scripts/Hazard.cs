using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    PlayerController player;
    GameController gameScript;
    GameSoundManager Sounds;

    float ImpactForce;
    float DamageMultiplier = 5;
    float minThreshold = 1.75f;
    float damage;

	// Use this for initialization
	void Awake() {

        Sounds = FindObjectOfType<GameSoundManager>();
        gameScript = FindObjectOfType<GameController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ContactPoint[] ContactPoints = collision.contacts;
            Sounds.PlayHazardSFX();
            ImpactForce = collision.impulse.magnitude;
            if (ImpactForce > minThreshold)
            {
                damage = ImpactForce * DamageMultiplier;

            }
        }
    }
    

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            ContactPoint[] ContactPoints = collision.contacts;
            var newforce = collision.impulse.magnitude * DamageMultiplier;
            player.takeDamage(newforce);

            foreach (ContactPoint contact in ContactPoints)
            {
                Vector3 location = contact.point;

                gameScript.InstantiateGrazeSpark(location);
            }
        }
    }
}
