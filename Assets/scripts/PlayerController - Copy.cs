/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrustSpeed = 10f;
    public float rotationSpeed = 5f;

    private Rigidbody rb;
    private bool canThrust = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //lookRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        // thrust
        if (canThrust && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * thrustSpeed, ForceMode.Impulse);
            canThrust = false;
            Invoke("ResetThrust", 3f);
        }
    }

    void ResetThrust()
    {
        canThrust=true;
    }
}
*/