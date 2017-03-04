using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowControl : MonoBehaviour {

    Rigidbody Player;
    Vector3 PlayerPosition;
    Projector ShadowProjector;
    //float height = 5.0f;
    float ShadowFactor;
	// Use this for initialization
	void Start () {

        Player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
        ShadowProjector = GameObject.Find("ProjectorScene").GetComponent<Projector>();
		
	}
	
	// Update is called once per frame
	void Update () {

        PlayerPosition = Player.transform.position;
        
        Debug.Log(PlayerPosition);




        RaycastHit hit;

        Physics.Raycast(PlayerPosition, -transform.up, out hit, 20.0f);

        ShadowFactor = (hit.distance + 1.0f) * (hit.distance +1.5f );
        

     //   ShadowProjector.orthographicSize

		
	}

    public void ShadowMove(Vector3 Position)
    {

      
    }
}
