using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSize : MonoBehaviour {

	void Start () {
		_InitSize ();
	}

	void Update () {
		
	}

	void _InitSize() {
		Vector3 temp = transform.position;
		temp.y = Random.Range (-1.75f, 1.75f);
		transform.position = temp;
	}
}
