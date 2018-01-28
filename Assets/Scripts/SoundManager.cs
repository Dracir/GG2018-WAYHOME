using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
	[Space]
	public AudioClip[] Clips;

	Dictionary<string, AudioClip> nameToClip = new Dictionary<string, AudioClip>();

	protected override void Awake()
	{
		base.Awake();

		nameToClip = Clips.ToDictionary(clip => clip.name);
	}

	public void Play(string sound, Vector3? position = null, float volume = 1f, float pitch = 1f, ulong delay = 0)
	{
		if (nameToClip.ContainsKey(sound))
			Play(nameToClip[sound], position ?? ZeCamera.Instance.transform.position, volume, pitch, delay);
	}

	public void Play(AudioClip[] aRandomClipIn, Vector3 position, ulong delay = 0)
	{
		if (aRandomClipIn.Length == 0)
		{
			Debug.LogError("Tu veux faire jouer un clip array qui a rien ! ! THE WHAT ?");
			return;
		}
		var clip = aRandomClipIn[Random.Range(0, aRandomClipIn.Length)];

		Play(clip, position, delay);
	}

	public void Play(AudioClip clip, Vector3 position, float volume = 1f, float pitch = 1f, ulong delay = 0)
	{
		if (clip == null)
		{
			Debug.LogWarning("Tu veux jouer un son null :/");
			return;
		}

		GameObject newGo = new GameObject(clip.name);
		newGo.transform.position = position;
		newGo.transform.parent = this.transform;

		var source = newGo.AddComponent<AudioSource>();
		source.pitch = pitch;
		source.clip = clip;
		source.volume = volume;
		source.Play(delay);

		newGo.AddComponent<DestroyOnAudioDone>();
	}
}

public class DestroyOnAudioDone : MonoBehaviour
{

	bool audioStarted;

	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (!audioStarted && source.isPlaying)
			audioStarted = true;

		if (audioStarted && !source.isPlaying)
			Destroy(gameObject);
	}
}