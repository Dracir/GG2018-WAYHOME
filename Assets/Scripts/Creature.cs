using System.Collections;
using UnityEngine;

public class Creature : CachedBehaviour<Creature>
{
	// TODO replace code with something useful...
	public SpriteRenderer Renderer;

	void Start()
	{
		// Change the color to differentiate creatures while there is no graphics for them...
		var color = Random.ColorHSV();
		color.a = 1f;
		Renderer.color = color;

		// Suicide to test the level progression...
		StartCoroutine(SuicideRoutine());
	}

	IEnumerator SuicideRoutine()
	{
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}
}
