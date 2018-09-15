using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPointer : MonoBehaviour {

    public float speed = 40.0f;
    public Transform visuals;


    private Transform target;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = gameObject.GetComponent<cat_logic>().pointer;
    }

    void Update()
    {
        // transform.LookAt(target);
        rb.AddRelativeForce(getTargetDirection() * speed);
    }

    Vector2 getTargetDirection()
    {
        Vector2 v2 = target.position - gameObject.transform.position;
        float direction = Mathf.Round(v2.normalized.x);
        if (direction != 0)
            visuals.localScale *= new Vector2(visuals.localScale.x * -direction, 1.0f);
        return v2.normalized;
    }
}
