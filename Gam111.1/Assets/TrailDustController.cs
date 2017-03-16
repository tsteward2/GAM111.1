using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDustController : MonoBehaviour {

    ParticleSystem TrailDust;
    Rigidbody PlayerToy;
    private void Awake()
    {
        PlayerToy = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
        TrailDust = gameObject.GetComponent<ParticleSystem>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var newPos = PlayerToy.transform.position - new Vector3(0, 0.5f, 0);

        gameObject.transform.position = newPos;
		
	}

    public void PlayParticleDust(bool offGround)
    {
        if(offGround == false)
        {
            if (TrailDust.isEmitting == false)
            {
                TrailDust.Play();
            }
        }
        if(offGround == true)
        {
            TrailDust.Stop();
        }
    }
}
