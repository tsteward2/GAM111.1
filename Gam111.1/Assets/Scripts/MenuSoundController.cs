using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundController : MonoBehaviour {

    public AudioClip MainTheme;
    AudioSource Audio;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start () {

        
        Audio.clip = MainTheme;
        Audio.Play();

	}
	
	// Update is called once per frame
	void Update () {

        if(Audio.isPlaying == false)
        {
            Audio.Play();
        }
		
	}
}
