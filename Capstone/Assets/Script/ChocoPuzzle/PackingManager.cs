using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackingManager : MonoBehaviour
{
    private ChocoPuzzleManager chocoPuzzleManager;
    public int currSpriteNum;
    public Sprite[] ImageSprites;
    public Image PackingBoxImage;
    public GameObject PlacingParent;
    public GameObject theCurrPanel;
    public Image BoxCover;
    // public GameObject PackingParent;
    public bool isPlacing;
    // Start is called before the first frame update
    void Start()
    {
        currSpriteNum = 0;
        isPlacing = true;
        BoxCover.raycastTarget = false;
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        //PackingParent.SetActive(false);
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        chocoPuzzleManager.ChocoPuzzleCanvas.enabled = false;
        chocoPuzzleManager.charactorController.isInteracting = false;
        chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.AllFinished;
        theCurrPanel.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if(isPlacing == true)
        PackingBoxImage.sprite = ImageSprites[currSpriteNum];

        
        if (currSpriteNum == ImageSprites.Length - 2)
        {
            //Debug.Log("put the cover on");
            BoxCover.raycastTarget = true;
           
        }
        if (currSpriteNum >= ImageSprites.Length-1)
        {
            StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));
            
        }
    }
}
