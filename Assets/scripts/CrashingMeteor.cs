using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashingMeteor : MonoBehaviour
{
    public Transform crashPoint;
    public float crashSpeed = 100f;
    Rigidbody rb;
    Damage damage;

    [SerializeField]
    GameObject explosion;

    List<string> TargetTags = new List<string>() {"Player", "SpaceStation" };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        damage = GetComponent<Damage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(crashPoint)
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

            if (explosion)
            {
                GameObject explode = Instantiate(explosion, transform.position, transform.rotation);//.parent.transform);
                Destroy(explode, 1f);
            }

            Destroy(gameObject);
        }
    }
}
