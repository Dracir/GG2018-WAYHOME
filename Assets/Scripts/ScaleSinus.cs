using UnityEngine;

public class ScaleSinus : CachedBehaviour<ScaleSinus>
{
	public Vector2 Amplitude;
	public Vector2 Frequency;
	public Vector2 Center;

	public Vector2 Offset { get; set; }

	void Start()
	{
		Offset = Random.insideUnitCircle * 100f;
	}

	void Update()
	{
		var scale = transform.localScale;
		scale.x = Mathf.Sin(Time.time * Frequency.x + Offset.x) * Amplitude.x + Center.x;
		scale.y = Mathf.Sin(Time.time * Frequency.y + Offset.y) * Amplitude.y + Center.y;
		transform.localScale = scale;
	}
}
