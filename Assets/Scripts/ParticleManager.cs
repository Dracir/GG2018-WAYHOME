using UnityEngine;

public class ParticleManager : Singleton<ParticleManager>
{
	public GutParticle[] GutParticles;
	public ShardParticle[] ShardParticles;

	public void GutExplosion(Vector3 position, int count = 10)
	{
		for (int i = 0; i < count; i++)
		{
			var particle = GutParticles[Random.Range(0, GutParticles.Length - 1)];
			var instance = Instantiate(particle, position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
			instance.Body.AddForce(Random.insideUnitCircle, ForceMode2D.Impulse);
		}
	}

	public void ShardExplosion(Vector3 position)
	{
		foreach (var particle in ShardParticles)
		{
			var instance = Instantiate(particle, position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)), transform);
			instance.Body.AddForce(Random.insideUnitCircle.normalized, ForceMode2D.Impulse);
		}
	}
}
