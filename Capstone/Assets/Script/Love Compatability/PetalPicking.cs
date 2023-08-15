using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PetalPicking : MonoBehaviour, IPointerDownHandler
{
    FlowerManager flowerManager;
    // Start is called before the first frame update
    void Start()
    {
        flowerManager = FindObjectOfType<FlowerManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        flowerManager.PickedFlowerPetals++;
        
        Destroy(gameObject);
    
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
