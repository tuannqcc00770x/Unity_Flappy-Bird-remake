using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour {

	private float speed = 2.5f;

	void Start () {
		
	}

	void Update () {
		if (BirdController.instance.flag != null) {
			if (BirdController.instance.flag == 1) {
				Destroy(GetComponent<PipeHolder>());
			}
		}
		_PipeMovement ();
	}

	void _PipeMovement(){
		Vector3 temp = transform.position;
		temp.x -= speed * Time.deltaTime;
		transform.position = temp;
	}

	void OnTriggerEnter2D ( Collider2D target){
		if (target.tag == "Destroy") {
			Destroy (gameObject);
		}
	}
}
