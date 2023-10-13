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
    private bool inTrigger;

    [SerializeField] private GameObject popupUI;
    private void Start()
    {
        inTrigger = false;
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player" && interactToPlayAnim == false)
        {
            inTrigger = true;
        }

        if (collider.tag == "Player" && interactToPlayAnim == true)
        {
            inTrigger = true;
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            inTrigger = false;
        }
    }

    public void PlayAnim(int i)
    {
        animator.SetBool(animatorBoolParameters[i], true);

    }

    private void Update()
    {
         if (inTrigger == true && interactToPlayAnim == true && Input.GetKeyDown(KeyCode.E))
         {
            PlayAnim(animationNo);
            popupUI.SetActive(false);
         }
        
         if (inTrigger == true && interactToPlayAnim == false)
         {
            PlayAnim(animationNo);
        }


    }
}
