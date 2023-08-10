using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChocoPuzzleManager : MonoBehaviour
{
    public Canvas ChocoPuzzleCanvas;

    /*public GameObject BreakingChocoPanel;
    public GameObject MixingMatchaPanel;
    public GameObject OvenPanel;*/
    public GameObject[] ChocoPanels;
    public int panelNum;
    public bool IsPanelFinished;

    private void Start()
    {
        panelNum = 0;
        ChocoPanels[panelNum].SetActive(true);
        IsPanelFinished = false;
    }

    private void FixUpdate()
    {
        if (IsPanelFinished == true && panelNum <= ChocoPanels.Length - 1);
        {
            Debug.Log("Panel Number 0 is " + panelNum);
            panelNum++;
            Debug.Log("Panel Number 1 is " + panelNum);
            ChocoPanels[panelNum].SetActive(true);
            ChocoPanels[panelNum -1].SetActive(false);
            IsPanelFinished = false;

        }
    }
}
