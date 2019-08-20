using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;
	[SerializeField]
	private GameObject[] birds;
	[SerializeField]
	private GameObject[] medals;
	[SerializeField]
	private Button instructionButton;
	[SerializeField]
	private Text scoreText, endScoreText, bestScoreText, title;
	[SerializeField]
	private GameObject gamePlayPanel, pauseButton;
	private bool isPauseGame = false;

	void Start () {
		
	}

	void Update () {
		
	}

	void Awake(){
		_MakeInstance ();
		_ShowBird ();
		_HideObject ();
		Time.timeScale = 0;
	}
		
	public void _InstructionButton(){
		Time.timeScale = 1;
		instructionButton.gameObject.SetActive (false);
		scoreText.gameObject.SetActive (true);
		pauseButton.gameObject.SetActive (true);
	}
		
	void _MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void _ShowBird(){
		if (GameManager.instance._GetSelectedBird () == 0) {
			birds [0].SetActive (true);
			birds [1].SetActive (false);
			birds [2].SetActive (false);
		} else if (GameManager.instance._GetSelectedBird () == 1) {
			birds [0].SetActive (false);
			birds [1].SetActive (true);
			birds [2].SetActive (false);
		} else if (GameManager.instance._GetSelectedBird () == 2) {
			birds [0].SetActive (false);
			birds [1].SetActive (false);
			birds [2].SetActive (true);
		}
	}

	public void _SetScore(int score) {
		scoreText.text = "" + score;
	}

	public void _BirdDiedShowPanel(int score) {
		isPauseGame = false;
		scoreText.gameObject.SetActive (false);
		gamePlayPanel.SetActive (true);
		title.text = "Game Over";
		endScoreText.text = ""+ score;
		if (score > GameManager.instance._GetBestScore ()) {
			GameManager.instance._SetBestScore (score);
		}
		bestScoreText.text = GameManager.instance._GetBestScore ()+"";
		_ShowMedal (score);
	}

	public void _HideObject() {
		gamePlayPanel.SetActive (false);
		scoreText.gameObject.SetActive (false);
		pauseButton.gameObject.SetActive (false);
	}

	public void _PauseShowPanel(){
		if (BirdController.instance.flag != null) {
			if (BirdController.instance.flag == 0) {
				Time.timeScale = 0;
				isPauseGame = true;
				scoreText.gameObject.SetActive (false);
				gamePlayPanel.SetActive (true);
				title.text = "";
				endScoreText.text = ""+ BirdController.instance.score;
				bestScoreText.text = GameManager.instance._GetBestScore ()+"";
				_ShowMedal (GameManager.instance._GetBestScore ());
			}
		}
	}

	public void _RestartAndResume(){
		if (isPauseGame) {
			Time.timeScale = 1;
			scoreText.gameObject.SetActive (true);
		} else {
			SceneManager.LoadScene ("GamePlay");
		}
		gamePlayPanel.SetActive (false);
	}

	private void _ShowMedal(int score){
		if (score <= 20) {
			medals [0].SetActive (true);
			medals [1].SetActive (false);
			medals [2].SetActive (false);
		} else if (score > 20 && score < 40) {
			medals [0].SetActive (false);
			medals [1].SetActive (true);
			medals [2].SetActive (false);
		} else if (score > 40) {
			medals [0].SetActive (false);
			medals [1].SetActive (false);
			medals [2].SetActive (true);
		}
	}
}
