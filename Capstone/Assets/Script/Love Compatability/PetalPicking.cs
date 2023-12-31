using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PetalPicking : MonoBehaviour
{
    FlowerManager flowerManager;
    CursorManager cursorManager;

    [SerializeField]
    private Canvas FlowerPickingCanvas;
    //public bool isPickable;
    //private float DraggingTimer;
    //public float MaxDraggingTime;
    // Start is called before the first frame update
    void Start()
    {
        flowerManager = FindObjectOfType<FlowerManager>();
        cursorManager = FindObjectOfType<CursorManager>();
        cursorManager.ChangeToPalm();
    }

    
    public void DragHandler(BaseEventData data)
    {
        cursorManager.ChangeToGrab();
        PointerEventData pointerData = (PointerEventData)data;
        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)FlowerPickingCanvas.transform,
            pointerData.position,
            FlowerPickingCanvas.worldCamera,
            out position
            );
        transform.position = FlowerPickingCanvas.transform.TransformPoint(position);
        flowerManager.FlowerPickingAudioSource.Stop();
        flowerManager.FlowerPickingAudioSource.PlayOneShot(flowerManager.FlowerPickingClip);
        


    }

    public void OnMouseDrag()
    {
        gameObject.transform.position = Input.mousePosition;


    }

    public void OnMouseUp()
    {

        cursorManager.ChangeToPalm();
        flowerManager.CurrFlowerPetal++;
        /*if (flowerManager.EyesImage.sprite == flowerManager.HappyEyes)
            flowerManager.EyesImage.sprite = flowerManager.SadEyes;
        if (flowerManager.EyesImage.sprite == flowerManager.SadEyes)
            flowerManager.EyesImage.sprite = flowerManager.HappyEyes;*/
        if (flowerManager.CurrFlowerPetal % 2 != 0)
        {
            
            flowerManager.EyesImage.sprite = flowerManager.HappyEyes;
        }
        if (flowerManager.CurrFlowerPetal % 2 == 0)
        {
            flowerManager.EyesImage.sprite = flowerManager.SadEyes;
        }
        Destroy(gameObject);



    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
