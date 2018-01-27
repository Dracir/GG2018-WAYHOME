using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunneling : AIMotion
{

	public float GravitySpeed;

	public float TunnelingCooldown;

	public float LerpPower = 2;

	public float MinTunnelingDistance;
	public float MaxTunnelingDistance;
	float ActualTunnelingDistance;

	float nextTunnel;
	float direction = 1;
	public float originX;
	float target;
	float startTunnel;

	float t = 1;

	// Use this for initialization
	void Start()
	{
		ActualTunnelingDistance = Random.Range(MinTunnelingDistance, MaxTunnelingDistance);
		originX = transform.position.x;
		//Debug.Log(originX);
		//Debug.Log(CameraTop.Instance.Left + " - " + CameraTop.Instance.Right);
		originX = Mathf.Clamp(originX,CameraTop.Instance.Left + ActualTunnelingDistance , CameraTop.Instance.Right - ActualTunnelingDistance);
		//Debug.Log(originX);
		transform.localPosition = new Vector3(originX + ActualTunnelingDistance / 2, transform.localPosition.y, 0);
		target = transform.localPosition.x;
		nextTunnel = Time.time + TunnelingCooldown;
	}

	// Update is called once per frame
	void Update()
	{
		lookAtPlanet();
		var x = 0f;

		if (nextTunnel <= Time.time)
		{
			nextTunnel = Time.time + TunnelingCooldown;
			direction *= -1;
			target = originX - ActualTunnelingDistance / 2 * direction;
			startTunnel = transform.localPosition.x;
			t = 0;
		}

		t += Time.deltaTime;
		if (t < 1)
		{
			float time = Mathf.Pow(t, LerpPower) * (3f - 2f * t);
			x = Mathf.Lerp(startTunnel, target, time);
		}else{
			x = target;
		}


		var y = -GravitySpeed * Time.deltaTime;

		transform.localPosition = new Vector3(x, transform.localPosition.y + y, 0);
	}
}
