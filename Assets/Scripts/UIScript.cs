using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour { //this script stores any achievements the user is able to unlock 
										//so it's easier to organize 

	public static UIScript Instance { get; private set; }

	void Start () {

		Instance = this;
	}
		
	public void Increment()
	{
		PlayGamesScript.IncrementAchievement (GPGSIds.achievement_icarus_lives, 100);
	}

	public void Unlock()
	{
		PlayGamesScript.UnlockAchievement (GPGSIds.achievement_defying_time);
		PlayGamesScript.UnlockAchievement (GPGSIds.achievement_bronze_aviator_license);
		PlayGamesScript.UnlockAchievement (GPGSIds.achievement_up_and_away);
	}

	public void ShowAchievements()
	{
		PlayGamesScript.ShowAchievementsUI ();
	}

	public void Leaderboards()
	{
		PlayGamesScript.ShowLeaderboardsUI ();
	}


}
