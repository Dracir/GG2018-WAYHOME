using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : Singleton<Planet>
{
	public void Shake()
	{
		StartCoroutine(ShakeRoutine());
	}

	public void TotalFailureOfDeath()
	{
		StopAllCoroutines();
		StartCoroutine(FailureRoutine());
	}

	public void TotalSuccessOfLife()
	{
		StopAllCoroutines();
		StartCoroutine(SuccessRoutine());
	}

	IEnumerator SuccessRoutine()
	{
		ZeCamera.Instance.Shake(0.25f, 5f);
		BloomMoiCa.Instance.FadeOutDuration = 5f;
		BloomMoiCa.Instance.StartFadeOut();
		SoundManager.Instance.Play("win", volume: 1f, pitch: 1f);

		BloomMoiCa.Instance.FullScreenOverlay.enabled = true;
		var duration = 5f;
		for (float counter = 0; counter < duration; counter += Time.deltaTime)
		{
			var ratio = Mathf.Clamp01(counter / duration);
			var settings = BloomMoiCa.Instance.BloomProfile.bloom.settings;
			settings.bloom.intensity = ratio * 25f;
			BloomMoiCa.Instance.BloomProfile.bloom.settings = settings;
			var color = BloomMoiCa.Instance.FullScreenOverlay.color;
			color.a = ratio;
			BloomMoiCa.Instance.FullScreenOverlay.color = color;
			yield return null;
		}
		Application.Quit();
		//SceneManager.LoadScene("End");
	}

	IEnumerator FailureRoutine()
	{
		ZeCamera.Instance.Shake(0.25f, 5f);
		BloomMoiCa.Instance.FadeOutDuration = 5f;
		BloomMoiCa.Instance.StartFadeOut();

		BloomMoiCa.Instance.FullScreenOverlay.enabled = true;
		var duration = 5f;
		for (float counter = 0; counter < duration; counter += Time.deltaTime)
		{
			var ratio = Mathf.Clamp01(counter / duration);
			var settings = BloomMoiCa.Instance.BloomProfile.bloom.settings;
			settings.bloom.intensity = ratio * 25f;
			BloomMoiCa.Instance.BloomProfile.bloom.settings = settings;
			var color = BloomMoiCa.Instance.FullScreenOverlay.color;
			color.a = ratio;
			BloomMoiCa.Instance.FullScreenOverlay.color = color;
			yield return null;
		}
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	IEnumerator ShakeRoutine()
	{
		ZeCamera.Instance.Shake(0.1f, 2.5f);
		yield return new WaitForSeconds(1f);
		KnowledgeTree.Instance.Shake();
		yield return new WaitForSeconds(1f);
	}
}
