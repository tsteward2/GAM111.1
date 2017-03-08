using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowControl : MonoBehaviour {

    Rigidbody Player;
    Vector3 PlayerPosition;
    Projector ShadowProjector;
    Terrain World;
    //float height = 5.0f;
    float ShadowFactor;
    float HeightDifference = 10;
	// Use this for initialization
	void Start () {

        Player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
        World = GameObject.Find("Terrain").GetComponent<Terrain>();
        ShadowProjector = GameObject.Find("ProjectorScene").GetComponent<Projector>();
		var PlayerPos = Player.transform.position;
        var newPos = new Vector3(PlayerPos.x, PlayerPos.y + HeightDifference, PlayerPos.z);
        transform.position = newPos;
	}

    // Update is called once per frame
    void Update()
    {


        

        
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
    

