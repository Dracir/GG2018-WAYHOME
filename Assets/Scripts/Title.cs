using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
	public GameObject Credits;
	public CanvasGroup Instructions;
	public Image Overlay;

	void Start()
	{
		StartCoroutine(FadeInRoutine());
	}

	void Update()
	{
		if (Instructions.gameObject.activeSelf && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftArrow))
			SceneManager.LoadScene("Main");
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

	IEnumerator InstructionsRoutine()
	{
		var duration = 1f;
		for (float counter = 0f; counter < duration; counter += Time.deltaTime)
		{
			var ratio = Mathf.Clamp01(counter / duration);
			Instructions.alpha = ratio;
			yield return null;
		}
	}

	public void OnBegin()
	{
		Instructions.gameObject.SetActive(true);
		StartCoroutine(InstructionsRoutine());
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
