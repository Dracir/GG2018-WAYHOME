using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class BloomMoiCa : Singleton<BloomMoiCa>
{

	public SpriteRenderer FullScreenOverlay;
	public PostProcessingProfile BloomProfile;

	public float maxBloomIntensity;

	public float FadeInDuration;
	public float FadeOutDuration;

	float t;
	float startIntensity;
	float endIntensity;
	Color startColor;
	Color endColor;

	//Touche pas a ca la! c a moi! mais tu peux me regarder
	public bool IsBlooming;

	public bool FadeInAfterFade;

	// Use this for initialization
	void Start()
	{
		StartFadeIn();
	}

	public void StartFadeIn()
	{
		if (IsBlooming)
			return;
		Debug.Log("bloo in");
		IsBlooming = true;
		FullScreenOverlay.color = new Color(255, 255, 255, 0);
		FullScreenOverlay.enabled = true;

		t = FadeInDuration;
		startIntensity = maxBloomIntensity;
		endIntensity = 0;

		startColor = Color.white;
		endColor = new Color(255, 255, 255, 0);
	}

	public void StartFadeOut()
	{
		if (IsBlooming)
			return;
		Debug.Log("bloo out");
		IsBlooming = true;
		FullScreenOverlay.color = Color.white;
		FullScreenOverlay.enabled = true;

		t = FadeOutDuration;
		endIntensity = maxBloomIntensity;
		startIntensity = 0;

		endColor = Color.white;
		startColor = new Color(255, 255, 255, 0);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F6))
			StartFadeIn();
		if (Input.GetKeyDown(KeyCode.F7))
			StartFadeOut();
		if (t > 0)
		{
			t -= Time.deltaTime;
			var bloom = BloomProfile.bloom.settings.bloom;
			if (t <= 0)
			{
				bloom.intensity = endIntensity;
				FullScreenOverlay.color = endColor;
				if (FadeInAfterFade)
				{
					FadeInAfterFade = false;
					IsBlooming = false;
					StartFadeIn();
				}
				else
					IsBlooming = false;
			}
			else
			{
				//Je suis fancy c a lenvers
				bloom.intensity = Mathf.Lerp(endIntensity, startIntensity, t / 2);
				FullScreenOverlay.color = Color.Lerp(endColor, startColor, t * t);

			}

		}
	}
}
