using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage_goal : MonoBehaviour {



    private stageManager reachStageManager;
    private Audio_System_Script reachAudioSystemScript;
    
    void Start () {
        reachStageManager = stageManager.FindObjectOfType<stageManager>();
        reachAudioSystemScript = Audio_System_Script.FindObjectOfType<Audio_System_Script>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void CheckIfLast()
    {
        int sceneAmount = SceneManager.sceneCountInBuildSettings - 1;
        int currentScene = SceneManager.GetActiveScene().buildIndex;



        if (currentScene == sceneAmount)
        {
            reachAudioSystemScript.SFXcatSleep();
            reachStageManager.ChangeMenus(stageManager.currentGameState.Win);
            SceneManager.LoadScene(0);
        }
        else
        {
            // int sceneindex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }


}
