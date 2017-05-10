using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour { //main menu functions for new game and quit buttons

	public string startLevel;

	public void NewGame() {

		Application.LoadLevel (startLevel); //on button press, loads scene with specified name (in this case, "startLevel")
	}

	public void QuitGame() {

		Application.Quit (); //exit 
	}
}
