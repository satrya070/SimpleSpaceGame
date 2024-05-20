using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGun : MonoBehaviour
{
    AIShip shipOwner;

    Rigidbody rb;
    RaycastHit hit;
    private float ShootRate = 3;
    private float m_shootRateTimeStamp;
    private float LaserRange = 1000;
    public GameObject m_shotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        shipOwner = transform.root.GetComponent<AIShip>();
    }

    // Update is called once per frame 
    void Update()
    {
        if(shipOwner.player)
        {
            ShootPlayer();
        }
    }

    void ShootPlayer()
    {   
        if(shipOwner.GetPlayerDist() < (shipOwner.MinRangeDist + 50f))
        {
            if(Time.time > m_shootRateTimeStamp)
            {
                //Debug.Log($"Shot!: {Time.time}");
                ShootRay();
                m_shootRateTimeStamp = Time.time + ShootRate;
            }
        }
    }

    void ShootRay()
    {
        Vector3 PlayerDirection = (shipOwner.playerTrans.position - transform.position).normalized;
        //debug ray
        //Ray ray = new Ray(transform.position, PlayerDirection * LaserRange);
        //Debug.DrawRay(transform.position, ray.direction * LaserRange, Color.green, 10f);

        GameObject laser = GameObject.Instantiate(
            m_shotPrefab, transform.position, Quaternion.LookRotation(PlayerDirection)
        ) as GameObject;
        laser.GetComponent<ShotBehavior>().setTargetComponents(
            shipOwner.gameObject.tag,
            transform.position + (PlayerDirection * LaserRange),
            shipOwner.GetComponent<Damage>(),
            shipOwner.gameObject.tag
        );
    }
}
