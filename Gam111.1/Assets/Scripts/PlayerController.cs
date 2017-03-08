using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    Rigidbody playerRB;
    Collider PlayerCollider;
    ShadowControl Shadow;
    CameraController CamScript;

    //Movement Variables
    float H;
    float V;
    public float ForwardTorqueFactor;
    public float SideTorqueFactor;
    public float ToqueMultiplier = 1;
    public float jumpForce = 30;
    float maxVelocity = 6.0f;
    float BoostMaxVelocity = 12.0f;

    // Boost variables
    float BoostDuration = 3.0f;
    float BoostTime;
    float BoostForceMultiplier = 2.0f;
    float MaxFov = 70.0f;
    float MinFov = 55.0f;
    float CurrentFov;
   public bool BoostIs = false;
    float BoostCoolDown;
    float BoostCoolTime = 0;
   
    //Player Shadow Variables
 
    


    private void Awake()
    {
       playerRB = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
        PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Collider>();
        CamScript = Camera.main.GetComponent<CameraController>();

        Shadow = GameObject.FindObjectOfType<ShadowControl>();
        BoostCoolDown = BoostDuration + 5.0f;
    }

    // Use this for initialization
    

	// Use this for initialization
	void Start () {

    }

    private void Update()
    {

        CurrentFov = Camera.main.fieldOfView;
        BoostTime -= Time.deltaTime;
        BoostCoolTime -= Time.deltaTime;

       // Debug.Log("Velociyy " + playerRB.velocity);
       // Debug.Log("Torque" + playerRB.angularVelocity);

        //Check Height from ground
        RaycastHit Hit;

        if(Physics.Raycast(playerRB.transform.position, -transform.up, out Hit, 20.0f))
        {
            var newHeight = (Hit.distance - PlayerCollider.bounds.extents.y) + 1;
            Shadow.ShadowChangeHeight(newHeight);

        }
        // Fov Push on boost
        if (Input.GetButtonDown("Boost"))
        {
            if (BoostCoolTime <= 0.0f)
            {
                
                BoostTime = BoostDuration;
                StartCoroutine(Boost());
                BoostCoolTime = BoostCoolDown;
            }
        }
    
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        TorqueFactor();
        ControlSpeed(playerRB.velocity);
       // Debug.Log("VelocityZ:  " + playerRB.velocity.z);


     if (Input.GetButtonDown("Jump") == true)
        {
            var newforce = (jumpForce * (playerRB.mass * (-Physics.gravity.y * -Physics.gravity.y)));
            playerRB.AddForce(transform.up * newforce );
        }


            
    }
    void ControlSpeed(Vector3 Velocity)
    {
        var Z = Velocity.z;

        if( BoostIs != true)
        {
            if(Z > maxVelocity)
            playerRB.velocity = new Vector3(Velocity.x, Velocity.y, maxVelocity);
        }
    }

  

    public void Movement()
    {
//Get input

       
        H = Input.GetAxisRaw("Horizontal");
        V = Input.GetAxisRaw("Vertical");
        // apply Input
        var VDir = Camera.main.transform.right;
        var HDir = Camera.main.transform.forward;

        playerRB.AddTorque(VDir * ForwardTorqueFactor * V);
        playerRB.AddTorque(HDir * -SideTorqueFactor * H);

    }

    public void TorqueFactor()
    {
        ForwardTorqueFactor = ToqueMultiplier * (playerRB.mass + Mathf.Abs(Physics.gravity.y));
        SideTorqueFactor =    ToqueMultiplier * (playerRB.mass + Mathf.Abs(Physics.gravity.y));
    }
    
   

    IEnumerator Boost()
    {
        BoostIs = true;
        
        var HalfwayTime = BoostDuration / 2;
        float actualForce = BoostForceMultiplier;
        while(BoostTime > HalfwayTime)
        {
            actualForce = Mathf.Lerp(actualForce, 1, HalfwayTime * Time.deltaTime);

            playerRB.velocity = new Vector3(playerRB.velocity.x,playerRB.velocity.y, BoostMaxVelocity);

            Camera.main.transform.position = CamScript.TargetPos;
            Camera.main.fieldOfView = Mathf.Lerp(CurrentFov, MaxFov, HalfwayTime * Time.deltaTime);

            yield return null;
        }
        while(BoostTime < HalfwayTime)
        {
            Camera.main.fieldOfView = Mathf.Lerp(CurrentFov, MinFov, HalfwayTime * Time.deltaTime);

            yield return null;
        }
        if (BoostTime >= 0.0f)
        {
         Camera.main.fieldOfView = MinFov;

        yield return true;
        BoostIs = false;
        }
       
        
    }
}
