using System;
using System.Collections;
using UnityEngine;

public class Creature : CachedBehaviour<Creature>
{
	// TODO replace code with something useful...
	public SpriteRenderer Renderer;

	public Symbol LifeGivingHopeAndLoveSymbol;

	public Symbol Symbol { get { return LifeGivingHopeAndLoveSymbol; } }

	public bool FlagQuiIndiqueQueLaCreatureEstHappy;

	void Start()
	{
		// Change the color to differentiate creatures while there is no graphics for them...
		//var color = UnityEngine.Random.ColorHSV();
		//color.a = 1f;
		//Renderer.color = color;

		// Suicide to test the level progression...
		//StartCoroutine(SuicideRoutine());
	}

	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F1))
			HAPPY();
		else if(Input.GetKeyDown(KeyCode.F2))
			DIE();
	}

	IEnumerator SuicideRoutine()
	{
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		var transmission = other.GetComponent<Transmission>();
		if(transmission == null) return;


		if(transmission.Symbol.Equals(Symbol))
			HAPPY();
		else
			DIE();
	}

	private void DIE()
	{
		SoundManager.Instance.Play(SoundManager.Instance.CreatureDie, transform.position);

		// Kevin play giblits
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
		tt.TargetPosition = transform.position + new Vector3(0,10,0);
		var scale = transform.localScale;
		float factor = 0.2f;
		tt.TargetScale = new Vector3(scale.x * factor, scale.y * factor, scale.z);
	}

	private void DesatureMoiCa(SpriteRenderer sr)
	{
		var c = sr.color;
		float h,s,v;
		Color.RGBToHSV(c,out h, out s, out v);
		s *= 0.3f;
		v *= 0.4f;

		var ct = gameObject.AddComponent<ColorTransition>();
		ct.Duration = 1;
		ct.Target = sr;
		ct.TargetColor = Color.HSVToRGB(h,s,v);
	}
}
