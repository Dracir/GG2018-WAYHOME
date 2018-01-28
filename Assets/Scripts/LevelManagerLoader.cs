using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif
[ExecuteInEditMode]
public class LevelManagerLoader : MonoBehaviour
{

	public bool GO;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (!GO)
			return;
		GO = false;

		#if UNITY_EDITOR
		var levelManager = LevelManager.Instance;

		var ds = Directory.GetDirectories("Assets/Prefabs/Creatures");
		foreach (var direct in ds)
		{
			var n = direct.Substring(direct.Length-2);
			int i = 0;
			int.TryParse(n, out i);

			var ass = Directory.GetFiles(direct).Where(f=>f.EndsWith(".prefab")).ToList();
			Debug.Log(i + " - " + ass.Count);
			levelManager.Levels[i-1].Creatures = new Creature[ass.Count];
			int j = 0;
			foreach (var a in ass)
			{
				var creature = ((GameObject)AssetDatabase.LoadAssetAtPath(a, typeof(GameObject))).GetComponent<Creature>();
				levelManager.Levels[i-1].Creatures[j] = creature;
				j++;
			}
		}
		#endif
	}
}
