using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGun : MonoBehaviour
{
    GameObject player;
    AIShip ship;

    Rigidbody rb;
    private float ShootRate = 1;
    private float m_shootRateTimeStamp;
    private float LaserRange = 1000;

    // Start is called before the first frame update
    void Start()
    {
        ship = transform.root.GetComponent<AIShip>(); //GetComponentInParent<AIShip>();
    }

    // Update is called once per frame 
    void Update()
    {
        ShootPlayer();
    }

    void ShootPlayer()
    {   
        if(ship.GetPlayerDist() < 7)
        {
            if(Time.time > m_shootRateTimeStamp)
            {
                Debug.Log($"Shot!: {Time.time}");
                ShootRay();
                m_shootRateTimeStamp = Time.time + ShootRate;
            }
        }
    }

    void ShootRay()
    {
        Ray ray = new Ray(transform.position, transform.forward * LaserRange);
        Debug.DrawRay(transform.position, ray.direction * LaserRange, Color.green, 10f);
    }
}
