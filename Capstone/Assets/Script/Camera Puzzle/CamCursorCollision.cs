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
        v.weight = 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCursorHit = false;
        v.weight = 0;
    }

}
