using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TotemDisplayCounter : MonoBehaviour {


    Text DisplayTotemCount;
    TriggerControl TotemCounter;



	// Use this for initialization
	void Start () {

        TotemCounter = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<TriggerControl>();
        DisplayTotemCount = gameObject.GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {

        var numberCollected = TotemCounter.TotemCount;

        DisplayTotemCount.text = (numberCollected + "   /   4");
		
	}
}
