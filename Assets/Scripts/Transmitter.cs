using UnityEngine;

public class Transmitter : CachedBehaviour<Transmitter>
{
	public Transmission Transmission;
	public Screen Screen;

	int selectedIndex;
	LevelManager.Pair selectedPair;

	void Update()
	{
		Select(selectedIndex);
	}

	public void Select(int index)
	{
		if (LevelManager.Instance.Current == null) return;

		selectedIndex = Mathf.Clamp(index, 0, LevelManager.Instance.Current.Symbols.Length - 1);
		selectedPair = LevelManager.Instance.Current.Symbols[selectedIndex];
		Screen.Select(selectedPair);
	}

	public void Next()
	{
		selectedIndex++;
	}

	public void Previous()
	{
		selectedIndex--;
	}

	public void Transmit()
	{
		if (selectedPair == null) return;

		var transmission = Instantiate(Transmission, transform.position, transform.rotation);
		transmission.Symbol = selectedPair.Symbol;
	}
}
