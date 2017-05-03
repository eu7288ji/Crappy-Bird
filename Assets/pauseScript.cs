using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour {

	public bool paused;

	// Use this for initialization
	public void Start () {

		paused = false;
	}
	
	// Update is called once per frame
	public void Pause () {

		System.Console.WriteLine();

		if (Input.touchCount > 0) {
			
			paused = !paused;
		}
		if (paused) {

			Time.timeScale = 0;
		} else if (!paused) {
			
			Time.timeScale = 1;
		}
	}
}
