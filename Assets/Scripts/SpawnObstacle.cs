using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour { //obstacle spawning script where I have a set number of obstacles (because PoolingScript didn't work...)

	public GameObject obstacle;
	float x = 0;

	void Update () {

		float y = Random.Range (13f, 9.0f); //spawns obstacle at a set random height range
		if (x < 50) { //number of obstacles I have set to spawn
			Instantiate (obstacle, new Vector3 (x * 9.0f, y, 0), Quaternion.identity);
			x++;
		}
		Debug.Log (x); //tells console that they spawned correcly
	}
}
