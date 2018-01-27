using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager> {


	[Space]
	public AudioClip[] CreatureDie;
	public AudioClip[] CreatureHappy;
	public AudioClip[] CreatureSpawn;


	public void Play(AudioClip[] aRandomClipIn, Vector3 position, ulong delay = 0){
		if(aRandomClipIn.Length == 0)
		{
			Debug.LogError("Tu veux faire jouer un clip array qui a rien ! ! THE WHAT ?");
			return;
		}
		var clip = aRandomClipIn[Random.Range(0,aRandomClipIn.Length)];

		Play(clip,position,delay);
	}
	public void Play(AudioClip clip, Vector3 position, ulong delay = 0){
		if(clip == null) 
		{
			Debug.LogWarning("Tu veux jouer un son null :/");
			return;
		}
			
		GameObject newGo = new GameObject(clip.name);
		newGo.transform.position = position;
		newGo.transform.parent = this.transform;

		var source = newGo.AddComponent<AudioSource>();
		source.clip = clip;
		source.pitch = Random.Range(0.9f,1.1f);

		source.Play(delay);

		newGo.AddComponent<DestroyOnAudioDone>();
	}
}

public class DestroyOnAudioDone : MonoBehaviour {

	bool audioStarted;

	AudioSource source;

	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	void Update () {
		if(!audioStarted && source.isPlaying)
			audioStarted = true;

		if(audioStarted && !source.isPlaying)
			Destroy(gameObject);
	}
}