using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    float rotateSpeed = 25f;

    PlayerController PlayerHealth;

	// Use this for initialization
	void Awake () {

        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.RotateAround(transform.position, transform.up, rotateSpeed * Time.deltaTime);

		
	}
    

}


