using UnityEngine;
using System.Collections;

public class ShotBehavior: MonoBehaviour
{
	public Vector3 m_target;
	public GameObject hitObject;
	public GameObject collisionExplosion;
	public float speed;

	void Update()
	{
		float step = speed * Time.deltaTime;

		if (m_target != null)
		{
			if (transform.position == m_target)
			{
				if (hitObject != null)
				{
					GameObject.Destroy(hitObject);
				}

				// still needed?
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
