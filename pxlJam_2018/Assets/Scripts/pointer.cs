using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointer : MonoBehaviour {


    public Vector2 screenPos;


    public GameObject particle;
    void Update()
    {
        screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(screenPos.x, screenPos.y);
    }
}
