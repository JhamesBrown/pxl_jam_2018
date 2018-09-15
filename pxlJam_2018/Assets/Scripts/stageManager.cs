using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageManager : MonoBehaviour {

    //This Shit right here knows what is going on
    public enum currentGameState { Main, Win, Lose, Game, Credits};
    private Menu_System_Script reachMenuSystemScript;

	void Start ()
    {
        reachMenuSystemScript = Menu_System_Script.FindObjectOfType<Menu_System_Script>();

    }

	void Update ()
    {
		
	}

    public void ChangeMenus(currentGameState menuNow)
    {
        Cursor.visible = (menuNow != currentGameState.Game)?true:false;
        if (menuNow == currentGameState.Main)
        {
            reachMenuSystemScript.MenuGame();//menuState = 0
        }
        else if (menuNow == currentGameState.Win)
        {
            reachMenuSystemScript.WinGame();//menuState = 1
        }
        else if (menuNow == currentGameState.Lose)
        {
            reachMenuSystemScript.LoseGame();//menuState = 2
        }
        else if (menuNow == currentGameState.Game)
        {
            reachMenuSystemScript.PlayGame();//menuState = 3
        }
        else if (menuNow == currentGameState.Credits)
        {
            reachMenuSystemScript.QuitToCredits();//menuState = 4
        }
    }

}
