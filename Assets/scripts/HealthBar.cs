using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider healthBar;
    GameObject Owner;
    Health OwnerHealth;
    GameObject MainCameraTarget;

    void Start()
    {
        healthBar = GetComponent<Slider>();
        Owner = transform.root.gameObject;
        OwnerHealth = Owner.GetComponent<Health>();

        if(gameObject.transform.root.gameObject.tag != "Player")
        {
            Debug.Log($"{gameObject.transform.root.transform.gameObject.name} is searhcing for player camera...");
            MainCameraTarget = GameObject.FindWithTag("MainCamera");
            Debug.Log(MainCameraTarget.transform.position);
        }
    }

    void Update()
    {
        healthBar.value = OwnerHealth.currentHealth;

        if(MainCameraTarget)
        {
            //Debug.Log(transform.parent.transform.name);
            transform.parent.transform.LookAt(MainCameraTarget.transform.position);
        }
    }
}
