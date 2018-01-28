using UnityEngine;

public enum Symbol
{
	None = -1,
	_00, _01, _02, _03, _04, _05, _06, _07, _08, _09,
	_10, _11, _12, _13, _14, _15, _16, _17, _18, _19,
	_20, _21, _22, _23, _24, _25, _26, _27, _28, _29,
	_30, _31, _32, _33, _34, _35, _36, _37, _38, _39,
	_40, _41, _42, _43, _44, _45, _46, _47, _48, _49
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
