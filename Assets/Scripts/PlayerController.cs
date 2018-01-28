using UnityEngine;

public class PlayerController : CachedBehaviour<PlayerController>
{
	public Player Player;
	public float Speed = 5f;

	void FixedUpdate()
	{
		if (LevelManager.Instance.HasFailed) return;

		//UpdateRotation();
		UpdatePosition();
	}

	void UpdateRotation()
	{
		var direction = Player.Body.position - (Vector2)Planet.Instance.transform.position;
		Player.Body.MoveRotation(-Vector2.Angle(Vector2.up, direction));
	}

	void UpdatePosition()
	{
		var direction = Input.GetAxis("Horizontal");
		Player.Body.AddForce(Vector2.right * direction * Speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
	}
}
