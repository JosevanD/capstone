using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CardPrize : MonoBehaviour
{
    public TMP_Text PrizeResult;
    public GameObject CardPuzzleGameobject;
    public GameObject TheEndingDoorObj;
    private Charactor_Controller charactorController;

    private void Start()
    {
        charactorController = FindObjectOfType<Charactor_Controller>();
    }

    public void nextAction()
    {
        //StartCoroutine(Countdown(3));
        CardPuzzleGameobject.SetActive(false);
        //PrizeCardObj.SetActive(true);
        TheEndingDoorObj.SetActive(true);
        charactorController.isInteracting = false;

    }
    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        Debug.Log("complete");
        //CardAudioSource.Stop();

        //PrizeResult.text = "You Won the Battle!";
        CardPuzzleGameobject.SetActive(false);
        //PrizeCardObj.SetActive(true);
        TheEndingDoorObj.SetActive(true);
        charactorController.isInteracting = false;

    }
}
