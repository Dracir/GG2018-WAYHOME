using System;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
	[Serializable]
	public class Level
	{
		public Symbol[] Symbols;
		public Creature[] Creatures;
	}

	public Level[] Levels;
	public bool IsDone { get { return Index >= Levels.Length - 1 && Cache<Creature>.Instances.Count == 0; } }
	public Level Current { get { return Index >= 0 && Index < Levels.Length ? Levels[Index] : null; } }
	public int Index = -1;

	void Update()
	{
		if (Cache<Creature>.Instances.Count == 0 && Index < Levels.Length - 1)
		{
			Index++;

			foreach (var creature in Levels[Index].Creatures)
				Spawn(creature);
		}
	}

	public void Spawn(Creature creature)
	{
		var position = CameraTop.Instance.GetRandomInside();
		SoundManager.Instance.Play(SoundManager.Instance.CreatureSpawn, transform.position);
		Instantiate(creature, position, Quaternion.identity);
	}
}
