using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRing : MonoBehaviour
{
    public float rotationSpeed = 30f;
    [SerializeField] bool NonCenteredRotated;
    Vector3 rotationPoint;

    void Start()
    {
        if(NonCenteredRotated)
        {
            rotationPoint = transform.position + new Vector3(30f, 0f, 0f);
        }
        else
        {
            rotationPoint = GetComponent<Collider>().bounds.center;
        }
    }

    // Update is called once per frame
    void Update()
    {
        applyRingRotation();
    }

    void applyRingRotation()
    {
        transform.RotateAround(rotationPoint, transform.forward, rotationSpeed * Time.deltaTime);
    }
}
