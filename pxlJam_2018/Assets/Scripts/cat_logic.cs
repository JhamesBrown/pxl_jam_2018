using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_logic : MonoBehaviour
{

    public enum states { idle, following, dead };
    public states currentState;
    public Transform pointer;
    public float attentionDistance = 3;
    private int framesNotMoving;
    public int framesCatIdle = 200;
    public bool isMoving;
    public float movementTolerance = 0.01f;
    private Vector2 prevFramePos;

    private states m_previousState;

    private followPointer m_followPoint;
    private stageManager reachStageManager;
    private Audio_System_Script reachAudioSystemScript;
    int layerMask;

    void Start()
    {
        currentState = states.idle;
        m_followPoint = GetComponent<followPointer>();
        reachStageManager = stageManager.FindObjectOfType<stageManager>();
        reachAudioSystemScript = Audio_System_Script.FindObjectOfType<Audio_System_Script>();
        layerMask = 0 << 9;
    }


    void FixedUpdate()
    {
        isMoving = isCatMoving();

        if (isMoving)
        {
            framesNotMoving = 0;
        }
        else {
            framesNotMoving++;
        }

        if (framesNotMoving >= framesCatIdle)
        {
            catDidNotMove();
        }


        if (reachStageManager.catCanMove)
        {
            Debug.Log("can MOve");
        
            RaycastHit2D hit = Physics2D.Raycast(transform.position, pointer.position - transform.position, Vector2.Distance(transform.position, pointer.transform.position), layerMask);
            if (Vector2.Distance(transform.position, pointer.transform.position) < attentionDistance && hit.collider == null)
                currentState = states.following;
            else
                currentState = states.idle;

        }



        if (currentState != m_previousState)
            setNewState(currentState);

        if (framesNotMoving > framesCatIdle)
        {
            reachAudioSystemScript.SFXcatIdle();
        }
    }

    void setNewState(states _s)
    {
        m_followPoint.enabled = false;
        switch ((int)_s)
        {
            case 0:
                Debug.Log(_s);
                break;
            case 1:
                catFollow();
                break;
            default:
                Debug.Log(_s);
                break;
        }
        m_previousState = currentState;
    }

    void catFollow()
    {
        m_followPoint.enabled = true;

        // cat is following , 
    }



    void catDeath()
    {
        Debug.Log("I die");// cat just died stuff , HURT and LOSE
        reachAudioSystemScript.SFXcatHurt();
        reachStageManager.ChangeMenus(stageManager.currentGameState.Lose);
    }

    void catSaved(stage_goal _goal)
    {
        /*
        Debug.Log("I survive");// win the level stuff
        reachAudioSystemScript.SFXcatSleep();
        reachStageManager.ChangeMenus(stageManager.currentGameState.Win);
        */

        _goal.CheckIfLast();
    }



    bool isCatMoving()
    {
        bool _isMoving = (Vector2.Distance(prevFramePos, (Vector2)transform.position) > movementTolerance);
        prevFramePos = transform.position;
        return _isMoving;
    }

    void catDidNotMove()
    {
            reachAudioSystemScript.SFXcatIdle();
        framesNotMoving = 0;
        }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hurter")
            catDeath();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<stage_goal>() != null)
            catSaved(col.gameObject.GetComponent<stage_goal>());
        else if (col.tag == "Hurter")
            catDeath();
    }


}
