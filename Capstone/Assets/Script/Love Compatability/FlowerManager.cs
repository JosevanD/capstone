using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerManager : MonoBehaviour
{
    [SerializeField] [Header("Flower Picking Canvas")]
    private GameObject FlowerPickingCanvasObj;
    //public Image 
    [Header("The bools")]
    public int MaxEndingTime;
    public GameObject[] FlowerPetals;
    private int FlowerPetalsCounts;
    public int CurrFlowerPetal;
    [Header("Player Controller")]
    public Charactor_Controller charactorController;

    [Header("Flower Picking Interactable Object")]
    public GameObject FlowerPickingObject;

    [Header("The Ending Door")]
    public GameObject EndingDoorObj;


    void Start()
    {
        charactorController = FindObjectOfType<Charactor_Controller>();
        CurrFlowerPetal = 0;
        FlowerPetalsCounts = FlowerPetals.Length;
        foreach (var petalObject in FlowerPetals)
        {
            petalObject.GetComponent<Image>().raycastTarget = false;
        }
        
    }
    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        charactorController.isInteracting = false;
        FlowerPickingCanvasObj.SetActive(false);
        FlowerPickingObject.SetActive(false);
        EndingDoorObj.SetActive(true);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrFlowerPetal >= FlowerPetalsCounts)
        {
            //puzzle ends
            
            StartCoroutine(Countdown(MaxEndingTime));
            Debug.Log("Flower Picking Finished");
        
        }
        if (CurrFlowerPetal < FlowerPetalsCounts)
            //FlowerPetals[CurrFlowerPetal].GetComponent<PetalPicking>().isPickable = true;
            FlowerPetals[CurrFlowerPetal].GetComponent<Image>().raycastTarget = true;
    }
}
