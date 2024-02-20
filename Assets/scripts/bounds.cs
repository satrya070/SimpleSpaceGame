using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounds : MonoBehaviour
{   
    [SerializeField]
    GameObject centerCapsule;

    [SerializeField]
    PlayerSpaceship player;

    private bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("going out!");

        // isRotating = true;
        // Transform otherTrans = other.gameObject.transform.root;

        // Vector3 targetAngles = otherTrans.eulerAngles + 180f * Vector3.right;
        // otherTrans.eulerAngles = targetAngles;
        // Debug.Log($"{otherTrans.eulerAngles}: {targetAngles}");

        Vector3 CenterDirection = (other.transform.position - centerCapsule.transform.position).normalized;
        

        other.GetComponent<Rigidbody>().AddForce(CenterDirection * 10, ForceMode.VelocityChange);
        //other.GetComponent<Rigidbody>().AddForce(CenterDirection.right * 10, ForceMode.VelocityChange);
    }

}
