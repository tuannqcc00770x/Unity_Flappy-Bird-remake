using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeat : MonoBehaviour {

	float speed = 2.5f;
	Vector3 startPosition; 

	void Start () {
		startPosition = transform.position;
	}
		
	void Update () {
		if (BirdController.instance.flag != null) {
			if (BirdController.instance.flag == 1) {
				Destroy(GetComponent<GroundRepeat>());
			}
		}
		transform.Translate ((new Vector3 (-1, 0, 0)) * speed * Time.deltaTime);
		if (transform.position.x < -21.39) {
			transform.position = startPosition;
		}
	}
}
