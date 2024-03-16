using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashingMeteor : MonoBehaviour
{
    public Transform crashPoint;
    public float crashSpeed = 100f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = (crashPoint.position - transform.position).normalized;
        if(crashPoint)
        {
            Debug.Log("Moving rock!");
            rb.AddForce(moveDirection * crashSpeed);
        }
    }
}
