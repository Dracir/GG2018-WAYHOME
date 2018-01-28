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


	public bool LookAtThePlanet = true;
    public MoveSpeeds moveSpeed = MoveSpeeds.Medium;
    public float GravitySpeed { get { return GetMoveSpeed(moveSpeed);}} 

    protected float GetMoveSpeed (MoveSpeeds value)
    {
        switch (value)
        {
            case MoveSpeeds.Slow:
                return 0.075f;
            case MoveSpeeds.Medium:
                return 0.125f;
            case MoveSpeeds.Fast:
                return 0.25f;
            default:
                return 0;
        }
        
    }

	protected void lookAtPlanet()
	{
		if (!LookAtThePlanet) return;

		Vector3 diff = Planet.Instance.transform.position - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg + 180;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}

    

	protected void FixPosition()
	{
		var x = Mathf.Clamp(transform.localPosition.x,CameraTop.Instance.Left + 1 , CameraTop.Instance.Right - 1);
		transform.localPosition = new Vector3(x,transform.position.y,0);
	}
}
