using UnityEngine;

public class KnowledgeOrb : CachedBehaviour<KnowledgeOrb>
{
	public Rigidbody2D Body;
	public CircleCollider2D Trigger;

	public bool Falling { get; private set; }

	public void Fall()
	{
		Falling = true;
		Body.simulated = true;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (Falling && collision.GetComponentInParent<Planet>() != null)
		{
			ParticleManager.Instance.ShardExplosion(transform.position);
			Destroy(gameObject);
		}
	}
}
