using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine;

public class PlayGamesScript : MonoBehaviour { //this script stores the functions for login and google play
											   //services achievement unlocks and leaderboards to make it
											   //easier to call within other scripts

	void Start () {

		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.Activate (); //this initializes Google Play Services to run within the app

		SignIn ();
	}

	void SignIn()
	{

		Social.localUser.Authenticate (success => { //signs user into local device
		}); 
	}

	#region Achievements
	public static void UnlockAchievement(string id)
	{

		Social.ReportProgress (id, 100, success => { //reports 100% completion on unlock
		});
	}

	public static void IncrementAchievement(string id, int stepsToIncrement)
	{
		//increment takes however many steps the developer has defined 
		PlayGamesPlatform.Instance.IncrementAchievement (id, stepsToIncrement, success => {
		});
	}

	public static void ShowAchievementsUI()
	{
		Social.ShowAchievementsUI (); //show Achievement UI on assigned button press
	}
	#endregion /Achievements

	#region Leaderboards
	public static void AddScoreToLeaderboard(string leaderboardId, long score)
	{

		Social.ReportScore (score, leaderboardId, success => { //takes highest current score and reports to GPS
		});
	}

	public static void ShowLeaderboardsUI()
	{
		Social.ShowLeaderboardUI (); //show Leaderboard UI on assigned button press
	}
	#endregion /Leaderboards
}
