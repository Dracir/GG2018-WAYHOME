using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.IO;

[ExecuteInEditMode]
public class SymbolManager : MonoBehaviour {
	
	public List<SymbolData> Symbols = new List<SymbolData>();

	public bool Go;
	
	void Update()
	{
		if(!Go) return;
		Go = false;

		/*if(Symbols.Count == 0)
		{
			var symbs = System.Enum.GetValues(typeof(Symbol));
			
			var asss = Directory.GetFiles("Assets/Resources/Symbols/Sprites").Where(truc => truc.EndsWith("png")).ToList();
			var sprites = new List<Sprite>();
			sprites.Sort();
			foreach (var ass in asss)
			{
				sprites.Add(AssetDatabase.LoadAssetAtPath<Sprite>(ass));	
			}

			int i = 0;
			foreach (var s in (Symbol[])symbs)
			{
				var so = Utils.CreateAsset<SymbolData>("Assets/Resources/Symbols/ScriptableObject/" + s.ToString());
				so.Symbol = s;
				so.Sprite = sprites[i++];
			}
		}*/	
	}

	
}
