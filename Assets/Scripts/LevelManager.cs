using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
	[Serializable]
	public class Level
	{
		public Creature[] Creatures;
	}

	public Level[] Levels;
	public bool IsDone { get { return Index >= Levels.Length - 1 && Remaining.Count == 0 && Cache<Creature>.Instances.Count == 0; } }
	public int Index = -1;
	public readonly Queue<Creature> Remaining = new Queue<Creature>();

	void Update()
	{
		if (Cache<Creature>.Instances.Count == 0 && Index < Levels.Length - 1 && Remaining.Count == 0)
		{
			Index++;

			foreach (var creature in Levels[Index].Creatures)
				Remaining.Enqueue(creature);
		}

		if (Cache<Creature>.Instances.Count == 0 && Remaining.Count > 0)
			Spawn(Remaining.Dequeue());
	}

	public void Spawn(Creature creature)
	{
		// TODO: Spawn at a proper position...
		var p  = CameraTop.Instance.GetRandomInside();
		Instantiate(creature, p, Quaternion.identity);
	}
}
