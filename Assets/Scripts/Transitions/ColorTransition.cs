using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTransition : MonoBehaviour {

	public float Duration;

	public SpriteRenderer Target;
	public Color TargetColor;
	Color StartColor;
	float t = 0;
	
	void Start () {
		StartColor = Target.color;	
	}
	
	
	void Update () {
		t+= Time.deltaTime;
		var c = Color.Lerp(StartColor, TargetColor, t/Duration);
		Target.color = c;
		
	}
}
