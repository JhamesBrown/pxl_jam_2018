using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_System_Script : MonoBehaviour {

    public GameObject musicSneaky;
    private AudioSource asMusicSneaky;
    public GameObject catIdleSFX;
    public GameObject catLeapSFX;
    public GameObject catHurtSFX;
    public GameObject catAlertSFX;
    public GameObject dogAlertSFX;
    public GameObject dogAttackSFX;
    private AudioSource[] asCatIdle;
    private AudioSource[] asCatLeap;
    private AudioSource[] asCatHurt;
    private AudioSource[] asCatAlert;
    private AudioSource[] asDogAlert;
    private AudioSource[] asDogAttack;
    private int totalCatIdle;
    private int totalCatLeap;
    private int totalCatHurt;
    private int totalCatAlert;
    private int totalDogAlert;
    private int totalDogAttack;


    // Use this for initialization
    void Start () {
        asMusicSneaky = musicSneaky.GetComponent<AudioSource>();
        asCatIdle = catIdleSFX.GetComponentsInChildren<AudioSource>();
        totalCatIdle = asCatIdle.Length;
        asCatLeap = catLeapSFX.GetComponentsInChildren<AudioSource>();
        totalCatLeap = asCatLeap.Length;
        asCatHurt = catHurtSFX.GetComponentsInChildren<AudioSource>();
        totalCatHurt = asCatHurt.Length;
        asCatAlert = catAlertSFX.GetComponentsInChildren<AudioSource>();
        totalCatAlert = asCatAlert.Length;
        asDogAlert = dogAlertSFX.GetComponentsInChildren<AudioSource>();
        totalDogAlert = asDogAlert.Length;
        asDogAttack = dogAttackSFX.GetComponentsInChildren<AudioSource>();
        totalDogAttack = asDogAttack.Length;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MUSICsneaky()
    {
        asMusicSneaky.Stop();
        asMusicSneaky.Play();
    }

    public void SFXcatIdle()
    {
        int random = Random.Range(0, totalCatIdle);
        asCatIdle[random].Play();
    }

    public void SFXcatLeap()
    {
        int random = Random.Range(0, totalCatLeap);
        asCatLeap[random].Play();
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
