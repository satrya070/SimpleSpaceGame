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
        ShootPlayer();
    }

    void ShootPlayer()
    {   
        if(shipOwner.GetPlayerDist() < (shipOwner.InRangeDist + 20f))
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
        Ray ray = new Ray(transform.position, PlayerDirection * LaserRange);
        Debug.DrawRay(transform.position, ray.direction * LaserRange, Color.green, 10f);

        GameObject laser = GameObject.Instantiate(
            m_shotPrefab, transform.position, Quaternion.LookRotation(PlayerDirection)
        ) as GameObject;
        laser.GetComponent<ShotBehavior>().setTargetComponents(
            //transform.position + (transform.forward * range),
            transform.position + (PlayerDirection * LaserRange),
            shipOwner.GetComponent<Damage>()
        );

        // raycast from AI always hits
        // if (Physics.Raycast(ray, out hit, LaserRange))
        // {
        //     Quaternion LaserRotation = Quaternion.Euler(PlayerDirection);// * LaserRange);
        //     GameObject laser = GameObject.Instantiate(
        //         m_shotPrefab, transform.position, Quaternion.LookRotation(PlayerDirection)
        //     ) as GameObject;
        //     //Debug.Log($"{hit.point} - {hit.point * 2f}");
        //     laser.GetComponent<ShotBehavior>().setTarget(hit.point * 1f);
        //     laser.GetComponent<ShotBehavior>().setHitComponents(hit.transform.gameObject, laser, shipOwner.transform.gameObject);
        // }

    }
}
