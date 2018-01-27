using UnityEngine;

public enum Symbol
{
	None,
	A1,A2,B1,B2,C1,C2,C3,C4,
	D1,D2,D3,D4,
	E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,
	F1,F2,F3,F4,G1,G2,G3,G4,
	H1,H2,H3,H4,H5,
	I1,I2,I3,I4,I5,I6,I7,I8,
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
