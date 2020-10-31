using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //This is referance to the Rigidbody component
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sideForce = 500f;

    // we are using fixed update as we are messing wiht physics
    void FixedUpdate()
    {
        //add a froward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);       // as update take place per frame it may give very large force for higer
                                                                // frame rate and vice versa so we multipy it with Time.deltaTime 
                                                                //so that we can solve this proble and have a smooth gameplay
        if(Input.GetKey("d"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
