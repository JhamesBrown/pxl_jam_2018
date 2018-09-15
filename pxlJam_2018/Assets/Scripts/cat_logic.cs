using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_logic : MonoBehaviour
{

    public enum states { idle, following, dead };
    public states currentState;
    public Transform pointer;
    public float attentionDistance = 5;


    private states m_previousState;

    private followPointer m_followPoint;
	
	void Start()
    {
        currentState = states.idle;
        m_followPoint = GetComponent<followPointer>();
	}
	
	
	void Update()
    {
        if (Vector2.Distance(transform.position, pointer.transform.position) < attentionDistance)
            currentState = states.following;
        else
            currentState = states.idle;


        if (currentState != m_previousState)
            setNewState(currentState);


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
                m_followPoint.enabled = true;
                break;
            default:
                Debug.Log(_s);
                break;
        }
        m_previousState = currentState;
    }


    void catDeath()
    {
        Debug.Log("I die");


    }

    void catSaved()
    {

        Debug.Log("I survive");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<dog_logic>() != null)
            catDeath();
        else if (col.gameObject.GetComponent<stage_goal>() != null)
            catSaved();

    }
}
