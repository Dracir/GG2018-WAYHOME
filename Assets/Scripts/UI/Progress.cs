using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
	public Color Queued;
	public Color InProgress;
	public Color Done;
	public Image Big;
	public Image Small;

	Image[] bigs;
	Image[][] smalls;
	Image end;

	void Start()
	{
		bigs = new Image[LevelManager.Instance.Levels.Length];
		smalls = new Image[LevelManager.Instance.Levels.Length][];

		for (int i = 0; i < LevelManager.Instance.Levels.Length; i++)
		{
			var level = LevelManager.Instance.Levels[i];
			var big = Instantiate(Big, transform);
			big.gameObject.SetActive(true);
			bigs[i] = big;
			smalls[i] = new Image[level.Creatures.Length];

			for (int j = 0; j < level.Creatures.Length; j++)
			{
				var small = Instantiate(Small, transform);
				small.gameObject.SetActive(true);
				smalls[i][j] = small;
			}
		}

		end = Instantiate(Big, transform);
		end.gameObject.SetActive(true);
	}

	void Update()
	{
		for (int i = 0; i < bigs.Length; i++)
		{
			if (LevelManager.Instance.Index > i || LevelManager.Instance.IsDone)
				bigs[i].color = Done;
			else if (LevelManager.Instance.Index == i)
				bigs[i].color = InProgress;
			else
				bigs[i].color = Queued;
		}

		for (int i = 0; i < smalls.Length; i++)
		{
			var current = smalls[i];

			for (int j = 0; j < current.Length; j++)
			{
				if (LevelManager.Instance.Index > i || LevelManager.Instance.IsDone)
					current[j].color = Done;
				else if (LevelManager.Instance.Index == i)
				{
					var index = current.Length - Cache<Creature>.Instances.Count;
					if (index > j)
						current[j].color = Done;
					else
						current[j].color = InProgress;
				}
				else
					current[j].color = Queued;
			}
		}

		if (LevelManager.Instance.IsDone)
			end.color = Done;
		else
			end.color = Queued;
	}
}
