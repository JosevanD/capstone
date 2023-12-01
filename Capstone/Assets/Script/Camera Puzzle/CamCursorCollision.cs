using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CamCursorCollision : MonoBehaviour
{
    public bool isCursorHit = false;
    public float Radius;

    [Header("Blur Volume")]
    public Volume v;
    private DepthOfField DoF;
    private void Start()
    {
        v.profile.TryGet(out DoF);
       
    }

    private void Update()
    {
        //isCursorHit = false;
        /*isCursorHit = false;
        if (!isCursorHit)
        {
            v.weight = 1;
        {
            v.weight = 0;

        }*/
        Collider2D Collider = Physics2D.OverlapCircle(gameObject.transform.position, Radius);
        if (Collider.tag == "View Finder")
        {
            isCursorHit = true;
            Debug.Log("Detected");
            //v.weight = 0;
            DoF.active = false;
        }
        else
        {
            isCursorHit = false;
            Debug.Log("not detected");
            //v.weight = 1;
            DoF.active = true;
        }
    }
}

