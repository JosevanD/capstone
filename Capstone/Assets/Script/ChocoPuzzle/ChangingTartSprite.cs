using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangingTartSprite : MonoBehaviour
{
    public float MaxFillingTimer;
    public float FillingTimer;
    public Sprite FilledSprite;
    public Image CurrImage;
    public float DetectionDistance;
    public GameObject MatchaChocoBowl;
    private DNDForTart DragNDropForTart;
    private bool isFinished;

    //public Sprite Fi

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.tag == "Matcha Choco Bowl")
        {
            //GetComponent<SpriteRenderer>.sprite = FilledSprite
            FillingTimer += Time.deltaTime;
            Debug.Log(other);
        }
        if (other.tag == "Match Choco Bowl" && FillingTimer >= MaxFillingTimer)
        {
            CurrImage.sprite = FilledSprite;

        }
    }*/
    private void Start()
    {
        DragNDropForTart = FindObjectOfType<DNDForTart>();
    }
    private void Update()
    {
        float Distance = Vector3.Distance(MatchaChocoBowl.transform.position, gameObject.transform.position);
        if (Distance < DetectionDistance)
        {
            //GetComponent<SpriteRenderer>.sprite = FilledSprite
            FillingTimer += Time.deltaTime;
            Debug.Log("collide" + CurrImage);
        }
        if (Distance < DetectionDistance && FillingTimer >= MaxFillingTimer && !isFinished)
        {
            CurrImage.sprite = FilledSprite;
            DragNDropForTart.TartCount++;
            isFinished = true;
            
        }
    }


}
