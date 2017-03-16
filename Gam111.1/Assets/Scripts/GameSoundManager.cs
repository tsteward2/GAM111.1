using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour {

   public AudioClip[] HazardSFX;
    public AudioClip[] EnemyHitSFX;
    public AudioClip TotemSFX;
    public AudioClip DestroyObjectSFX;
    public AudioClip rollingSFX;
    public AudioClip HealthGainSFX;
    public AudioClip[] EffectSFX;
    public AudioClip Landing;
    AudioSource Rolling;

    AudioSource Audio;

	// Use this for initialization
	void Start () {
        Audio = GetComponent<AudioSource>();
		  Rolling = new AudioSource();
	}
	
	// Update is called once per frame
	void Update () {
      

        
		
	}

   

    public void playlandingSFX()
    {
        Audio.clip = Landing;
        Audio.Play();
    }

    public void PlayEffectSFX()
    {
      var i = Random.Range(0, EffectSFX.Length );

        Audio.clip = EffectSFX[i];
        Audio.Play();
    }

    public void PlayHazardSFX()
    {
        var i = Random.Range(0, HazardSFX.Length);
        Audio.clip = HazardSFX[i];
        Audio.Play();
    }

    public void PlayEnemySFX()
    {
        var i = Random.Range(0, EnemyHitSFX.Length);
        Audio.clip = EnemyHitSFX[i];
        Audio.Play();
    }

    public void PlayDestroySFX()
    {
        Audio.clip = DestroyObjectSFX;
        Audio.Play();
    }

    public void PlayTotemSFX()
    {
        Audio.clip = TotemSFX;
        Audio.Play();
    }

    public void PlayHealthgain()
    {
        var Health = new AudioSource();
    
        Health.clip = HealthGainSFX;
       Health.Play();
    }


}
