using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChocoPuzzleManager : MonoBehaviour
{
    public Canvas ChocoPuzzleCanvas;
    public Charactor_Controller charactorController;

    /*public GameObject BreakingChocoPanel;
    public GameObject MixingMatchaPanel;
    public GameObject OvenPanel;*/
    //public GameObject[] ChocoPanels;

    public int panelNum;
    //public bool IsPanelFinished;
    public int ChocolatesPlaced;

    private void Start()
    {
        ChocolatesPlaced = 0;
        panelNum = 0;
        charactorController = FindObjectOfType<Charactor_Controller>();

        //ChocoPanels[panelNum].SetActive(true);
        //IsPanelFinished = false;
    }

    private void Update()
    {
        /*if (IsPanelFinished == true && panelNum <= ChocoPanels.Length - 1);
        {
            Debug.Log(IsPanelFinished);

            IsPanelFinished = false;
            Debug.Log("Panel Number 0 is " + panelNum);
            panelNum+=1;
            Debug.Log("Panel Number 1 is " + panelNum);
            
            ChocoPanels[panelNum].SetActive(true);
            ChocoPanels[panelNum -1].SetActive(false);
           

        }*/
        /*if (IsPanelFinished == true)
        {
            charactorController.isInteracting = false;
        
        }*/


    }
}
