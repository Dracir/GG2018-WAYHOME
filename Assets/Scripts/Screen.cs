using System.Collections;
using UnityEngine;

public class Screen : CachedBehaviour<Screen>
{
	public float NoiseDuration = 0.2f;
	public Sprite[] Noise;
	public SpriteRenderer Renderer;

	LevelManager.Pair selected;

	public void Select(LevelManager.Pair pair)
	{
		if (selected == pair) return;
		else
		{
			selected = pair;
			StopAllCoroutines();
			StartCoroutine(SetSymbolRoutine(selected.Sprite));
		}
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
