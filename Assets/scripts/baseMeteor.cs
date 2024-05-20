using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseMeteor : MonoBehaviour
{
    Health health;
    bool HasCollided;
    List<string> TargetTags = new List<string>() { "Player", "Enemy" };

    public Damage collisionDamage;
    public Damage PlayerCollisionDamage;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();

        SetCollisionDamage();
    }

    void SetCollisionDamage()
    {
        collisionDamage = gameObject.AddComponent(typeof(Damage)) as Damage;
        PlayerCollisionDamage = gameObject.AddComponent(typeof(Damage)) as Damage;
        
        collisionDamage.DamagePoints = 25;
        PlayerCollisionDamage.DamagePoints = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (TargetTags.Contains(other.gameObject.tag) & !HasCollided)
        {
            //Debug.Log(other.gameObject.name);
            HasCollided = true;
            CombatHandler.ApplyDamage(other.gameObject, PlayerCollisionDamage);
            CombatHandler.ApplyDamage(gameObject, collisionDamage);  // same damage as player collision
        }
    }
}
