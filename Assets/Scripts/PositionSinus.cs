using UnityEngine;

public class PositionSinus : CachedBehaviour<PositionSinus>
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
		var position = transform.localPosition;
		position.x = Mathf.Sin(Time.time * Frequency.x + Offset.x) * Amplitude.x + Center.x;
		position.y = Mathf.Sin(Time.time * Frequency.y + Offset.y) * Amplitude.y + Center.y;
		transform.localPosition = position;
	}
}
