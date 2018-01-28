using UnityEngine;

public class Motor : CachedBehaviour<Motor>
{
	public enum State { Idle, Rolling }

	public float Threshold = 0.1f;
	public float Frequency = 20f;
	public SpriteRenderer Idle;
	public SpriteAnimator Rolling;
	public Player Player;

	State state;

	void Update()
	{
		var magnitude = Player.Body.velocity.x;
		state = Mathf.Abs(magnitude) > Threshold ? State.Rolling : State.Idle;

		Idle.gameObject.SetActive(state == State.Idle);
		Rolling.gameObject.SetActive(state == State.Rolling);

		switch (state)
		{
			case State.Idle:
				Idle.sprite = Rolling.Renderer.sprite;
				break;
			case State.Rolling:
				Rolling.Frequency = magnitude * Frequency;
				break;
		}
	}
}
