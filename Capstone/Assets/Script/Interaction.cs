using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public float InteractionDistance = 2;

    public Canvas PuzzleCanvas;
    public GameObject PuzzlePanel;

    public GameObject PuzzleCanvasObj;

    public Charactor_Controller charactorController;
    private void Awake()
    {
        PuzzleCanvas.enabled = false;
        PuzzlePanel.SetActive(false);
        //PuzzleCanvasObj.SetActive(false);
        charactorController = FindObjectOfType<Charactor_Controller>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, InteractionDistance);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.transform.tag == "Player")
                {
                    Debug.Log("Interected");

                    //PuzzleCanvasObj.SetActive(true);
                    PuzzlePanel.SetActive(true);
                    PuzzleCanvas.enabled = true;
                    charactorController.isInteracting = true;
                    //Destroy(gameObject);
                    
                }
            }
        
        }
    }

    
}
