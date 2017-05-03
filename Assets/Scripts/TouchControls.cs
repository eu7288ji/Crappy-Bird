using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

	private PlayerController thePlayer;

	void Start () {

		thePlayer = FindObjectOfType<PlayerController> ();
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
