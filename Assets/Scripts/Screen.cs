using System.Collections;
using UnityEngine;

public class Screen : CachedBehaviour<Screen>
{
	public float NoiseDuration = 0.2f;
	public Sprite[] Noise;
	public SpriteRenderer Renderer;

	public void SetSprite(Sprite sprite)
	{
		StopAllCoroutines();
		StartCoroutine(SetSymbolRoutine(sprite));
	}

	IEnumerator SetSymbolRoutine(Sprite sprite)
	{
		for (float counter = 0f; counter < NoiseDuration; counter += Time.deltaTime)
		{
			Renderer.sprite = Noise[Random.Range(0, Noise.Length)];
			yield return null;
		}

		Renderer.sprite = sprite;
	}
}
