using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PetalPicking : MonoBehaviour
{
    FlowerManager flowerManager;
    //private float DraggingTimer;
    //public float MaxDraggingTime;
    // Start is called before the first frame update
    void Start()
    {
        flowerManager = FindObjectOfType<FlowerManager>();
    }

    /*public void OnPointerDown(PointerEventData eventData)
    {
        flowerManager.PickedFlowerPetals++;
        
        Destroy(gameObject);
    
    }*/

    public void OnMouseDrag()
    {
        gameObject.transform.position = Input.mousePosition;


    }

    public void OnMouseUp()
    {
        Destroy(gameObject);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
