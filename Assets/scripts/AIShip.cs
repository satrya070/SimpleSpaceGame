using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShip : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame 
    void Update()
    {
    }

    void FixedUpdate()
    {
        if(GetPlayerDist() >= 7)
        {
            Vector3 PlayerDirection = (player.transform.position - transform.position).normalized;
            rb.AddForce(PlayerDirection * 1, ForceMode.VelocityChange);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public float GetPlayerDist()
    {   
        return Vector3.Distance(transform.position, player.transform.position);
    }
}
