using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChocoPieces : MonoBehaviour, IPointerDownHandler
{
    private BreakingChocoPieces breakingChocoPieces;

    private void Start()
    {
        breakingChocoPieces = FindObjectOfType<BreakingChocoPieces>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        breakingChocoPieces.SwitchChocoSprite(gameObject);
        breakingChocoPieces.brokenChocolateCount++;
        gameObject.GetComponent<Image>().raycastTarget = false;
    
    }

}
