using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;
	public float force = 50;
	public bool paused;
	public string mainMenu;
	public GameObject gameOverText;
	public bool gameOver = false;
	public Text scoreText;

	//public static PlayerController Instance { get; private set; }
	//public static int Counter { get; private set; }

	private int score = 0;

	void Awake (){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Start () {

		//Instance = this;
		paused = false;
	}
	
	void Update () {

//#if UNITY_STANDALONE || UNITY_WEBPLAYER
		if (Input.touchCount > 1) {
		
			//GetComponent<Rigidbody2D> ().AddForce (Vector2.up * force);
			Jump();
			//Counter++;
			//PlayGamesScript.AddScoreToLeaderboard (GPGSIds.leaderboard_leaderboard, Counter);
		}

		if (gameOver == true) {
			
		}

		if (gameOver == true && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
//#endif
	}

	public void BirdDied(){
		gameOverText.SetActive (true);
		gameOver = true;
	}
		

	public void Jump() {

		//GetComponent<Rigidbody2D> ().AddForce (Vector2.up * force);

		//if (Input.GetButtonDown ("Jump")) {

		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * force);
		Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

	}

	public void Pause () {

//		System.Console.WriteLine();
		Social.ReportProgress (GPGSIds.achievement_defying_time, 100, success => {
		}); 
		//achievement for pausing ^

		paused = !paused;

		if (paused) {

			Time.timeScale = 0;
		} else if (!paused) {

			Time.timeScale = 1;
		}
	}

	public void Home() {

		Application.LoadLevel (mainMenu);
	}

	public void BirdScored() {
	
		if (gameOver) {
			return;
		}
		score++;
		scoreText.text = "SCORE: " + score.ToString ();
	}
}
