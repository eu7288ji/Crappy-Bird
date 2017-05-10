using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;
	public float force = 50;
	public bool paused;
	public string mainMenu;
	public GameObject gameOverText;
	public bool gameOver = false;
	public Text scoreText;
	public int HighestScoreCompleted{ set; get;}
	private int score = 0;

	void Awake (){
		if (instance == null) {
			instance = this;
		} else if (instance != this) { //if more/less than 1 instance of character, destroy it
			Destroy (gameObject);
		}
	}

	void Start () {
		
		paused = false;
	}
	
	void Update () {

		if (Input.touchCount > 1) { //if user taps with 1 finger on specified button, player activates jump method
		
			Jump();
		}

		if (gameOver == true && Input.GetMouseButtonDown (0)) { //if player is dead and they tap the screen
			
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); //load the active scene again
		}
	}

	public void BirdDied(){
		
		gameOverText.SetActive (true); //game over text
		gameOver = true;

		if (gameOver == true) {
			RestartGame (); //sends leaderboard information to GPS 
		}
	}
		

	public void Jump() {

		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * force); //applies 2D force upward
		Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition; //on touch position of specified point

		Social.ReportProgress (GPGSIds.achievement_up_and_away, 100, success => {
		});
		//achievement for flapping wings at least once
	}

	public void Pause () {

		Social.ReportProgress (GPGSIds.achievement_defying_time, 100, success => {
		}); 
		//achievement for pausing ^

		paused = !paused;

		if (paused) {

			Time.timeScale = 0; //when paused, time stops
		} else if (!paused) {

			Time.timeScale = 1; //resumes
		}
	}

	public void Home() {

		Application.LoadLevel (mainMenu); //loads in scene with the specified name (in this case, "mainMenu")
	}

	public void BirdScored() {
	
		if (gameOver) {
			return;
		}
		score++; //through each obstacle, add 1 point
		scoreText.text = "SCORE: " + score.ToString ();

		if (score == 10) {
			Social.ReportProgress (GPGSIds.achievement_bronze_aviator_license, 100, success => {
			});	
			//achievement for scoring 10 points in one run^
		}

		PlayGamesPlatform.Instance.IncrementAchievement (GPGSIds.achievement_icarus_lives, 1, success => {
		});	}
	//when the player passes through obstacle, adds 1 single point to the incremental achievement (in my case a total of 100 needed to unlock)
	
	public void RestartGame()
	{
		PlayGamesScript.AddScoreToLeaderboard (GPGSIds.leaderboard_leaderboard, score);
		//report back to leaderboard system if the score is greater than 1
	}
}
