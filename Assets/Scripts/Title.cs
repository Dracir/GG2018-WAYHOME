using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
	public GameObject Credits;
	public Image Overlay;

	void Start()
	{
		StartCoroutine(FadeInRoutine());
	}

	IEnumerator FadeInRoutine()
	{
		var duration = 10f;
		for (float counter = 0f; counter < duration; counter += Time.deltaTime)
		{
			var ratio = Mathf.Clamp01(counter / duration);
			var color = Overlay.color;
			color.a = 1f - ratio;
			Overlay.color = color;
			yield return null;
		}

		Overlay.gameObject.SetActive(false);
	}

	public void OnBegin()
	{
		SceneManager.LoadScene("Main");
	}

	public void OnCredits()
	{
		Credits.SetActive(true);
	}

	public void OnCreditsClose()
	{
		Credits.SetActive(false);
	}
}
