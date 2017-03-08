using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour {

    Rigidbody Player;
    Renderer PlayerMesh;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
    
        PlayerMesh = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Renderer>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        

        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 0.5f, Player.transform.position.z);

        
		
	}
}
