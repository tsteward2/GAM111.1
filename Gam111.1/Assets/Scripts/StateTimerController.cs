using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateTimerController : MonoBehaviour {
    UIController UI;
    Image TimerDisplay;
    public float PercentShown;
	// Use this for initialization
	void Start () {

      UI = gameObject.GetComponentInParent<UIController>();
        TimerDisplay = gameObject.GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {
        PercentShown = UI.TimeDisplaymaterialEffect;
        TimerDisplay.fillAmount = Mathf.Clamp(PercentShown, 0, 1);
	}
}
