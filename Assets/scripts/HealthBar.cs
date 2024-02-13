using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    //int PlayerCurrentHealth;


    [SerializeField]
    PlayerSpaceship Player;
    Health PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = Player.GetComponent<Health>();  //GameObject.Find("PlayerSpaceShip").GetComponent<Health>();
        //PlayerCurrentHealth = PlayerHealth.currentHealth; //GameObject.Find("PlayerSpaceShip").GetComponent<Health>().currentHealth;
        //healthBar = healthBar.GetComponent<Slider>();
        //healthBar.value = PlayerHealth - 50; 
    }

    void Update()
    {
        healthBar.value = PlayerHealth.currentHealth;
    }
}
