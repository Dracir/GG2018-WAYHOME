using System;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
	[Serializable]
	public class Level
	{
		public Sprite Background;
		public Symbol[] Symbols;
		public Creature[] Creatures;
	}

	public Level[] Levels;
	public bool IsDone { get { return Index >= Levels.Length - 1 && Cache<Creature>.Instances.Count == 0; } }
	public Level Current { get { return Index >= 0 && Index < Levels.Length ? Levels[Index] : null; } }
	public int Index = -1;

	private bool SpawnIsWaitingForBloom;

	void Update()
	{
		if (Current != null)
			ZeCamera.Instance.ChangeBackground(Current.Background);

		if (Cache<Creature>.Instances.Count == 0 && Index < Levels.Length - 1)
			NextLevel();

		if (Input.GetKeyDown(KeyCode.F3))
		{
			foreach (var c in Cache<Creature>.Instances)
			{
				c.HAPPY();
			}
		}
	}

	void NextLevel()
	{
		Index++;

		foreach (var creature in Levels[Index].Creatures)
			Spawn(creature);

	}

	public void Spawn(Creature creature)
	{
		if (creature == null)
		{
			Debug.LogError("Ouf tu spawn du null toi dans le Level Manager");
			return;
		}
		var position = CameraTop.Instance.GetRandomInside();
		SoundManager.Instance.Play(SoundManager.Instance.CreatureSpawn, transform.position);
		Instantiate(creature, position, Quaternion.identity);
	}
}
