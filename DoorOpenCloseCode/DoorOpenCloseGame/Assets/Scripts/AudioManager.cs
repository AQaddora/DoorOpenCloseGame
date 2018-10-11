using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	private static AudioSource audioSource;

	void Awake()
	{
		if (audioSource == null)
		{
			audioSource = GetComponent<AudioSource>();
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
