using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHorse : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.Rotate(transform.up, 90.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
