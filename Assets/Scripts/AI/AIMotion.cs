using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMotion : MonoBehaviour
{


	public bool LookAtThePlanet;



	protected void lookAtPlanet()
	{
		if (!LookAtThePlanet) return;

		Vector3 diff = Planet.Instance.transform.position - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}
}
