using System.Linq;
using UnityEngine;

public class KnowledgeTree : Singleton<KnowledgeTree>
{
	public KnowledgeOrb[] Orbs;

	public void Shake()
	{
		var validOrbs = Orbs.Where(orb => orb != null && !orb.Falling).ToArray();
		if (validOrbs.Length > 0)
			validOrbs[Random.Range(0, validOrbs.Length)].Fall();
	}
}
