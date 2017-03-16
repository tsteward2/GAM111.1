using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

    UIController HealthStats;
    Image HealthBar;
    float FillAmount = 1.0f;

	// Use this for initialization
	void Awake () {

       HealthStats = gameObject.GetComponentInParent<UIController>();
        HealthBar = gameObject.GetComponent<Image>();
		
	}
	
	// Update is called once per frame
	void Update () {
        FillAmount = HealthStats.healthDisplay;

        HealthBar.fillAmount = FillAmount;
        
	}
}
