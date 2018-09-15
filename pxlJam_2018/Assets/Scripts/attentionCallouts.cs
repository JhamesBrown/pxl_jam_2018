using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attentionCallouts : MonoBehaviour {

    public Transform target;

    private float m_attentionDist;


	void Start()
    {
        target = GetComponentInParent<cat_logic>().pointer;
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        m_attentionDist = GetComponentInParent<cat_logic>().attentionDistance;
    }
	void FixedUpdate()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position - transform.position, Vector2.Distance(transform.position, target.transform.position));
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        if (hit.transform != null)
            lineRenderer.SetPosition(1, hit.transform.position);
        else if (Vector2.Distance(transform.position, target.position) <= m_attentionDist)
            lineRenderer.SetPosition(1, target.position);
    }
}
