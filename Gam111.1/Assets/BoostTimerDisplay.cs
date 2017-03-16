using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostTimerDisplay : MonoBehaviour {

    Image BoostTimerImage;
    PlayerController BoostTime;


    float DisplayAmount;
   

    // Use this for initialization
    void Awake () {
        BoostTime = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();
        BoostTimerImage = gameObject.GetComponent<Image>();
       
		
	}
	
	// Update is called once per frame
	void Update () {
        DisplayAmount = BoostTime.BoostPercentage;

        BoostTimerImage.fillAmount = DisplayAmount;

        if(DisplayAmount < 1)
        {
            BoostTimerImage.color = Color.red;
        }
        else
        {
            BoostTimerImage.color = Color.blue;
        }
	}
}
