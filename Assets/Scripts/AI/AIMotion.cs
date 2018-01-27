using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MoveSpeeds
{
    Slow,
    Medium,
    Fast
}

public class AIMotion : MonoBehaviour
{


	public bool LookAtThePlanet;
    public MoveSpeeds moveSpeed = MoveSpeeds.Medium;

    protected float GetMoveSpeed (MoveSpeeds value)
    {
        switch (value)
        {
            case MoveSpeeds.Slow:
                return 0.5f;
            case MoveSpeeds.Medium:
                return 0.8f;
            case MoveSpeeds.Fast:
                return 1.1f;
            default:
                return 0;
        }
        
    }

	protected void lookAtPlanet()
	{
		if (!LookAtThePlanet) return;

		Vector3 diff = Planet.Instance.transform.position - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}
}
