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
            MainCameraTarget = GameObject.FindWithTag("MainCamera");
        }
    }

    void Update()
    {
        healthBar.value = OwnerHealth.currentHealth;

        if(MainCameraTarget)
        {
            transform.parent.transform.LookAt(MainCameraTarget.transform.position);
        }
    }
}
