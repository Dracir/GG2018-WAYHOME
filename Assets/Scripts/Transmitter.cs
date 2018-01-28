using UnityEngine;

public class Transmitter : CachedBehaviour<Transmitter>
{
	public Transmission Transmission;
	public Screen Screen;

	int selectedIndex;
	Symbol selectedSymbol;

	void Update()
	{
		Select(selectedIndex);
	}

	public void Select(int index)
	{
		if (LevelManager.Instance.Current == null) return;

		selectedIndex = Mathf.Clamp(index, 0, LevelManager.Instance.Current.Symbols.Length - 1);
		selectedSymbol = LevelManager.Instance.Current.Symbols[selectedIndex];
		Screen.Select(selectedSymbol);
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
		if (selectedSymbol == Symbol.None) return;

		var transmission = Instantiate(Transmission, transform.position, transform.rotation);
		transmission.Selected = selectedSymbol;
		SoundManager.Instance.Play("transmit", volume: 0.25f, pitch: 2f);
	}
}
