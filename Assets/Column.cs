using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour { //this adds the trigger for the point system, so each time the tigger is passed, player activates BirdScored

	private void OnTriggerEnter2D (Collider2D other){
		if (other.GetComponent<Bird> () != null) {
			PlayerController.instance.BirdScored ();
		}
	}
}
