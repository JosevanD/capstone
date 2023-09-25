using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractActivate : MonoBehaviour
{
    [Header("Objects")]
    public GameObject objectToActivate;
    public GameObject objectToDeActivate;
    //public GameObject popupUI;

    [Header("Interact Conditions")]
    private bool inTrigger;
    private bool objectActive = false;

    public bool interactToPlay;
    public float objectDuration;
    public bool objectHasDuration;
    public bool hasObjectToDeactivate;

    private void Start()
    {
        inTrigger = false;
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player" && interactToPlay == false)
        {
            inTrigger = true;
            
        }

        if (collider.tag == "Player" && interactToPlay == true)
        {
            inTrigger = true;
            //popupUI.SetActive(true);
        }

        if (hasObjectToDeactivate == true)
        {
            objectToDeActivate.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player" && interactToPlay == true)
        {
            inTrigger = false;
            //popupUI.SetActive(false);
        }

        if (collider.tag == "Player" && interactToPlay == false)
        {
            inTrigger = false;
            
        }

    }

    public void ActivateObject()
    {
        objectToActivate.SetActive(true);
        
        objectActive = true;

        if (objectHasDuration == true)
        {
            StartCoroutine(ObjectTimer(objectDuration));
        }

        if (interactToPlay == true)
        {
            //popupUI.SetActive(false);
        }

    }
    
    public void DeactivateObject()
    {
        objectToActivate.SetActive(false);
        objectActive = false;
    }

    private void Update()
    {
        if (inTrigger == true && interactToPlay == true && Input.GetKeyDown(KeyCode.E) && objectActive == false)
        {
            ActivateObject();
        }

        if (inTrigger == true && interactToPlay == false && objectActive == false)
        {
            ActivateObject();
        }


    }

    IEnumerator ObjectTimer (float time)
    {
        yield return new WaitForSeconds(time);
        DeactivateObject();
         
    }
}
