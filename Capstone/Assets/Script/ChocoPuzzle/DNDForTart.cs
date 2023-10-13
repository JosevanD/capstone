using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //private float pressTime = 0f;
    //public float totalPressTime = 0f;
    private void Start()
    {
        TotalTartCount = GameObject.FindGameObjectsWithTag("Tart").Length;
        Tarts = GameObject.FindGameObjectsWithTag("Tart");
        chocoPuzzleManager = FindObjectOfType<ChocoPuzzleManager>();
        BowlAudioSource = GetComponent<AudioSource>();
        BowlAudioSource.clip = FillingTartClip;
        objectInitPos = objectToDrag.transform.position;
    }

    
    public void OnMouseDrag()
    {
        objectToDrag.transform.position = Input.mousePosition;
        //pressTime += Time.deltaTime;
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
