using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnTriggerEnter (Collider col) {

		if (col.gameObject.tag == "Limit") {

			Debug.Log ("You flew too high!");
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
