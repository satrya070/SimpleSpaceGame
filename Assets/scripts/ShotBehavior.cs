﻿using UnityEngine;
using System.Collections;

public class ShotBehavior: MonoBehaviour
{
	public Vector3 m_target;
	public GameObject hitObject;
	public GameObject collisionExplosion;
	public float speed;
	int ShotID;

	void Update()
	{
		float step = speed * Time.deltaTime;

		if (m_target != null)
		{
			if (transform.position == m_target)
			{
				// if hit an object with health
				if (hitObject != null && hitObject.GetComponent<Health>() != null)
				{	
					// make sure that during update shot counts only once
					if (ShotID != hitObject.gameObject.GetInstanceID())
					{
                        ShotID = hitObject.gameObject.GetInstanceID();
                        CombatHandler.ApplyDamage(hitObject, GameObject.Find("PlayerSpaceShip").GetComponent<Damage>());
					}
				}

				// still needed? (laser explosion)
				explode();
				return;
			}
			transform.position = Vector3.MoveTowards(transform.position, m_target, step);
		}
	}

	public void setTarget(Vector3 target)
	{
		m_target = target;
	}

	public void setHitComponent(GameObject _hitObject)
	{
		hitObject = _hitObject;
    }

	void explode()
	{
		if (collisionExplosion != null)
		{
			GameObject explosion = (GameObject)Instantiate(
				collisionExplosion, transform.position, transform.rotation
			);
			Destroy(gameObject);
			Destroy(explosion, 1f);
		}
	}
}