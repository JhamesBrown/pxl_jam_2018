using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageManager : MonoBehaviour {

    //This Shit right here knows what is going on
    public enum currentGameState { Main, Win, Lose, Game, Credits};
    private Menu_System_Script reachMenuSystemScript;

    public bool catCanMove;

	void Start ()
    {
        reachMenuSystemScript = Menu_System_Script.FindObjectOfType<Menu_System_Script>();

    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void ChangeMenus(currentGameState menuNow)
    {

        catCanMove = (reachMenuSystemScript.menuState != 3)? false : true;

        


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
