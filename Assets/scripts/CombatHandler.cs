using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    public static void ApplyDamage(GameObject target, Damage damage)
    {
        Debug.Log($"{damage.DamagePoints} taken!");
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
