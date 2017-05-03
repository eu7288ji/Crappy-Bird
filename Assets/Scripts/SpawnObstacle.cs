using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour {

	public GameObject obstacle;
	float x = 0;

	void Update () {

		float y = Random.Range (13f, 9.0f);
		if (x < 50) {
			Instantiate (obstacle, new Vector3 (x * 9.0f, y, 0), Quaternion.identity);
			x++;
		}
		Debug.Log (x);
	}
}
