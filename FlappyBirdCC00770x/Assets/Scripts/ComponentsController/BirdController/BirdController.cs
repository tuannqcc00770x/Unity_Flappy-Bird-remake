using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

	private float bounceForce = 3.5f;
	private Rigidbody2D myBody;
	private Animator anim;
	[SerializeField]
	private AudioSource audioSource;
	[SerializeField]
	private AudioClip flyClip, pingClip, diedClip;
	private bool isAlive;
	private bool didFlap;	
	public float flag = 0;
	public static BirdController instance;
	private GameObject initGreenPipe, initBrownPipe;
	public int score = 0;


	void Start () {
		
	}

	void Update () {
		
	}

	void FixedUpdate(){
		_BirdMoveMent ();
	}

	void Awake (){
		_MakeInstance ();
		isAlive = true;
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		initGreenPipe = GameObject.Find ("InitGreenPipe");
		initBrownPipe = GameObject.Find ("InitBrownPipe");
	}

	void _BirdMoveMent(){
		if (isAlive) {
			if (didFlap) {
				didFlap = false;
				myBody.velocity = new Vector2 (myBody.velocity.x, bounceForce);
				audioSource.PlayOneShot (flyClip);
			}
		}

		if (isAlive) {
			if (Input.GetMouseButtonDown (0)) {
				myBody.velocity = new Vector2 (myBody.velocity.x, bounceForce);
				audioSource.PlayOneShot (flyClip);
			}
		}

		if (myBody.velocity.y > 0) {
			float angle = 0;
			angle = Mathf.Lerp (0, 90, myBody.velocity.y / 7);
			transform.rotation = Quaternion.Euler (0, 0, angle);
		} else if (myBody.velocity.y == 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} 
		if (myBody.velocity.y < 0) {
			float angle = 0;
			angle = Mathf.Lerp (0, -90, -myBody.velocity.y / 7);
			transform.rotation = Quaternion.Euler (0, 0, angle);
		}
	}

	public void _TouchButton() {
		didFlap = true;
	}

	void OnTriggerEnter2D (Collider2D target){
		if (target.tag == "PipeHolder") {
			audioSource.PlayOneShot (pingClip);
			score++;
			if (GamePlayController.instance != null) {
				GamePlayController.instance._SetScore (score);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D target){
		if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground" || target.gameObject.tag == "BreakPipe") {
			flag = 1;
			if (isAlive) {
				isAlive = false;
				audioSource.PlayOneShot (diedClip);
				anim.SetTrigger("Died");
				Destroy (initGreenPipe);
				Destroy (initBrownPipe);
			}
			if (GamePlayController.instance != null) {
				GamePlayController.instance._BirdDiedShowPanel (score);
			}
		}
	}

	void _MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}
}
