using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour { //this script simply assigns each button to the relevant method for touch button support

	private PlayerController thePlayer;

	void Start () {

		thePlayer = FindObjectOfType<PlayerController> (); //so I don't have to refer back to PlayerController in every method
	}

	public void Jump() {

		thePlayer.Jump ();
	}

	public void Pause() {

		thePlayer.Pause ();
	}

	public void Home() {

		thePlayer.Home ();
	}
}
