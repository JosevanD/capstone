using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private bool interactToPlayAnim;
    [SerializeField] private bool animationPlayOnce;


    [Header("Animation Paramater")]
    public string[] animatorBoolParameters;
    public int animationNo = 0;
    private bool inTrigger;

    [SerializeField] private GameObject popupUI;
    [SerializeField] private BoxCollider trigCollider;

    [Header("Objects")]
    [SerializeField] private GameObject objToDisable;
    [SerializeField] private bool isDisableObj;


    private void Start()
    {
        inTrigger = false;
        //trigCollider = gameObject.GetComponent<BoxCollider>();
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
        trigCollider.enabled = false;
        
        if (isDisableObj == true)
        {
            objToDisable.SetActive(false);
        }
    }

    public void AnimReEnableCollider()
    {
        trigCollider.enabled = true;
    }

    public void AnimReActivateObj()
    {
        objToDisable.SetActive(true);
    }

    public void AnimBoolOff(int i)
    {
        animator.SetBool(animatorBoolParameters[i], false);
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

    public void AnimDisableObj()
    {
        objToDisable.SetActive(false);
    }
}
