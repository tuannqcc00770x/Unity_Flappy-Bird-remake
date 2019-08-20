using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRepeat : MonoBehaviour {

	float speed = 2.5f;
	Vector3 startPosition; 

	void Start () {
		startPosition = transform.position;
	}

	void Update () {
		if (BirdController.instance.flag != null) {
			if (BirdController.instance.flag == 1) {
				Destroy(GetComponent<BackGroundRepeat>());
			}
		}

		transform.Translate ((new Vector3 (-1, 0, 0)) * speed * Time.deltaTime);
		if (transform.position.x < -28.5) {
			transform.position = startPosition;
		}
	}
}
