using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour {

	public GameObject obstacles;
	public bool gen = true;
	public float seconds = 0;
	public int updateCounter = 0;
	public int maxRange = 170;

	void Update() {

		if (gen) {

			gen = false;
			Invoke ("GenerateNewObstacle", Random.Range (4, 8));
		
		} else 
			updateCounter++;
		
			if (updateCounter >= maxRange) {

				gen = true;
				updateCounter = 0;
			}
		}

	void GenerateNewObstacle() {
		Instantiate (obstacles);
	}
}
