using UnityEngine;

public enum Symbol
{
	None,
	DotSlashDot,
	SquareRootDot,
	Spiral,
	RandomName,
}

public class Transmission : CachedBehaviour<Transmission>
{
	public float Lifetime = 5f;
	public float Speed = 100f;
	public Rigidbody2D Body;
	public Symbol Symbol;

	float counter;

	void Update()
	{
		if (counter < Lifetime)
			counter += Time.deltaTime;
		else
			Destroy(gameObject);
	}

	void FixedUpdate()
	{
		Body.velocity = transform.up * Speed * Time.fixedDeltaTime;
	}
}
