using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

	public Animator anim;
	void Start () {
	}

	void Update () {
		
	}

	public void _FadeToGamePlay() {
		anim.SetTrigger ("FadeOut");
		SceneManager.LoadScene ("GamePlay");
	}

	public void _FadeToMainMenu() {
		Time.timeScale = 1;
		anim.SetTrigger ("FadeOut");
		SceneManager.LoadScene ("MainMenu");
	}
}
