using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider healthBar;
    GameObject Owner;
    Health OwnerHealth;

    void Start()
    {
        healthBar = GetComponent<Slider>();
        Owner = transform.root.gameObject;
        OwnerHealth = Owner.GetComponent<Health>();
    }

    void Update()
    {
        healthBar.value = OwnerHealth.currentHealth;
    }
}
