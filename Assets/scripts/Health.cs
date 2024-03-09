using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // public variables
    //[SerializeField]
    public int maxHealth;

    public int currentHealth;
    
    [SerializeField]
    GameObject explosion;

    void Start()
    {
        currentHealth = maxHealth;
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
}
