using System;
using System.Linq;
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
	public bool HasFailed { get; private set; }
	public bool HasSucceeded { get; private set; }

	void Update()
	{
		if (HasFailed || HasSucceeded) return;

		if (KnowledgeTree.Instance.Orbs.All(orb => orb == null))
		{
			HasFailed = true;
			Planet.Instance.TotalFailureOfDeath();
			return;
		}
		else if (IsDone)
		{
			HasSucceeded = true;
			Planet.Instance.TotalSuccessOfLife();
			return;
		}

		if (Current != null)
			ZeCamera.Instance.ChangeBackground(Current.Background);

		if (Cache<Creature>.Instances.Count == 0 && Cache<GutParticle>.Instances.Count == 0 && Index < Levels.Length - 1)
			NextLevel();

		if (Input.GetKey(KeyCode.P) && Input.GetKeyDown(KeyCode.F12))
		{
			foreach (var creature in Cache<Creature>.Instances.ToArray())
				Destroy(creature.gameObject);
		}
	}

	void NextLevel()
	{
		Index++;

		var level = Levels[Index];
		for (int i = 0; i < level.Creatures.Length; i++)
		{
			var creature = level.Creatures[i];
			var width = CameraTop.Instance.Right - CameraTop.Instance.Left;
			var slice = width / level.Creatures.Length;
			var x = CameraTop.Instance.Left + i * slice + slice / 2f;
			var y = CameraTop.Instance.Top;
			Spawn(new Vector2(x, y), creature);
		}

	}

	public void Spawn(Vector3 position, Creature creature)
	{
		if (creature == null)
		{
			Debug.LogError("Ouf tu spawn du null toi dans le Level Manager");
			return;
		}
		//SoundManager.Instance.Play(SoundManager.Instance.CreatureSpawn, transform.position);
		Instantiate(creature, position, Quaternion.identity);
	}
}
