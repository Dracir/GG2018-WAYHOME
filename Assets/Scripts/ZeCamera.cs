using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ZeCamera : Singleton<ZeCamera>
{
	public Transform[] Hooks;
	public Image Noise;
	public Image Background;

	Vector3 position;

	protected override void Awake()
	{
		base.Awake();

		position = transform.position;
	}

	void Update()
	{
		foreach (var hook in Hooks)
		{
			var hookPosition = hook.position;
			hookPosition.x = position.x;
			hookPosition.y = position.y;
			hook.position = hookPosition;
		}
	}

	public void ChangeBackground(Sprite sprite)
	{
		if (Background.sprite != sprite)
			StartCoroutine(ChangeBackgroundRoutine(sprite));
	}

	IEnumerator ChangeBackgroundRoutine(Sprite sprite)
	{
		Noise.gameObject.SetActive(true);
		SoundManager.Instance.Play("noise_short", volume: 0.1f, pitch: 0.75f);
		Background.sprite = sprite;
		yield return new WaitForSeconds(0.25f);
		Noise.gameObject.SetActive(false);
	}

	public void Shake(float amplitude, float duration)
	{
		StartCoroutine(ShakeRoutine(amplitude, duration));
	}

	IEnumerator ShakeRoutine(float amplitude, float duration)
	{
		SoundManager.Instance.Play("earthquake", volume: 0.5f, pitch: 1f);
		for (float counter = 0f; counter < duration; counter += Time.deltaTime)
		{
			transform.position = position + (Vector3)Random.insideUnitCircle * amplitude;
			yield return null;
		}

		transform.position = position;
	}
}
