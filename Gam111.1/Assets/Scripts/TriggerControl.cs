using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TriggerControl : MonoBehaviour {

    public Collider PlayerCollider;
    Rigidbody RB;
    PlayerController PlayerScript;
    GameController GameScript;
    GameSoundManager Sounds;

    public PhysicMaterial Sticky;
    public PhysicMaterial Bouncey;
    public PhysicMaterial Slippery;
    public float Timer = 5f;
    public float TimeCount = 0;
    public float TimeDisplay;

    public int TotemCount = 0;

    public string Currentmaterial = "Normal";

	// Use this for initialization
	void Awake () {
        PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Collider>();
        RB = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();
        GameScript = FindObjectOfType<GameController>();
        Sounds = FindObjectOfType<GameSoundManager>();
    }
	
	// Update is called once per frame
	void Update () {



        TimeDisplay = TimeCount / Timer;
        TimeCount -= Time.deltaTime;

        if(TimeCount <= 0)
        {
            PlayerCollider.material = null;
            Currentmaterial = "Normal";
        }
      
	}



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            PlayerScript.inAir = false;
            Sounds.playlandingSFX();
        }
    }

   

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            PlayerScript.inAir = true;
        }
    }









    private void OnTriggerEnter(Collider other)
    {
       
           

           if(other.tag == "PhysicsTriggerSticky")
            {
                PlayerCollider.material = Sticky;
                TimeCount = Timer;
                Currentmaterial = "Sticky!!";
            Sounds.PlayEffectSFX();

            }

            if (other.tag == "PhysicsTriggerBouncey")
            {
                PlayerCollider.material = Bouncey;
                TimeCount = Timer;
            Currentmaterial = "Bouncey!!";
            Sounds.PlayEffectSFX();
        }

            if (other.tag == "PhysicsTriggerSlippery")
            {
                
                PlayerCollider.material = Slippery;
                TimeCount = Timer;
            Currentmaterial = "Slippery!!";
            Sounds.PlayEffectSFX();
        }


        
        if(other.tag == "HealthTrigger")
        {
            Destroy(other.gameObject);
            PlayerScript.AddHealth();
            Sounds.PlayHealthgain();
        }

        if (other.tag == "TotemPickUp")
        {
            ++TotemCount;
            GameScript.score += 200;
            var TotemName = other.name;
            switch (TotemName)
            {
                case "AirPickUp":
                    {
                        
                        GameScript.PickedUp[0] = true;
                        Debug.Log("air");
                        break;
                    }
                case "WaterPickUp":
                    {
                        GameScript.PickedUp[1] = true;
                        Debug.Log("water");
                        break;
                    }
                case "FirePickUp":
                    {
                        GameScript.PickedUp[2] = true;
                        Debug.Log("fire");
                        break;
                    }
                case "EarthPickUp":
                    {
                        GameScript.PickedUp[3] = true;
                        Debug.Log("Earth");
                        break;
                    }
            }
            Sounds.PlayTotemSFX();
            Destroy(other);
        }


    }
}
