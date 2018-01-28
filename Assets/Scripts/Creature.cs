using System.Collections;
using UnityEngine;

public class Creature : CachedBehaviour<Creature>
{
	// TODO replace code with something useful...
	public SpriteRenderer Renderer;

	public Symbol Symbol;

	public bool FlagQuiIndiqueQueLaCreatureEstHappy;

	//void Update()
	//{
	//	if (Input.GetKeyDown(KeyCode.F1))
	//		HAPPY();
	//	else if (Input.GetKeyDown(KeyCode.F2))
	//		DIE();
	//}

	IEnumerator SuicideRoutine()
	{
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log("KWAME : " + other.gameObject.name);
		var transmission = other.GetComponentInParent<Transmission>();
		if (transmission == null) return;


		if (transmission.Symbol.Equals(Symbol))
			HAPPY();
		else
			DIE();

		Destroy(transmission);
	}

	private void DIE()
	{
		SoundManager.Instance.Play(SoundManager.Instance.CreatureDie, transform.position);

		ParticleManager.Instance.GutExplosion(transform.position);
		Destroy(gameObject);

	}

	private void HAPPY()
	{
		SoundManager.Instance.Play(SoundManager.Instance.CreatureHappy, transform.position);
		FlagQuiIndiqueQueLaCreatureEstHappy = true;
		foreach (var movementeur in GetComponents<AIMotion>())
			Destroy(movementeur);

		foreach (var sr in GetComponentsInChildren<SpriteRenderer>())
			DesatureMoiCa(sr);

		var tt = gameObject.AddComponent<TransformTransition>();
		tt.Duration = 1;
		tt.TargetPosition = transform.position + new Vector3(0, 10, 0);
		var scale = transform.localScale;
		float factor = 0.2f;
		tt.TargetScale = new Vector3(scale.x * factor, scale.y * factor, scale.z);

		StartCoroutine(SuicideRoutine());
	}

	private void DesatureMoiCa(SpriteRenderer sr)
	{
		var c = sr.color;
		float h, s, v;
		Color.RGBToHSV(c, out h, out s, out v);
		s *= 0.3f;
		v *= 0.4f;

		var ct = gameObject.AddComponent<ColorTransition>();
		ct.Duration = 1;
		ct.Target = sr;
		ct.TargetColor = Color.HSVToRGB(h, s, v);
	}
}
