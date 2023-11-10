using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popupUI;
    private bool isPopupActive;
    [SerializeField] Animator popupAnimator;
    [SerializeField] bool popupIsFlipped = true;
    [SerializeField] bool isStay = false;
    //[SerializeField] AudioSource popupSound;
    [SerializeField] AudioSource lockedSound;
    [SerializeField] float lockShakeDelay;
    [SerializeField] bool isPlayOnce;
    void Start()
    {
        isPopupActive = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPopupActive == true && Input.GetKeyDown(KeyCode.E) && isStay == false)
        {
            DeactivatePopup();
        }

        if (isPopupActive == true && Input.GetKeyDown(KeyCode.E) && isStay == true)
        {
            LockedPopup();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && isPopupActive == false && popupUI != null)
        {
            ActivatePopup();
        }
        

        
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player" && isPopupActive == true)
        {
            HidePopup();
        }
    }
    
    private void ActivatePopup()
    {
        popupUI.SetActive(true);
        Flip();
        isPopupActive = true;
    }
    
    private void DeactivatePopup()
    {
        popupUI.SetActive(false);
        
        isPopupActive = false;

        if (isPlayOnce == true)
        {
            DeletePopup();
        }
    } 
    
    private void HidePopup()
    {
        popupUI.SetActive(false);
        
        isPopupActive = false;

    }

    private void LockedPopup()
    {
        popupAnimator.SetBool("LockTry", true);
        lockedSound.enabled = true;
        StartCoroutine(LockedPopupDelay(lockShakeDelay));
    }
   

    private void Flip()
    {
        if (popupIsFlipped == true)
        {
            popupAnimator.SetBool("Flip", true);
        }

        if (popupIsFlipped == false)
        {
            popupAnimator.SetBool("Flip", false);
        }
    }

    IEnumerator LockedPopupDelay(float time)
    {

        yield return new WaitForSeconds(time);
        lockedSound.enabled = false;
        popupAnimator.SetBool("LockTry", false);


    }

    private void DeletePopup()
    {
        Destroy(popupUI);
    }
}
