using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    Rigidbody playerRB;
    //Movement Variables
    float H;
    float V;
    public float ForwardTorqueFactor;
    public float SideTorqueFactor;

    //Player Shadow Variables
    public GameObject playerShadow;
    ShadowControl ShadowController;
    Vector3 HitLocation;
    bool isShadow = false;
    GameObject shadow;

    private void Awake()
    {
       playerRB = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
       
    }

    // Use this for initialization
    

	// Use this for initialization
	void Start () {
        ShadowController = playerShadow.GetComponent<ShadowControl>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        TorqueFactor();
        
        //place shadow
        RaycastHit Hit;

        if (Physics.Raycast((transform.localPosition - new Vector3(0f,0.5f,0f)), -transform.up, out Hit, 20.0f))
        {
            if (isShadow == false)
            {
             shadow = Instantiate(playerShadow, HitLocation, Quaternion.Euler(90,0,0));
                isShadow = true;
            }
            else
            {   // instanstiate 
                HitLocation = Hit.transform.position;

                var DisFromground = (HitLocation - transform.position).magnitude;
                shadow.transform.position = HitLocation;
                Debug.Log(DisFromground);

            }
        }
    }

  

    public void Movement()
    {
//Get input

       
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        // apply Input
        playerRB.AddTorque(transform.right * ForwardTorqueFactor * V);
        playerRB.AddTorque(transform.forward * -SideTorqueFactor * H);

    }

    public void TorqueFactor()
    {
        ForwardTorqueFactor = (playerRB.mass + Mathf.Abs(Physics.gravity.y));
        SideTorqueFactor = (playerRB.mass + Mathf.Abs(Physics.gravity.y));
    }
    
}
