using System.Collections;
using UnityEngine;

public class KnowledgeOrb : CachedBehaviour<KnowledgeOrb>
{
	public Rigidbody2D Body;
	public CircleCollider2D Trigger;
	public SpriteRenderer Renderer;

	public bool Falling { get; private set; }

	public void Fall()
	{
		if (!Falling)
		{
			Falling = true;
			StartCoroutine(FallRoutine());
		}
	}

	IEnumerator FallRoutine()
	{
		Body.simulated = true;

		var duration = 5f;
		for (float counter = 0f; counter < duration; counter += Time.deltaTime)
		{
			var ratio = 1f - counter / duration;
			var color = Renderer.color;
			color *= ratio;
			color.a = 1f;
			Renderer.color = color;
			yield return null;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (Falling && collision.GetComponentInParent<Planet>() != null)
		{
			ParticleManager.Instance.ShardExplosion(transform.position);
			BloomMoiCa.Instance.StartFadeIn();
			Destroy(gameObject);
		}
	}
}
