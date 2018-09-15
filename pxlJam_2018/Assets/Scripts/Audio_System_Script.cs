using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_System_Script : MonoBehaviour {

    public GameObject music;
    public GameObject catIdleSFX;
    public GameObject catLeapSFX;
    public GameObject catHurtSFX;
    public GameObject catAlertSFX;
    public GameObject catSleepSFX;
    public GameObject dogAlertSFX;
    public GameObject dogAttackSFX;
    private AudioSource[] asMusic;
    private AudioSource[] asCatIdle;
    private AudioSource[] asCatLeap;
    private AudioSource[] asCatHurt;
    private AudioSource[] asCatAlert;
    private AudioSource[] asCatSleep;
    private AudioSource[] asDogAlert;
    private AudioSource[] asDogAttack;
    private int totalCatIdle;
    private int totalCatLeap;
    private int totalCatHurt;
    private int totalCatAlert;
    private int totalCatSleep;
    private int totalDogAlert;
    private int totalDogAttack;

    public GameObject all;
    private AudioSource[] asAll;

    // Use this for initialization
    void Start () {
        asMusic = music.GetComponentsInChildren<AudioSource>();
        asCatIdle = catIdleSFX.GetComponentsInChildren<AudioSource>();
        totalCatIdle = asCatIdle.Length;
        asCatLeap = catLeapSFX.GetComponentsInChildren<AudioSource>();
        totalCatLeap = asCatLeap.Length;
        asCatHurt = catHurtSFX.GetComponentsInChildren<AudioSource>();
        totalCatHurt = asCatHurt.Length;
        asCatAlert = catAlertSFX.GetComponentsInChildren<AudioSource>();
        totalCatAlert = asCatAlert.Length;
        asCatSleep = catSleepSFX.GetComponentsInChildren<AudioSource>();
        totalCatSleep = asCatSleep.Length;
        asDogAlert = dogAlertSFX.GetComponentsInChildren<AudioSource>();
        totalDogAlert = asDogAlert.Length;
        asDogAttack = dogAttackSFX.GetComponentsInChildren<AudioSource>();
        totalDogAttack = asDogAttack.Length;

        asAll = all.GetComponentsInChildren<AudioSource>();
        MUSIC(0);//Start with menu music
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MUSIC(int menuMusic)
    {
        stopMusic();
//        int random = Random.Range(0, totalMusic);//remove me after testing
        asMusic[menuMusic].Play();//needs to know the menu state. music follows same array order.
    }

    public void stopMusic()//stop tracks so that new music for each menu can play without overlap
    {
        foreach (AudioSource audioS in asMusic)
        {
            audioS.Stop();
        }
    }

    public void stopAll()//stop tracks so that new music for each menu can play without overlap
    {
        foreach (AudioSource audioS in asAll)
        {
            audioS.Stop();
        }
    }

    public void SFXcatIdle()
    {
        int random = Random.Range(0, totalCatIdle);
        asCatIdle[random].Play();
    }

    public void SFXcatLeap()
    {
        StopSFXcatLeap();
        int random = Random.Range(0, totalCatLeap);//pick a random audio source in the the array of cat leap SFX
        float currentSFXLength = asCatLeap[random].clip.length;//find out how long the SFX plays for
        asCatLeap[random].Play();

    }

    //IEnumerator playSFXcatLeapSequentially()
    //{
    //    yield return null;

    //    //1.Loop through each AudioClip
    //    for (int i = 0; i < asCatLeap[].Length; i++)
    //    {
    //        //2.Assign current AudioClip to audiosource
    //        asCatLeap[].clip = asCatLeap[i];

    //        //3.asCatLeap Audio
    //        acCatLeap[].Play();

    //        //4.Wait for it to finish playing
    //        while (asCatLeap.isPlaying)
    //        {
    //            yield return null;
    //        }

    //        //5. Go back to #2 and play the next audio in the adClips array
    //    }
    //}

    public void StopSFXcatLeap()
    {
        foreach (AudioSource audioS in asCatLeap)
        {
            audioS.Stop();
        }
    }

    public void SFXcatHurt()
    {
        int random = Random.Range(0, totalCatHurt);
        asCatHurt[random].Play();
    }

    public void SFXcatAlert()
    {
        int random = Random.Range(0, totalCatAlert);
        asCatAlert[random].Play();
    }

    public void SFXcatSleep()
    {
        int random = Random.Range(0, totalCatSleep);
        asCatSleep[random].Play();
    }

    public void SFXdogAlert()
    {
        int random = Random.Range(0, totalDogAlert);
        asDogAlert[random].Play();
    }

    public void SFXdogAttack()
    {
        int random = Random.Range(0, totalDogAttack);
        asDogAttack[random].Play();
    }
}
