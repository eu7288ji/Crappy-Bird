using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float speed = 2;
	//float playerHeight = GameObject.transform.position.y;

	void Start () {

		//GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;

	}
	
	void Update () {

		if (gameObject.transform.position.y == 9) {
			Application.LoadLevel (Application.loadedLevel);
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		PlayerController.instance.BirdDied();
	}
		
}
