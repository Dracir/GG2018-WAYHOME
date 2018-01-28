using System.Collections;
using UnityEngine;

public class Screen : CachedBehaviour<Screen>
{
	public float NoiseDuration = 0.2f;
	public SpriteRenderer SymbolRenderer;
	public SpriteRenderer NoiseRenderer;

	Symbol selected = Symbol.None;

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
		NoiseRenderer.gameObject.SetActive(true);
		SoundManager.Instance.Play("noise_short", volume: 0.1f, pitch: 3f);
		yield return new WaitForSeconds(NoiseDuration);
		NoiseRenderer.gameObject.SetActive(false);
		SymbolRenderer.sprite = sprite;
	}
}
