using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRing : MonoBehaviour
{
    public float rotationSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(GetComponent<Collider>().bounds.center, transform.forward, rotationSpeed * Time.deltaTime);
    }
}
