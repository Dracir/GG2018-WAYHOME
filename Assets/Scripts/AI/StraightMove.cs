using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMove : AIMotion {

	// Use this for initialization
	void Start () {
		
	}
	
	
	// Update is called once per frame
	void Update () {
		lookAtPlanet();
		
		var y = -GravitySpeed * Time.deltaTime;
		transform.localPosition += new Vector3(0,y,0);
	}
}
