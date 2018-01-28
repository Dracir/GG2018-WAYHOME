using System.Collections;
using UnityEngine;

public class Creature : CachedBehaviour<Creature>
{
	public enum State
	{
		Normal,
		Angry,
		Happy
	}

	// TODO replace code with something useful...
	public SpriteRenderer Renderer;

	public Symbol Symbol;

	public bool FlagQuiIndiqueQueLaCreatureEstHappy;

	State state;

	void FixedUpdate()
	{
		switch (state)
		{
			case State.Normal:
				break;
			case State.Angry:
				foreach (var motion in GetComponents<AIMotion>())
					motion.enabled = false;
				foreach (var sprite in GetComponentsInChildren<SpriteRenderer>())
					sprite.color = Color.Lerp(sprite.color, Color.red, Time.deltaTime * 3f);
				var direction = (Planet.Instance.transform.position - transform.position).normalized;
				var body = GetComponent<Rigidbody2D>();
				body.bodyType = RigidbodyType2D.Dynamic;
				body.AddForce(direction * 10f * Time.fixedDeltaTime, ForceMode2D.Impulse);
				break;
			case State.Happy:
				// TODO give me some happy eyes.
				break;
		}
	}

	IEnumerator SuicideRoutine()
	{
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponentInParent<Planet>() != null)
			DIE();
		else if (state == State.Normal)
		{
			var transmission = other.GetComponentInParent<Transmission>();
			if (transmission == null) return;

			if (transmission.Selected.Equals(Symbol))
				HAPPY();
			else
				ANGRY();

			Destroy(transmission.gameObject);
		}
	}

	public void ANGRY()
	{
		state = State.Angry;
	}

	public void DIE()
	{
		SoundManager.Instance.Play(SoundManager.Instance.CreatureDie, transform.position);
		Planet.Instance.Shake();
		ParticleManager.Instance.GutExplosion(transform.position);
		Destroy(gameObject);

	}

	public void HAPPY()
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
