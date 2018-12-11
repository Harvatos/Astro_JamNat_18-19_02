using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObject : MonoBehaviour {

	public static SoundObject instance;

	void Awake ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}


	}

	void Start()
	{
		AkSoundEngine.PostEvent("Game_Start", gameObject);
	}
}
