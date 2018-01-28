using UnityEngine;
using UnityEngine.UI;

public class ImageAnimator : CachedBehaviour<ImageAnimator>
{
	public Sprite[] Sprites;
	public float Frequency = 5f;
	public Image Image;

	float next;
	int index;

	protected override void OnEnable()
	{
		base.OnEnable();

		next = Time.time;
	}

	void Update()
	{
		UpdateSprite();
	}

	void FixedUpdate()
	{
		UpdateSprite();
	}

	void LateUpdate()
	{
		UpdateSprite();
	}

	void UpdateSprite()
	{
		if (Frequency != 0 && next <= Time.time)
		{
			next += Mathf.Min(1f / Mathf.Abs(Frequency), 0.2f);
			index += (int)Mathf.Sign(Frequency);
			if (index < 0) index += Sprites.Length;
			Image.sprite = Sprites[index % Sprites.Length];
		}
	}
}
