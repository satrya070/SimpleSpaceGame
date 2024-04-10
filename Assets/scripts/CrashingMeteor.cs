using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashingMeteor : MonoBehaviour
{
    public Transform crashPoint;
    public float crashSpeed = 5000f;
    Rigidbody rb;
    Damage damage;
    Health health;

    [SerializeField]
    GameObject explosion;

    List<string> TargetTags = new List<string>() {"Player", "SpaceStation" };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        damage = GetComponent<Damage>();
        health = GetComponent<Health>();

        SetCollisionDamage();
    }

    void SetCollisionDamage()
    {
        health.collisionDamage.DamagePoints = 25;
        health.PlayerCollisionDamage.DamagePoints = 15;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (crashPoint)
        {
            //Debug.Log("Moving rock!");
            Vector3 moveDirection = (crashPoint.position - transform.position).normalized;
            rb.AddForce(moveDirection * crashSpeed);
        }
    }

    void OnCollisionEnter(Collision other) {
        if (TargetTags.Contains(other.gameObject.tag))
        {
            Debug.Log(other.gameObject.name);
            CombatHandler.ApplyDamage(other.gameObject, damage);
            CombatHandler.ApplyDamage(gameObject, health.collisionDamage);  // same damage as player collision

            //Destroy(gameObject);
        }
    }
}
