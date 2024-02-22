using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShip : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    public float InRangeDist = 70f;
    float maxSpeed = 100f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame 
    void Update()
    {
        if(player)
        {
            transform.LookAt(player.transform);
        }
    }

    void FixedUpdate()
    {
        // if in_range false 
        float PlayerDist = GetPlayerDist();
        Debug.Log(rb.velocity.magnitude);
        if(PlayerDist >= InRangeDist)
        {
            if(PlayerDist >= (InRangeDist + 10))
            {
                Vector3 PlayerDirection = (player.transform.position - transform.position).normalized;
                rb.AddForce(PlayerDirection * 1, ForceMode.VelocityChange);
            }
            else
            {
                //braking range
                Debug.Log("brakeing!");
                if(rb.velocity.magnitude > 3)
                {
                    rb.velocity = Vector3.Lerp(rb.velocity, -rb.velocity, Time.fixedDeltaTime / .2f);
                }
                else
                {
                    Debug.Log("below 3");
                    rb.velocity = Vector3.zero;
                }
                //Debug.Log(rb.velocity.magnitude);
            }
        }

        ClampSpeed();
    }

    // strafe
    // if shot at strafe 

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
        return Vector3.Distance(transform.position, player.transform.position);
    }
}
