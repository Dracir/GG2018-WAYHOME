using UnityEngine;

public class ShardParticle : CachedBehaviour<ShardParticle>
{
	public float FadeOutTime = 1f;
	public float LifeTime = 5f;
	public SpriteRenderer Renderer;
	public CircleCollider2D Collider;
	public Rigidbody2D Body;

	float lifeCounter;

	void Update()
	{
		lifeCounter += Time.deltaTime;

		if (lifeCounter >= LifeTime)
			Destroy(gameObject);
		else if (lifeCounter >= LifeTime - FadeOutTime)
		{
			var ratio = 1f - (lifeCounter - (LifeTime - FadeOutTime)) / FadeOutTime;
			var color = Renderer.color;
			color.a = ratio;
			Renderer.color = color;
		}
	}
}
