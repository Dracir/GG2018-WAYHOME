using System.Collections;
using UnityEngine;

public class Planet : Singleton<Planet>
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S)) Shake();
	}

	public void Shake()
	{
		StopAllCoroutines();
		StartCoroutine(ShakeRoutine());
	}

	IEnumerator ShakeRoutine()
	{
		ZeCamera.Instance.Shake(0.1f, 3f);
		yield return new WaitForSeconds(1f);
		KnowledgeTree.Instance.Shake();
		BloomMoiCa.Instance.StartFadeIn();
		yield return new WaitForSeconds(1f);
	}
}
