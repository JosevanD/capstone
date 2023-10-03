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
                if (!DragNDropForTart.BowlAudioSource.isPlaying)
                {
                    Debug.Log("DragNDropForTart.BowlAudioSource.isPlaying" + DragNDropForTart.BowlAudioSource.isPlaying);
                    DragNDropForTart.BowlAudioSource.PlayOneShot(DragNDropForTart.FillingTartClip);
                }
                BowlAnimator.SetBool("isFillingTart", true);
                FillingTimer += Time.deltaTime;
                Debug.Log("collide" + gameObject);

            }
            if (Distance > DetectionDistance)
            {
                BowlAnimator.SetBool("isFillingTart", false);
                DragNDropForTart.BowlAudioSource.Stop();

            }
            if (Distance <= DetectionDistance && FillingTimer >= MaxFillingTimer)
            {
                BowlAnimator.SetBool("isFillingTart", false);
                CurrImage.sprite = FilledSprite;
                DragNDropForTart.TartCount++;
                gameObject.GetComponent<ChangingTartSprite>().enabled = false;
                isFinished = true;

            }

        }


    }


}
