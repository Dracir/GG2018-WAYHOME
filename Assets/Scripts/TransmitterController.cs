﻿using UnityEngine;

public class TransmitterController : CachedBehaviour<TransmitterController>
{
	public KeyCode Next = KeyCode.X;
	public KeyCode Previous = KeyCode.Z;
	public KeyCode Transmit = KeyCode.UpArrow;
	public float Cooldown = 1f;
	public Transmitter Transmitter;

	public float CooldownRatio
	{
		get { return Mathf.Clamp01((Cooldown - transmitCounter) / Cooldown); }
	}

	float transmitCounter;

	void Update()
	{
		if (transmitCounter > 0f)
			transmitCounter -= Time.deltaTime;
		else if (Input.GetKeyDown(Transmit))
		{
			Transmitter.Transmit();
			transmitCounter = Cooldown;
		}

		if (Input.GetKeyDown(Next)) Transmitter.Next();
		else if (Input.GetKeyDown(Previous)) Transmitter.Previous();
	}
}