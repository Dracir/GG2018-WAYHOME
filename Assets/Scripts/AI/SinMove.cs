using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMove : AIMotion {

	public float Frequency = 1;
	public float Amplitude = 1;
	public float Offset = 0;


	private float lastX;
	private float lastSin;
	
	void Start () {
		var x = Mathf.Clamp(transform.position.x,CameraTop.Instance.Left + Amplitude , CameraTop.Instance.Right - Amplitude);
		transform.position = new Vector3(x,transform.position.y);

		lastX = Amplitude * Mathf.Sin( Frequency * Time.time + Offset) ;
		
	}
	
	// Update is called once per frame
	void Update () {
		lookAtPlanet();
		var x = Amplitude * Mathf.Sin( Frequency * Time.time + Offset) ;
		
		var y = -GravitySpeed * Time.deltaTime;
		transform.localPosition += new Vector3(lastX-x,y,0);
		lastX = x;

		FixPosition();
	}
}
