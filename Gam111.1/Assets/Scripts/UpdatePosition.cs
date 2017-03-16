using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosition : MonoBehaviour {

    Rigidbody PlayerBall;
	// Use this for initialization
	void Awake () {

        PlayerBall = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = PlayerBall.transform.position;
	}
}
