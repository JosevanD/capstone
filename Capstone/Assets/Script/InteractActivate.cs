using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractActivate : MonoBehaviour
{
    [Header("Objects")]
    public GameObject objectToActivate;
    //public GameObject objectToDeActivate;
    public GameObject popupUI;

    [Header("Interact Conditions")]
    private bool inTrigger;
    private bool objectActive = false;

    public bool interactToPlay;
    public float objectDuration;
    public bool objectHasDuration;
    

    private void Start()
    {
        inTrigger = false;
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player" && interactToPlay == false)
        {
            inTrigger = true;
            popupUI.SetActive(true);
        }

        if (collider.tag == "Player" && interactToPlay == true)
        {
            inTrigger = true;
            popupUI.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            inTrigger = false;
            popupUI.SetActive(false);
        }
    }

    public void ActivateObject()
    {
        objectToActivate.SetActive(true);
        popupUI.SetActive(false);
        objectActive = true;

        if (objectHasDuration == true)
        {
            StartCoroutine(ObjectTimer(objectDuration));
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
