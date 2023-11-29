using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CamCursorCollision : MonoBehaviour
{
    public bool isCursorHit = false;

    [Header("Blur Volume")]
    public Volume v;
    //private DepthOfField d;
    //private bool isCursorIn = false;
    private void Start()
    {
        //v.profile.TryGet(out d);
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("Collided");
        isCursorHit = true;
        
    }

    
    private void Update()
    {
        isCursorHit = false;
        if (!isCursorHit)
        {
            v.weight = 1;
        }
        if (isCursorHit)
        {
            v.weight = 0;

        }
    }

}
