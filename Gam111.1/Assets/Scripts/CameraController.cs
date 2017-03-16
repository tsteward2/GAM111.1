using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Use this for initialization
    Rigidbody PlayerRB;
    PlayerController playerScript;


    float MinMag;
    float MaxMag = 4.0f;
    Vector3 playerPos;
    public GameObject TargetLook;
    float PlayerMagnitude;
    float CameraSpeed = 0.5f;


    public Vector3 TargetPos;
    float Yoffset = 1.5f;
    float Zoffset = 2.0f;

    void Awake()
    {

        PlayerRB = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();


    }
    private void Update()
    {
     if(PlayerRB.velocity.z < 0)
        {
            Yoffset = 2.0f;
            Zoffset = 4.0f;
        }
     else
        {
            Yoffset = 0.75f;
            Zoffset = 2.0f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

      
        playerPos = PlayerRB.transform.position;
        PlayerMagnitude = (playerPos - transform.position).magnitude;

        MinMag = (playerPos - TargetPos).magnitude;

        Vector3 LookPos = TargetLook.transform.position;
        transform.LookAt(LookPos);

        //Keep Camera Bheind Player

        var BehindPlayer = (-PlayerRB.velocity).normalized;
       TargetPos = new Vector3(playerPos.x, playerPos.y + Yoffset, playerPos.z - Zoffset);



        if (playerScript.BoostIs == true)
        {
            transform.position = TargetPos;
        }
        else
        {
            if (PlayerMagnitude < MinMag)
            {
                transform.position = TargetPos;
            }
            else
            {
                var Velocity = Vector3.zero;
                transform.position = Vector3.SmoothDamp(transform.position, TargetPos, ref Velocity, CameraSpeed * Time.fixedDeltaTime);

                //  Debug.Log(PlayerMagnitude);

            }
        }

    }

   

}

  
