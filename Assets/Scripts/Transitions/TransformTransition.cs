using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTransition : MonoBehaviour {

	public float Duration;

	public Color TargetColor;
	public Vector3 TargetPosition;
	public Vector3 TargetScale;

	private Vector3 StartPosition;
	private Vector3 StartScale;
	
	float t = 0;
	
	void Start () {
		StartPosition = transform.position;	
		StartScale = transform.localScale;	
	}
	
	
	void Update () {
		t+= Time.deltaTime;
		float time = t/Duration;
		transform.position = Vector3.Lerp(StartPosition, TargetPosition,time);
		transform.localScale = Vector3.Lerp(StartScale, TargetScale,time);
		
	}
}
