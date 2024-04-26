using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    Rigidbody rb;

    float verticalMove;
    float horizontalMove;
    float mouseInputX;
    float mouseInputY;
    float rollInput;

    //speed multipliers
    [SerializeField]
    float speedMult = 1;
    [SerializeField]
    float speedMultAngle = 0.5f;
    [SerializeField]
    float speedRollMultAngle = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;
        //Invoke("EnableMouseInput", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");
        rollInput = Input.GetAxis("Roll");

        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");

        //Debug.Log($"X: {mouseInputX}, Y: {mouseInputY}");

        // temp debug test for damage
        //TestDamage();
    }

    void FixedUpdate()
    {
        rb.AddForce(rb.transform.TransformDirection(Vector3.forward) * verticalMove * speedMult, ForceMode.VelocityChange);
        rb.AddForce(rb.transform.TransformDirection(Vector3.right) * horizontalMove * speedMult, ForceMode.VelocityChange);

        rb.AddTorque(rb.transform.right * speedMultAngle * mouseInputY * -1, ForceMode.VelocityChange);
        rb.AddTorque(rb.transform.up * speedMultAngle * mouseInputX, ForceMode.VelocityChange);

        rb.AddTorque(rb.transform.forward * speedRollMultAngle * rollInput, ForceMode.VelocityChange);
    }

    void DisableMouseInput()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void EnableMouseInput()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    void TestDamage()
    {
        GameObject Player = GameObject.Find("PlayerSpaceShip");
        if (Input.GetKeyDown(KeyCode.L))
        {
            Damage TDamage = this.AddComponent<Damage>();
            TDamage.DamagePoints = 20;
            CombatHandler.ApplyDamage(Player, TDamage);
        }
    }

}
