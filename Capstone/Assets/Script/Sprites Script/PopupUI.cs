using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popupUI;
    private bool isPopupActive;
 
    void Start()
    {
        isPopupActive = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPopupActive == true && Input.GetKeyDown(KeyCode.E))
        {
            DeactivatePopup();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && isPopupActive == false)
        {
            ActivatePopup();
        }
        

        
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player" && isPopupActive == true)
        {
            DeactivatePopup();
        }
    }
    
    private void ActivatePopup()
    {
        popupUI.SetActive(true);
        isPopupActive = true;
    }
    
    private void DeactivatePopup()
    {
        popupUI.SetActive(false);
        isPopupActive = false;
    }
}
