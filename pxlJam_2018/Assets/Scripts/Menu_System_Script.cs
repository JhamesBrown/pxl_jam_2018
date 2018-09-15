﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_System_Script : MonoBehaviour {

    public int menuState;
    public int menuStateBefore;
    public GameObject PanelMainMenu;
    public GameObject PanelWinMenu;
    public GameObject PanelLoseMenu;
    public GameObject PanelGameMenu;
    public GameObject PanelCreditsMenu;

    void Start ()
    {
        menuState = 0;
        menuStateBefore = 100;

    }

    void Update ()// Update is called once per frame
    {

        if (menuState != menuStateBefore)//If the menu state changed, activate the appropriate menus
        {
            MenuPanelController();//turn panels on/off correctly
            menuStateBefore = menuState;
        }
    }

    public void PlayGame()//in-game screen
    {
        menuState = 3;
    }

    public void WinGame()//win result screen
    {
        menuState = 1;
    }

    public void LoseGame()//lose result screen
    {
        menuState = 2;
    }

    public void QuitToCredits()//open credits screen on way out
    {
        menuState = 4;
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