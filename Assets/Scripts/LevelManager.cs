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

	private bool SpawnIsWaitingForBloom;

	void Update()
	{
		if (Cache<Creature>.Instances.Count == 0 && Index < Levels.Length - 1)
			NextLevel();

		if (Input.GetKeyDown(KeyCode.F3))
		{
			foreach (var c in Cache<Creature>.Instances)
			{
				c.HAPPY();
			}
		}

		if (SpawnIsWaitingForBloom && !BloomMoiCa.Instance.IsBlooming)
		{
			foreach (var creature in Levels[Index].Creatures)
				Spawn(creature);

			SpawnIsWaitingForBloom = false;
		}
	}

	private void NextLevel()
	{
		if (SpawnIsWaitingForBloom)
			return;
		Debug.Log("Next level");
		Index++;
		moinBug = false;
		SpawnIsWaitingForBloom = true;
		if (Index > 0)
		{
			BloomMoiCa.Instance.StartFadeOut();
			BloomMoiCa.Instance.FadeInAfterFade = true;
		}

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
