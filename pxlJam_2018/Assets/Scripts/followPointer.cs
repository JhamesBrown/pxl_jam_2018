using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPointer : MonoBehaviour {


    public Transform target;
    public float speed = 1.0f;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // transform.LookAt(target);
        rb.AddRelativeForce(getTargetDirection() * speed);
    }

    Vector2 getTargetDirection()
    {
        Vector2 v2 = target.position - gameObject.transform.position;
        return v2.normalized;
    }
}
