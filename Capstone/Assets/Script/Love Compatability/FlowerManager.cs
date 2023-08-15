using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{

    public GameObject[] FlowerPetals;
    private int FlowerPetalsCounts;
    public int PickedFlowerPetals;
    private bool isFinished;
    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
        PickedFlowerPetals = 0;
        //FlowerPetalsCounts = GameObject.FindGameObjectsWithTag("Flower Petal").Length;
        FlowerPetalsCounts = FlowerPetals.Length;

    }

    // Update is called once per frame
    void Update()
    {
        if (PickedFlowerPetals >= FlowerPetalsCounts)
        {
            //puzzle ends
            Debug.Log("Flower Picking Finished");
        
        }


    }
}
