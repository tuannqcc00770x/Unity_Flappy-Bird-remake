using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	public AudioSource audioSource;
	public static SoundController instance;

	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	void Update () {
	}
}
