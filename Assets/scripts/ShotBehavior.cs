using UnityEngine;
using System.Collections;
using System;

public class ShotBehavior: MonoBehaviour
{
	public Vector3 m_target;
	public float speed;
	string HitterTag;

	private bool HasHit;
	private float EndExistTime;
	private float ExistTime = 2f;
	Damage DamageObj;


	void Update()
	{
		MoveLaser();
	}

	public void setTargetComponents(string _HitterTag, Vector3 target, Damage _DamageObj)
	{
		HitterTag = _HitterTag;
		m_target = target;
		EndExistTime = Time.time + ExistTime;
		DamageObj = _DamageObj;
	}

	void OnCollisionEnter(Collision other)
    {
		Debug.Log($"hit {other.gameObject.name}");
		GameObject hitObject = other.gameObject;

		// check for events where damage should be different from default
		if(GameManager.GameManagerInstance.specialBehaviour.ContainsKey(Tuple.Create(HitterTag, other.gameObject.tag)))
		{
			DamageObj.DamagePoints = GameManager.GameManagerInstance.specialBehaviour[Tuple.Create(HitterTag, other.gameObject.tag)];
		}

		// if hittable and only first registered collision
		if(hitObject.GetComponent<Health>() != null & !HasHit)
		{
			Debug.Log(HitterTag);
			HasHit = true;
			//Debug.Log($"{hitObject.name} <- {shooterObject.name}:{shooterObject.GetComponent<Damage>().DamagePoints}");
			CombatHandler.ApplyDamage(hitObject, DamageObj);
			Destroy(gameObject);
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
}
