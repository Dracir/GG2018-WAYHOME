using UnityEngine;

public class Transmitter : CachedBehaviour<Transmitter>
{
	public Symbol[] Symbols;
	public Transmission Transmission;

	public Symbol Selected
	{
		get { return Symbols[selectedIndex % Symbols.Length]; }
	}

	int selectedIndex;

	public bool Select(int index)
	{
		selectedIndex = Mathf.Clamp(index, 0, Symbols.Length - 1);
		return index != selectedIndex;
	}

	public bool Next()
	{
		return Select(selectedIndex + 1);
	}

	public bool Previous()
	{
		return Select(selectedIndex - 1);
	}

	public void Transmit()
	{
		var transmission = Instantiate(Transmission, transform.position, transform.rotation);
		transmission.Symbol = Selected;
	}
}
