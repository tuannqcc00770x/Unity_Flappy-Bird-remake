using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	public static MainMenuController instance;
	[SerializeField]
	private GameObject[] birds;

	[SerializeField]
	private Text modeText;

	void Awake (){
		_MakeInstance ();
		_ShowBird ();
		_ShowMode ();
	}

	void Start () {
		
	}

	void Update () {
		
	}
		
	void _MakeInstance(){
		if (instance = null) {
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

	public void _ChooseBird(){
		if (birds [0].activeSelf) {
			birds [0].SetActive (false);
			birds [1].SetActive (true);
			birds [2].SetActive (false);
			GameManager.instance._SetSelectedBird (1);
		} else if (birds [1].activeSelf) {
			birds [0].SetActive (false);
			birds [1].SetActive (false);
			birds [2].SetActive (true);
			GameManager.instance._SetSelectedBird (2);
		} else if (birds [2].activeSelf) {
			birds [0].SetActive (true);
			birds [1].SetActive (false);
			birds [2].SetActive (false);
			GameManager.instance._SetSelectedBird (0);
		}
	}

	public void _ChooseMode() {
		if (modeText.text.Equals ("ON")) {
			modeText.text = "OFF";
			GameManager.instance._SetBreakingMode (0);
		} else if  (modeText.text.Equals ("OFF")) {
			modeText.text = "ON";
			GameManager.instance._SetBreakingMode (1);
		}
	}

	public void _ShowMode(){
		if (GameManager.instance._GetBreakingMode () == 1) {
			modeText.text = "ON";
		} else {
			modeText.text = "OFF";
		}
	}

}
