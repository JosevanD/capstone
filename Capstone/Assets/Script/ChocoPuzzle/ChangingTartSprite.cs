using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangingTartSprite : MonoBehaviour
{
    public Animator BowlAnimator;
    public float MaxFillingTimer;
    public float FillingTimer;
    public Sprite FilledSprite;
    public Image CurrImage;
    public float DetectionDistance;
    public GameObject MatchaChocoBowl;
    private DNDForTart DragNDropForTart;
    private bool isFinished;

    //public Sprite Fi

    /*private void OnTriggerStay2D(Collider2D other)
    {
        

        if (other.tag == "Matcha Choco Bowl" && !isFinished)
        {
            BowlAnimator.SetBool("isFillingTart", true);
            FillingTimer += Time.deltaTime;
            Debug.Log(other);
        }
        if (other.tag == null && isFinished)
        {
            BowlAnimator.SetBool("isFillingTart", false);

        }

        if (other.tag == "Match Choco Bowl" && FillingTimer >= MaxFillingTimer && !isFinished)
        {
            CurrImage.sprite = FilledSprite;
            DragNDropForTart.TartCount++;

            isFinished = true;

        }
    }*/

    private void Start()
    {
        DragNDropForTart = FindObjectOfType<DNDForTart>();
    }
    private void Update()
    {
        if (isFinished == false) 
        {
            float Distance = Vector3.Distance(MatchaChocoBowl.transform.position, gameObject.transform.position);
            if (Distance <= DetectionDistance && !isFinished)
            {
                BowlAnimator.SetBool("isFillingTart", true);
                FillingTimer += Time.deltaTime;
                Debug.Log("collide" + gameObject);
            }
            if (Distance > DetectionDistance)
            {
                BowlAnimator.SetBool("isFillingTart", false);

            }
            if (Distance <= DetectionDistance && FillingTimer >= MaxFillingTimer)
            {
                CurrImage.sprite = FilledSprite;
                DragNDropForTart.TartCount++;
                gameObject.GetComponent<ChangingTartSprite>().enabled = false;
                isFinished = true;

            }

        }


    }


}
