using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {



    //Health PickUp


    Rigidbody playerRB;
    TrailDustController Dust;
    Collider PlayerCollider;
    ShadowControl Shadow;
    CameraController CamScript;
    GameObject playertoy;

    //Player Variables
    public float Life;
    public float MaxLife = 200;
    public float startLifes = 100;

    //Jump Variables
   public int jumpCount;
    int Jump = 1;
    int DoubleJump = 2;
    int jumpMax = 1;
   public  bool inAir = false;
    public bool doubleJumpEnabled = false;


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
    public float BoostCoolDown = 5f;
    public float BoostCoolTime = 0f;
    public float BoostPercentage;

    //Player Shadow Variables
    float newHeight;

    //playersize

    public int TotemsCollected = 0;



    private void Awake()
    {
        Dust = gameObject.GetComponentInChildren<TrailDustController>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
        PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Collider>();
        CamScript = Camera.main.GetComponent<CameraController>();
        playertoy = GameObject.Find("PlayerToy");
        Shadow = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ShadowControl>();
        BoostCoolDown = BoostDuration + 5.0f;
    }

    // Use this for initialization
    

	// Use this for initialization
	void Start () {

        Life = startLifes;
        playerRB.maxAngularVelocity = 12.0f;

    }




    private void Update()
    {
        BoostTimerUpdate(BoostCoolTime);
        Dust.PlayParticleDust(inAir);
        
        var PlayerScale = playertoy.transform.localScale.x;
        var newscale = PlayerScale + (TotemsCollected / 4);

        playertoy.transform.localScale = new Vector3(newscale, newscale, newscale);
        



        Life = Mathf.Clamp(Life, 0, MaxLife);
        DoubleJumpControl();
     

       
        if(playerRB.transform.position.y <= 10.0f)
        {
            Life = 0;
        }

       if(inAir == false)
        {
            JumpReset();
        }


        //FOVPUSH
        CurrentFov = Camera.main.fieldOfView;
        BoostTime -= Time.deltaTime;
        BoostCoolTime -= Time.deltaTime;

       // Debug.Log("Velociyy " + playerRB.velocity.magnitude);
       // Debug.Log("Torque" + playerRB.angularVelocity);

       
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

            if (jumpCount < jumpMax)
            {


                inAir = true;
                var newforce = (jumpForce * (playerRB.mass * (-Physics.gravity.y * -Physics.gravity.y)));
                playerRB.AddForce(transform.up * newforce);
                ++jumpCount;
            }
        }
    }  


    void BoostTimerUpdate(float BoostTimeCoolDown)
    {
        if (BoostTimeCoolDown >= 0.0f)
        {
            BoostPercentage = 1 - (BoostCoolTime / BoostCoolDown);
        }
        if(BoostTimeCoolDown < 0.0f)
        {
            BoostPercentage = 1;
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
        switch (inAir)
        {
            case false:
                {
                    

                      playerRB.AddTorque(VDir * ForwardTorqueFactor * V);
                      playerRB.AddTorque(HDir * -SideTorqueFactor * H);
                    break;
                }
            case true:
                {

                    playerRB.AddForce(H * transform.right * 5);
                    playerRB.AddForce(V * transform.forward * 8);
                    break;

                }
    }
    }

    void DoubleJumpControl()
    {
        switch (doubleJumpEnabled)
        {
            case true:
                
                    jumpMax = DoubleJump;
                break;
                        
            case false:
                    jumpMax = Jump;
                    break;
                
        }
    }

    //weight torque factoring

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
         BoostIs = false;
        yield return true;
       
        }
       
        
    }

   

    public void AddHealth()
    {
        Life += 25.0f;
    }

    public void takeDamage(float Damage)
    {
        Life -= Damage;
    }

    public void JumpReset()
    {
        jumpCount = 0;
    }
}
