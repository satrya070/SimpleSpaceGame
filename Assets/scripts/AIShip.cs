using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShip : MonoBehaviour
{
    public GameObject player;
    public Transform playerTrans;

    Rigidbody rb;
    public float InRangeDist = 70f;
    float maxSpeed = 100f;
    float rotationSpeed = 3f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        // get the actual set ship center position.
        playerTrans = player.transform.Find("ShipTransform");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame 
    void Update()
    {
    }

    void FixedUpdate()
    {
        Vector3 PlayerDirection = (playerTrans.position - transform.position).normalized;

        // look at player logic
        if(player)
        {
            Quaternion targetRotation = Quaternion.LookRotation(PlayerDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // if in_range false 
        float PlayerDist = GetPlayerDist();
        //Debug.Log(rb.velocity.magnitude);
        if(PlayerDist >= InRangeDist)
        {
            if(PlayerDist >= (InRangeDist + 10))
            {
                rb.AddForce(PlayerDirection * 1, ForceMode.VelocityChange);
            }
            else
            {
                //braking range
                // Debug.Log("brakeing!");
                if(rb.velocity.magnitude > 3)
                {
                    rb.velocity = Vector3.Lerp(rb.velocity, -rb.velocity, Time.fixedDeltaTime / .2f);
                }
                else
                {
                    //Debug.Log("below 3");
                    // TODO only zero forward/backward velocity(not angular for lookat?)
                    rb.velocity = Vector3.zero;
                }
            }
        }

        ClampSpeed();
    }

    // TODO strafe/move when shot

    // update_range
    // dist < playetDist + 10
        // set in_range false

    void ClampSpeed()
    {
        if(rb.velocity.magnitude > 100f)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public float GetPlayerDist()
    {   
        // if(player)
        // {
        //     return Vector3.Distance(transform.position, player.transform.position);
        // }
        return Vector3.Distance(transform.position, playerTrans.position);
    }
}
