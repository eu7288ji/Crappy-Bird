using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public float speed = 0;
	public float switchTime = 2;
	//public GameObject obstacle;
	//float x = 0;

	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
		InvokeRepeating ("Switch", 0, switchTime);
	}

	//void Update(){
		//float y = Random.Range (4.5f, 9.0f);
		//if (x < 10) {
			//Instantiate(obstacle, new Vector3(x * 4.0f, y, 0),Quaternion.identity);
		//}
		//Debug.Log(x);
	//}

	void Switch () {
		GetComponent<Rigidbody2D> ().velocity *= -1;
	}
}
