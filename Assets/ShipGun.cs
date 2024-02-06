using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGun : MonoBehaviour
{
    public float shootRate;
    private float m_shootRateTimeStamp;

    public GameObject m_shotPrefab;
    RaycastHit hit;
    float range = 1000f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Debug.Log($"Clicked! {Time.time}");
            if(Time.time > m_shootRateTimeStamp)
            {
                Debug.Log("Shot!");
                shootRay();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }
    }

    void shootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, range))
        {
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);
        }
        else
        {
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(ray.direction * range);
            GameObject.Destroy(laser, 2f);
        }
    }
}
