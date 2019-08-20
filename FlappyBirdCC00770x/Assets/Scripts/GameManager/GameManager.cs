using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	private const string BIRD_ORDERNUMBER = "Bird order number";
	private const string BEST_SCORE = "Best score";
	private const string BREAKING_MODE = "Breaking mode";

	void Awake () {
		_MakeInstance ();
		_IsTheGameStartForTheFirstTime ();
	}

	void Update () {
		
	}
		
	void _MakeInstance(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void _IsTheGameStartForTheFirstTime(){
		if (!PlayerPrefs.HasKey ("IsTheGameStartForTheFirstTime")) {
			PlayerPrefs.SetInt (BIRD_ORDERNUMBER, 0);
			PlayerPrefs.SetInt (BEST_SCORE, 0);
			PlayerPrefs.SetInt (BREAKING_MODE, 0);
			PlayerPrefs.SetInt ("IsTheGameStartForTheFirstTime", 0);
		}
	}

	public int _GetSelectedBird (){
		return PlayerPrefs.GetInt (BIRD_ORDERNUMBER);
	}

	public void _SetSelectedBird (int birdOrderNumber){
		PlayerPrefs.SetInt (BIRD_ORDERNUMBER, birdOrderNumber);
	}

	public int _GetBestScore (){
		return PlayerPrefs.GetInt (BEST_SCORE);
	}

	public void _SetBestScore (int score){
		PlayerPrefs.SetInt (BEST_SCORE, score);
	}

	public int _GetBreakingMode (){
		return PlayerPrefs.GetInt (BREAKING_MODE);
	}

	public void _SetBreakingMode (int breakingMode){
		PlayerPrefs.SetInt (BREAKING_MODE, breakingMode);
	}
}
