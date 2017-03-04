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
    public float jumpForce = 30;
    //Player Shadow Variables
 
    


    private void Awake()
    {
       playerRB = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
       
    }

    // Use this for initialization
    

	// Use this for initialization
	void Start () {

    }

    private void Update()
    {
      
        if (Input.GetButtonDown("Jump") == true)
        {
            var newforce = (jumpForce * (playerRB.mass * (-Physics.gravity.y * -Physics.gravity.y)));
            playerRB.AddForce(transform.up * newforce );
        }
    
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        TorqueFactor();


            
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
