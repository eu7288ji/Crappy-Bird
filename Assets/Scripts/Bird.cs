using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	void Update () {

		if (gameObject.transform.position.y == 9) { //if the bird reaches a certain height on the Y axis, reset
			Application.LoadLevel (Application.loadedLevel);
		}

	}

	void OnCollisionEnter2D(Collision2D coll){ //activate the BirdDied method upon collision with any object
		PlayerController.instance.BirdDied();
	}
		
}
