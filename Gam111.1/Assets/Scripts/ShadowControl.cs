using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowControl : MonoBehaviour {

    Rigidbody Player;
    Collider PlayerCol;
    Vector3 PlayerPosition;
    Projector ShadowProjector;
    GameObject PlayerSpawn;
    float height = 10.0f;
    float ShadowFactor;
   
	// Use this for initialization
	void Awake () {

        Player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
        PlayerCol = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Collider>();

        ShadowProjector = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Projector>();

        PlayerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn");

      transform.position = PlayerSpawn.transform.position;

       
	
  
	}

    // Update is called once per frame
    void Update()
    { 
        PlayerPosition = Player.transform.position;
        var NewPos = PlayerPosition + new Vector3(0, height, 0);
        gameObject.transform.position = NewPos;
        

        




    }

    public void ShadowChangeHeight(float Height)
    {
        var deadzone = 1.25f;
        if (Height > deadzone)
        {
            ShadowProjector.orthographicSize = (Height * 2) + 1.0f;
           // Debug.Log("Height:  " + Height);
        }
        else
        {
            ShadowProjector.orthographicSize = 1.0f;
        }
    }




   
	}
    

