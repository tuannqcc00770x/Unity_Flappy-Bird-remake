using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InitPipe : MonoBehaviour {
	[SerializeField]
	private GameObject pipeHolder;

	void Start () {
		StartCoroutine (_Init ());
	}

	void Update () {
		
	}

	IEnumerator _Init(){
		yield return new WaitForSeconds (7f/2.5f);
		Vector3 temp = pipeHolder.transform.position;
		temp.y =UnityEngine.Random.Range (-1.75f, 1.75f);
		Instantiate (pipeHolder, temp, Quaternion.identity);
		StartCoroutine (_Init ());
	}
}
