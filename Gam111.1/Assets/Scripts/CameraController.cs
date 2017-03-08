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
    Vector3 TargetPosLook;
    float PlayerMagnitude;
    float CameraSpeed = 2f;

    public Vector3 TargetPos;
    float Yoffset = 0.75f;
    float Zoffset = 2.0f;

    void Start()
    {
        
        PlayerRB = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Debug.Log(playerScript.BoostIs);
        playerPos = PlayerRB.transform.position;
        PlayerMagnitude = (playerPos - transform.position).magnitude;
        TargetPos = new Vector3(playerPos.x, playerPos.y + Yoffset, playerPos.z - Zoffset);
        MinMag = (playerPos - TargetPos).magnitude;
        transform.LookAt(playerPos);


        if(playerScript.BoostIs == true)
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
