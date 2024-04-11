using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashingMeteor : MonoBehaviour
{
    public Transform crashPoint;
    public float crashSpeed = 50000f;
    Rigidbody rb;
    Damage SpaceshipDamage;
    Health health;
    bool HasCollided;

    [SerializeField]
    GameObject explosion;

    List<string> TargetTags = new List<string>() {"Player", "SpaceStation" };
    public Damage collisionDamage;
    public Damage PlayerCollisionDamage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SpaceshipDamage = GetComponent<Damage>();
        health = GetComponent<Health>();

        SetCollisionDamage();
    }

    void SetCollisionDamage()
    {
        collisionDamage = gameObject.AddComponent(typeof(Damage)) as Damage;
        PlayerCollisionDamage = gameObject.AddComponent(typeof(Damage)) as Damage;

        collisionDamage.DamagePoints = 25;
        PlayerCollisionDamage.DamagePoints = 20;
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
        if (TargetTags.Contains(other.gameObject.tag) & !HasCollided)
        {
            HasCollided = true;

            if (other.gameObject.tag == "SpaceStation")
            {
                CombatHandler.ApplyDamage(other.gameObject, SpaceshipDamage);
            }
            else
            {
                CombatHandler.ApplyDamage(other.gameObject, PlayerCollisionDamage);
            }
            CombatHandler.ApplyDamage(gameObject, collisionDamage);
        }
    }
}
