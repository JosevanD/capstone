using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DNDForTart : MonoBehaviour
{
    private ChocoPuzzleManager chocoPuzzleManager;


    public GameObject objectToDrag;
    public float DetectionRadius;
    
    public GameObject theCurrPanel;
    public int TotalTartCount;
    public GameObject[] Tarts; 
    public int TartCount;
    public LayerMask UI;
    Vector2 objectInitPos;

    [Header("Filling Tart SFX")]
    public AudioSource BowlAudioSource;
    public AudioClip FillingTartClip;

    [Header("Instruction")]
    public TMP_Text TextObj;
    public string Instruction_1;
    public string Instruction_2;

    private void Start()
    {
        TotalTartCount = GameObject.FindGameObjectsWithTag("Tart").Length;
        Tarts = GameObject.FindGameObjectsWithTag("Tart");
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        BowlAudioSource = GetComponent<AudioSource>();
        BowlAudioSource.clip = FillingTartClip;
        objectInitPos = objectToDrag.transform.position;
        chocoPuzzleManager.SwitchInstruction(TextObj, Instruction_1);
        chocoPuzzleManager.cursorManager.ChangeToPalm();
    }

    
    public void OnMouseDrag()
    {
        chocoPuzzleManager.cursorManager.ChangeToGrab();
        objectToDrag.transform.position = Input.mousePosition;
        
    }
    public void OnMouseUp()
    {
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
        chocoPuzzleManager.currPanels = ChocoPuzzleManager.CurrPanels.Packing;
        theCurrPanel.SetActive(false);


    }

    private void Update()
    {
        if (TartCount >= TotalTartCount)
        {
            chocoPuzzleManager.cursorManager.SetCursorDefault();
            chocoPuzzleManager.cursorManager.SetCursorDefault();
            chocoPuzzleManager.EndingAudioSource.Stop();
            chocoPuzzleManager.EndingAudioSource.PlayOneShot(chocoPuzzleManager.EndingClip);
            BowlAudioSource.Stop();
            gameObject.GetComponent<Image>().enabled = false;
            StartCoroutine(Countdown(chocoPuzzleManager.MaxEndingTime));

        }
        if (TartCount >= TotalTartCount)
        {
            TartCount = TotalTartCount;
        }
        else
        {
            Tarts[TartCount].GetComponent<ChangingTartSprite>().enabled = true;
        }
        
        
    }



}
