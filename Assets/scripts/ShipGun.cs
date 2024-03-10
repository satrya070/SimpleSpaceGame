using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipGun : MonoBehaviour
{
    public float shootRate;
    private float shootrateTimestamp;
    PlayerSpaceship shipOwner;

    public GameObject m_shotPrefab;
    RaycastHit hit;
    float range = 1000f;

    AudioSource audioSourceGun;

    private void Start()
    {
        shipOwner = transform.root.GetComponent<PlayerSpaceship>();
        audioSourceGun = GetComponent<AudioSource>();
        audioSourceGun.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(Time.time > shootrateTimestamp)
            {
                shootRay();
                shootrateTimestamp = Time.time + shootRate;
            }
        }
    }

    void shootRay()
    {
        if (audioSourceGun)
        {
            Debug.Log("play sound!");
            audioSourceGun.Play();
        }
        Ray ray = new Ray(transform.position, transform.forward * range);

        Debug.DrawRay(transform.position, ray.direction * 1000, Color.green, 10f);
        // if (Physics.Raycast(ray, out hit, range))
        // {
        //     GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
        //     laser.GetComponent<ShotBehavior>().setTarget(hit.point);
        //     laser.GetComponent<ShotBehavior>().setHitComponents(hit.transform.gameObject, laser, transform.root.gameObject);
        //     //Debug.Log(transform.root.gameObject.name);
        //     //Debug.Log($"Hit object: {hit.collider}!");
        // }
        // else
        // {
        //     GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
        //     laser.GetComponent<ShotBehavior>().setTarget(transform.position + (transform.forward * range));
        //     GameObject.Destroy(laser, 2f);
        // }

        GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
        laser.GetComponent<ShotBehavior>().setTargetComponents(
            transform.position + (transform.forward * range),
            shipOwner.GetComponent<Damage>()
        );
        //laser.GetComponent<ShotBehavior>().setHitComponents(hit.transform.gameObject, laser, transform.root.gameObject);
    }
}
