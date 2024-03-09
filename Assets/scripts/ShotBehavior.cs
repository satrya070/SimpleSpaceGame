using UnityEngine;
using System.Collections;

public class ShotBehavior: MonoBehaviour
{
	public Vector3 m_target;
	GameObject shooterObject;
	GameObject hitObject;
	GameObject laser;
	GameObject collisionExplosion;
	public float speed;

	private bool HasHit;
	private float EndExistTime;
	private float ExistTime = 2f;
	Damage DamageObj;


	void Update()
	{
		MoveLaser();
	}

	public void setTargetComponents(Vector3 target, Damage _DamageObj)
	{
		m_target = target;
		EndExistTime = Time.time + ExistTime;
		DamageObj = _DamageObj;
	}

	public void setHitComponents(GameObject _hitObject, GameObject _laser, GameObject _shooterObject)
	{
		hitObject = _hitObject;
		laser = _laser;
		shooterObject = _shooterObject;
		//Debug.Log($"{hitObject.name} <- {shooterObject.name}");
    }

	void OnCollisionEnter(Collision other)
    {
		Debug.Log($"hit {other.gameObject.name}");
		GameObject hitObject = other.gameObject;

		// if hittable and only first registered collision
		if(hitObject.GetComponent<Health>() != null & !HasHit)
		{
			HasHit = true;
			//Damage damageTobe = shooterObject.GetComponent<Damage>();
			//Debug.Log($"{hitObject.name} <- {shooterObject.name}:{damageTobe.DamagePoints}");
			CombatHandler.ApplyDamage(hitObject, DamageObj);
			Destroy(gameObject);
			//Debug.Log("Has a hit!");
		}
	}

	void MoveLaser()
	{
		// make it travel max existtime
		if(Time.time > EndExistTime)
		{
			Destroy(gameObject);
		}

		float step = speed * Time.deltaTime;
		if (m_target != null)
		{
			transform.position = Vector3.MoveTowards(transform.position, m_target, step);
		}
	}

	// void explode()
	// {
	// 	if (collisionExplosion != null)
	// 	{
	// 		GameObject explosion = (GameObject)Instantiate(
	// 			collisionExplosion, transform.position, transform.rotation
	// 		);
	// 		Destroy(gameObject);
	// 		Destroy(explosion, 1f);
	// 	}
	// }
}
