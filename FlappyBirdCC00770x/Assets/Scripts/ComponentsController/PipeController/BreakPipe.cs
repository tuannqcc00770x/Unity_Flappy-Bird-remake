using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPipe : MonoBehaviour {
	
	private Rigidbody2D myPipe;
	private float randomTime;
	private float randomVerlocityX;
	private float randomVerlocityY;
	private int probabilityBreaking;

	void Start () {
		StartCoroutine (_BreakPipe ());
	}

	void Update () {
	}

	IEnumerator _BreakPipe() {
		if (GameManager.instance._GetBreakingMode () == 1) {
			probabilityBreaking = Random.Range (0, 2);
			if (probabilityBreaking == 1) {
				randomTime = Random.Range (4f, 6f);
				randomVerlocityX = Random.Range (0.5f, 1f);
				randomVerlocityY = Random.Range (0.5f, 1f);
				yield return new WaitForSeconds (randomTime);
				myPipe = gameObject.AddComponent<Rigidbody2D> ();
				myPipe.velocity = new Vector2 (-randomVerlocityX, -randomVerlocityY);
			}
		}
	}
}
