using System;
using UnityEngine;

public class Transmitter : CachedBehaviour<Transmitter>
{
	[Serializable]
	public struct Pair
	{
		public Symbol Symbol;
		public Sprite Sprite;
	}

	public Pair[] Symbols;
	public Transmission Transmission;
	public Screen Screen;

	public Pair Selected
	{
		get { return Symbols[selectedIndex]; }
	}

	int selectedIndex;

	public void Select(int index)
	{
		index = Mathf.Clamp(index, 0, Symbols.Length - 1);
		if (index != selectedIndex)
		{
			selectedIndex = index;
			Screen.SetSprite(Selected.Sprite);
		}
	}

	public void Next()
	{
		Select(selectedIndex + 1);
	}

	public void Previous()
	{
		Select(selectedIndex - 1);
	}

	public void Transmit()
	{
		var transmission = Instantiate(Transmission, transform.position, transform.rotation);
		transmission.Symbol = Selected.Symbol;
	}
}
