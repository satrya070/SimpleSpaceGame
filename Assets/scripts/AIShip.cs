using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShip : MonoBehaviour
{
    public GameObject player;
    public Transform playerTrans;

    Rigidbody rb;
    public float MinRangeDist;
    float maxSpeed = 100f;
    float rotationSpeed = 3f;

    float BrakeMark = 50f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTrans = player.transform.Find("ShipTransform");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame 
    void Update()
    {
    }

    void FixedUpdate()
    {
        if(player)
        {
            Vector3 PlayerDirection = (playerTrans.position - transform.position).normalized;

            // look at player logic
            if(player)
            {
                Quaternion targetRotation = Quaternion.LookRotation(PlayerDirection);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            }

            // if in_range false 
            float PlayerDist = GetPlayerDist();
            if(PlayerDist >= MinRangeDist)
            {

                Debug.Log(rb.velocity.magnitude);
                if(PlayerDist >= (MinRangeDist + BrakeMark))
                {
                    //Debug.Log(PlayerDist);
                    rb.AddForce(PlayerDirection * 1, ForceMode.VelocityChange);
                }
                else
                {
                    if(rb.velocity.magnitude > 10f)
                    {
                        float CounterForce = (rb.velocity.magnitude / 100f) * 4.5f;
                        rb.AddForce(PlayerDirection * -CounterForce, ForceMode.VelocityChange);
                    }
                }
            }

            ClampSpeed();
        }
    }

    // TODO strafe/move when shot


    void ClampSpeed()
    {
        if(rb.velocity.magnitude > 100f)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public float GetPlayerDist()
    {   
        return Vector3.Distance(transform.position, playerTrans.position);
    }
}
