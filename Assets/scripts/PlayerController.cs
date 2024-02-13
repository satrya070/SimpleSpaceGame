using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    /*public float thrustSpeed = 10f;
//    public float rotationSpeed = 5f;

//    private Rigidbody rb;
//    private bool canThrust = true;*/

//    // second implementation vars
//    public float normalSpeed = 25f;
//    public float accelerationSpeed = 45f;
//    public float rotationSpeed = 2.0f;
//    public float cameraSmooth = 4f;
//    float mouseXSmooth = 0f;
//    float mouseYSmooth = 0f;
//    float rotationZ = 0f;

//    private Rigidbody rb;
//    float speed;
//    public Camera mainCamera;
//    public Transform cameraPosition;
//    Quaternion lookRotation;
//    public Transform spaceshipRoot;
//    Vector3 defaultShipRotation;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        lookRotation = transform.rotation;
//        defaultShipRotation = spaceshipRoot.localEulerAngles;
//        rotationZ = defaultShipRotation.z;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        /*float horizontalInput = Input.GetAxis("Horizontal");
//        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

//        // thrust
//        if (canThrust && Input.GetKey(KeyCode.Space))
//        {
//            rb.AddForce(transform.forward * thrustSpeed, ForceMode.Impulse);
//            canThrust = false;
//            Invoke("ResetThrust", 3f);
//        }*/
//    }

//    void FixedUpdate()
//    {
//        if(Input.GetMouseButton(1))
//        {
//            speed = Mathf.Lerp(speed, accelerationSpeed, Time.deltaTime * 3);
//        }
//        else
//        {
//            speed = Mathf.Lerp(speed, normalSpeed, Time.deltaTime * 10);
//        }

//        //set moveDirection to the vertical axis * speed
//        Vector3 moveDirection = new Vector3(0, 0, speed);
//        moveDirection = transform.TransformDirection(moveDirection);
//        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);

//        //followCam
//        mainCamera.transform.position = Vector3.Lerp(
//            mainCamera.transform.position,
//            cameraPosition.transform.position,
//            Time.deltaTime * cameraSmooth
//        );

//        //rotation
//        float rotationTemp = 0f;
//        if (Input.GetKey(KeyCode.A))
//        {
//            rotationTemp = 1;
//        }
//        else if (Input.GetKey(KeyCode.D))
//        {
//            rotationTemp = -1;
//        }

//        Debug.Log(Input.GetAxis("Mouse X"));

//        mouseXSmooth = Mathf.Lerp(
//            mouseXSmooth,
//            Input.GetAxis("Mouse X") * rotationSpeed,
//            Time.deltaTime * cameraSmooth
//        );
//        mouseYSmooth = Mathf.Lerp(
//            mouseYSmooth,
//            Input.GetAxis("Mouse Y") * rotationSpeed,
//            Time.deltaTime * cameraSmooth
//        );
//        Quaternion localRotation = Quaternion.Euler(-mouseYSmooth, mouseXSmooth, rotationTemp * rotationSpeed);
//        lookRotation = lookRotation * localRotation;
//        rotationZ -= mouseXSmooth;
//        rotationZ = Mathf.Clamp(rotationTemp, -45, 45);
//        spaceshipRoot.transform.localEulerAngles = new Vector3(
//            defaultShipRotation.x, defaultShipRotation.y, rotationZ
//        );
//        rotationZ = Mathf.Lerp(rotationZ, defaultShipRotation.z, Time.deltaTime * cameraSmooth);


//    }
//}
