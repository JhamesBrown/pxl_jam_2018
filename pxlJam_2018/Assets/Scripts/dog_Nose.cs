using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_Nose : MonoBehaviour {

    private Audio_System_Script reachAudioSystemScript;

    // Use this for initialization
    void Start () {
        reachAudioSystemScript = Audio_System_Script.FindObjectOfType<Audio_System_Script>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Cat")
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                reachAudioSystemScript.SFXdogAlert();
            }
            else
            {
                reachAudioSystemScript.SFXcatLeap();
            }

        }
    }
}
