using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PackingManager : MonoBehaviour
{
    private ChocoPuzzleManager chocoPuzzleManager;
    public int currSpriteNum;
    public Sprite[] ImageSprites;
    public Image PackingBoxImage;
    public GameObject PlacingParent;
    public GameObject theCurrPanel;

    public GameObject LidObj;
    public GameObject plate;
    public Image BoxCover;
    // public GameObject PackingParent;
    public bool isPlacing;

    [Header("Instruction")]
    public TMP_Text TextObj;
    public string Instruction_1;
    public string Instruction_2;


    void Start()
    {
        currSpriteNum = 0;
        isPlacing = true;
        BoxCover.raycastTarget = false;
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_1);
        chocoPuzzleManager.cursorManager.ChangeToPalm();
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
            chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_2);
            //Debug.Log("put the cover on");
            plate.SetActive(false);
            LidObj.SetActive(true);
            BoxCover.raycastTarget = true;
           
        }
        if (currSpriteNum >= ImageSprites.Length-1)
        {
            chocoPuzzleManager.cursorManager.SetCursorDefault();
            chocoPuzzleManager.EndingAudioSource.Stop();
            chocoPuzzleManager.EndingAudioSource.PlayOneShot(chocoPuzzleManager.EndingClip);
            StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));
            
        }
    }
}
