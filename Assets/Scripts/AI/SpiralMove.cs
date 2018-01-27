using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMove : AIMotion {

	public float XRadius;
	public float YRadius;

	public float GravitySpeed = 1;
	public float Speed = 1;

	float yCenter;

	// Use this for initialization
	void Start () {
		var x = Mathf.Clamp(transform.position.x,CameraTop.Instance.Left + XRadius , CameraTop.Instance.Right - XRadius);
		transform.position = new Vector3(x,transform.position.y);
		yCenter = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		lookAtPlanet();

		var t = Time.time * Speed;

		var x = Mathf.Sin(t) * XRadius;
		var y = Mathf.Cos(t) * YRadius ;

		yCenter -= GravitySpeed * Time.deltaTime;

		transform.localPosition = new Vector3(x,yCenter + y,0);	


	}
}
