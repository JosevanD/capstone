using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringPot : MonoBehaviour
{
    public Animator potAnimator;
    public Animator moldAnimator;

    public void OnPointerDown()
    {
        potAnimator.SetBool("isPouring", true);
        //potAnimator.speed = 1;
        moldAnimator.SetBool("isFilling", true);
        moldAnimator.speed = 1;
    }

    public void OnPointerUp() 
    {
        potAnimator.SetBool("isPouring", false);

        moldAnimator.speed = 0;
    }

}
