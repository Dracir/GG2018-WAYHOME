using System.Collections;
using UnityEngine;

public class Screen : CachedBehaviour<Screen>
{
	public float NoiseDuration = 0.2f;
	public Sprite[] Noise;
	public SpriteRenderer Renderer;

	Symbol selected;

	public void Select(Symbol symbol)
	{
		if (selected == symbol) return;
		else
		{
			selected = symbol;
			StopAllCoroutines();
			StartCoroutine(SetSymbolRoutine(SymbolManager.Instance.GetSprite(selected)));
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
