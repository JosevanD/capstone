using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCursorCollision : MonoBehaviour
{
    public bool isCursorHit = false;
    //private bool isCursorIn = false;
    private void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("Collided");
        isCursorHit = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCursorHit = false;

    }

}
