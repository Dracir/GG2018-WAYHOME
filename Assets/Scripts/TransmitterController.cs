using System.Linq;
using UnityEngine;

public class TransmitterController : CachedBehaviour<TransmitterController>
{
	public KeyCode Next = KeyCode.X;
	public KeyCode Previous = KeyCode.Z;
	public KeyCode[] Transmit;
	public float Cooldown = 1f;
	public Transmitter Transmitter;

	public float CooldownRatio
	{
		get { return Mathf.Clamp01((Cooldown - transmitCounter) / Cooldown); }
	}

	float transmitCounter;

	void Update()
	{
		if (LevelManager.Instance.HasFailed) return;

		if (transmitCounter > 0f)
			transmitCounter -= Time.deltaTime;
		else if (Transmit.Any(key => Input.GetKeyDown(key)))
		{
			Transmitter.Transmit();
			transmitCounter = Cooldown;
		}

		if (Input.GetKeyDown(Next)) Transmitter.Next();
		else if (Input.GetKeyDown(Previous)) Transmitter.Previous();
	}
}
