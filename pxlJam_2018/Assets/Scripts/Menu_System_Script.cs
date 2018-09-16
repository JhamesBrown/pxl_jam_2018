using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_System_Script : MonoBehaviour
{

    public int menuState;
    public int menuStateBefore;
    public GameObject PanelMainMenu;
    public GameObject PanelWinMenu;
    public GameObject PanelLoseMenu;
    public GameObject PanelGameMenu;
    public GameObject PanelCreditsMenu;
    private Audio_System_Script reachAudioSystemScript;



    static Menu_System_Script instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
    }





    void Start()
    {
        reachAudioSystemScript = Audio_System_Script.FindObjectOfType<Audio_System_Script>();
        menuState = 0;
        menuStateBefore = 100;
    }

    void Update()// Update is called once per frame
    {

        if (menuState != menuStateBefore)//If the menu state changed, activate the appropriate menus
        {
            MenuPanelController();//turn panels on/off correctly
            menuStateBefore = menuState;
        }
    }

    public void MenuGame()//main menu screen
    {
        menuState = 0;
        reachAudioSystemScript.MUSIC(menuState);
    }

    public void WinGame()//win result screen
    {
        menuState = 1;
        reachAudioSystemScript.MUSIC(menuState);
        reachAudioSystemScript.SFXcatSleep();
    }

    public void LoseGame()//lose result screen
    {
        menuState = 2;
        reachAudioSystemScript.MUSIC(menuState);
        reachAudioSystemScript.SFXcatSleep();
    }

    public void QuitToCredits()//open credits screen on way out
    {
        menuState = 4;
        reachAudioSystemScript.MUSIC(menuState);
    }

    public void PlayGame()//in-game screen
    {
        menuState = 3;
        reachAudioSystemScript.stopAll();
        reachAudioSystemScript.MUSIC(menuState);
    }

    public void QuitGame()//quit game
    {
        Debug.Log("Quit Application");
        Application.Quit();
    }

    public void MenuPanelController()//which menu should be active at any time
    {
        if (menuState == 0) // Main menu
        {
            //Debug.Log("Main Menu");
            PanelMainMenu.SetActive(true);
            PanelWinMenu.SetActive(false);
            PanelLoseMenu.SetActive(false);
            PanelGameMenu.SetActive(false);
            PanelCreditsMenu.SetActive(false);
        }
        else if (menuState == 1) // Win
        {
            //Debug.Log("Win Menu");
            PanelMainMenu.SetActive(false);
            PanelWinMenu.SetActive(true);
            PanelLoseMenu.SetActive(false);
            PanelGameMenu.SetActive(false);
            PanelCreditsMenu.SetActive(false);
        }
        else if (menuState == 2) // Lose
        {
            //Debug.Log("Lose Menu");
            PanelMainMenu.SetActive(false);
            PanelWinMenu.SetActive(false);
            PanelLoseMenu.SetActive(true);
            PanelGameMenu.SetActive(false);
            PanelCreditsMenu.SetActive(false);
        }
        else if (menuState == 3)  // In game
        {
            //Debug.Log("Game Menu");
            PanelMainMenu.SetActive(false);
            PanelWinMenu.SetActive(false);
            PanelLoseMenu.SetActive(false);
            PanelGameMenu.SetActive(true);
            PanelCreditsMenu.SetActive(false);
        }
        else if (menuState == 4)  // Credits
        {
            //Debug.Log("Credits Menu");
            PanelMainMenu.SetActive(false);
            PanelWinMenu.SetActive(false);
            PanelLoseMenu.SetActive(false);
            PanelGameMenu.SetActive(false);
            PanelCreditsMenu.SetActive(true);
        }
    }
}
