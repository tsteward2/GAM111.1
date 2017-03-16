using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConditionTextController : MonoBehaviour {

    GameObject Player;
   TriggerControl PlayerMaterial;

    Text ConditionDisplay;

    private void Awake()
    {
        PlayerMaterial = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<TriggerControl>();
     
        ConditionDisplay = gameObject.GetComponent<Text>();

    }

   
   

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

        var Material = PlayerMaterial.Currentmaterial;

        
        
            ConditionDisplay.text = Material;
        
      
		
	}
}
