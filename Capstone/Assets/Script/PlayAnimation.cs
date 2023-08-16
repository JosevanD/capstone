using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [Header("Animation")]
    public Animator animator;
    public bool interactToPlayAnim;

    [Header("Animation Paramater")]
    public string[] animatorBoolParameters;
    public int animationNo = 0;

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player" && interactToPlayAnim == false)
        {
            PlayAnim(animationNo);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player" && interactToPlayAnim == true && Input.GetKeyDown(KeyCode.E))
        {
            PlayAnim(animationNo);
        }
    }

    public void PlayAnim(int i)
    {
        animator.SetBool(animatorBoolParameters[i], true);
    }
}
