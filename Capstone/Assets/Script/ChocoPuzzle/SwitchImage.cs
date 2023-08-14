using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchImage : MonoBehaviour
{
    public GameObject[] ChocolateImages;

    public ChocoPuzzleManager chocoPuzzleManager;

    public GameObject theNextPanel;
    public GameObject theCurrPanel;
    public Canvas ChocolatePuzzleCanvas;
    private int ImageCount = 0;

    private void Start()
    {
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();

        Debug.Log(ChocolateImages.Length);
    }

    public void OnPointerDown()
    {
        if (ImageCount < ChocolateImages.Length - 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ImageCount++;
                ChocolateImages[ImageCount].SetActive(true);

                Debug.Log("Current Image No is " + ImageCount);

                ChocolateImages[ImageCount - 1].SetActive(false);

                Debug.Log("last Image No is " + ImageCount);




            }


        }
        if (ImageCount >= ChocolateImages.Length - 1)
        {
            Debug.Log("Breaking Choco is finished");

            //ChocolatePuzzleCanvas.enabled = false;
            chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
            chocoPuzzleManager.charactorController.isInteracting = false;
            //theNextPanel.SetActive(true);
            chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.MixingMatcha;
            theCurrPanel.SetActive(false);
        }

    }
    private void Update()
    {




    }
    
}
