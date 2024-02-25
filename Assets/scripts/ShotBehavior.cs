using UnityEngine;
using System.Collections;

public class ShotBehavior: MonoBehaviour
{
	public Vector3 m_target;
	GameObject hitObject;
	GameObject laser;
	GameObject collisionExplosion;
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
					// make sure that during update applyDamage prt 1 unique shot
					if (ShotID != hitObject.gameObject.GetInstanceID())
					{
                        ShotID = hitObject.gameObject.GetInstanceID();
                        CombatHandler.ApplyDamage(hitObject, GameObject.Find("PlayerSpaceShip").GetComponent<Damage>());
						GameObject.Destroy(laser);
					}
				}

				// TODO still needed? (laser explosion, if not delete)
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

	public void setHitComponents(GameObject _hitObject, GameObject _laser)
	{
		hitObject = _hitObject;
		laser = _laser;
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
