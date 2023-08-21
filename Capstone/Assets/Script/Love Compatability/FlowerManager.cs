using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject FlowerPickingCanvasObj;
    //public Image 
    public int MaxEndingTime;
    public GameObject[] FlowerPetals;
    private int FlowerPetalsCounts;
    public int CurrFlowerPetal;

    //public int PickedFlowerPetals;
    public GameObject EndingDoorObj;
    private bool isFinished;
    // Start is called before the first frame update
    void Start()
    {
        CurrFlowerPetal = 0;
        isFinished = false;
        //PickedFlowerPetals = 0;
        //FlowerPetalsCounts = GameObject.FindGameObjectsWithTag("Flower Petal").Length;
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

        FlowerPickingCanvasObj.SetActive(false);
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
