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


	void Update()
	{
		MoveLaser();
	}

	public void setTarget(Vector3 target)
	{
		m_target = target;
		EndExistTime = Time.time + ExistTime;
	}

	public void setHitComponents(GameObject _hitObject, GameObject _laser, GameObject _shooterObject)
	{
		shooterObject = _shooterObject;
		hitObject = _hitObject;
		laser = _laser;
    }

	void OnCollisionEnter(Collision other)
    {
		GameObject hitObject = other.gameObject;

		// if hittable and only first registered collision
		if(hitObject.GetComponent<Health>() != null & !HasHit)
		{
			HasHit = true;
			CombatHandler.ApplyDamage(hitObject, shooterObject.GetComponent<Damage>());
			GameObject.Destroy(laser);
			Debug.Log("Has a hit!");
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
