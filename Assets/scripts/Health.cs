using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // public variables
    public int maxHealth;



    public int currentHealth;
    
    [SerializeField]
    GameObject explosion;

    public Damage collisionDamage;
    public Damage PlayerCollisionDamage;

    void Start()
    {
        currentHealth = maxHealth;
        InitializeCollisionDamage();
    }

    void InitializeCollisionDamage()
    {
        collisionDamage = new Damage();
        PlayerCollisionDamage = new Damage();
    }

    public void TakeDamage(Damage damage)
    {
        currentHealth -= damage.DamagePoints;

        Debug.Log(damage.DamagePoints);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (explosion)
        {
            Debug.Log($"instantiate explosion! at: {transform.position}");
            GameObject explode = Instantiate(explosion, transform.position, transform.rotation);//.parent.transform);
            Destroy(explode, 1f);
        }

        if(gameObject.tag == "Player")
        {
            Transform shipTrans = gameObject.transform.Find("ship");
            Destroy(shipTrans.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerSpaceShip")
        {
            //Debug.Log(other.gameObject.name);
            CombatHandler.ApplyDamage(other.gameObject, PlayerCollisionDamage);
            CombatHandler.ApplyDamage(gameObject, collisionDamage);
        }
    }
}
