using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SymbolManager : Singleton<SymbolManager>
{
	public struct Data
	{
		public Symbol Symbol;
		public Sprite Sprite;
	}

	public Sprite[] Sprites;

	Data[] data = new Data[0];
	Dictionary<Symbol, Data> symbolToData = new Dictionary<Symbol, Data>();

	protected override void Awake()
	{
		base.Awake();

		data = Sprites.Select((sprite, index) => new Data { Symbol = (Symbol)index, Sprite = sprite }).ToArray();
		symbolToData = data.ToDictionary(data => data.Symbol);
	}

	public Sprite GetSprite(Symbol symbol) { return GetData(symbol).Sprite; }
	public Data GetData(Symbol symbol) { return symbolToData[symbol]; }
}
