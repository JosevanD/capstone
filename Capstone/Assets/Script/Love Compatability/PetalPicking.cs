using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PetalPicking : MonoBehaviour
{
    FlowerManager flowerManager;

    [SerializeField]
    private Canvas FlowerPickingCanvas;
    //public bool isPickable;
    //private float DraggingTimer;
    //public float MaxDraggingTime;
    // Start is called before the first frame update
    void Start()
    {
        flowerManager = FindObjectOfType<FlowerManager>();
        //isPickable = false;
    }

    /*public void OnPointerDown(PointerEventData eventData)
    {
        flowerManager.PickedFlowerPetals++;
        
        Destroy(gameObject);
    
    }*/
    public void DragHandler(BaseEventData data)
    {
        
        PointerEventData pointerData = (PointerEventData)data;
        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)FlowerPickingCanvas.transform,
            pointerData.position,
            FlowerPickingCanvas.worldCamera,
            out position
            );
        transform.position = FlowerPickingCanvas.transform.TransformPoint(position);


    
    }

    public void OnMouseDrag()
    {
        gameObject.transform.position = Input.mousePosition;


    }

    public void OnMouseUp()
    {


        flowerManager.CurrFlowerPetal++;
        Destroy(gameObject);



    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
