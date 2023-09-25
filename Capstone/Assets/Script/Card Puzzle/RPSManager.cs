using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RPSManager : MonoBehaviour
{
    
    public TMP_Text Result;
    public Image AIChoice;

    public string[] Choices;
    public Sprite Rock, Paper, Scissors, AIRock, AIPaper, AIScissors;

    [SerializeField]
    private int TotalWinedRound;
    private int CurrWinedRound;

    [Header("Card Puzzle Canvas")]
    public GameObject CardPuzzleGameobject;

    [Header("The Waiting Time for Each Round")]
    public int WaitForSeconds;

    [Header("The Ending Door")]
    public GameObject TheEndingDoorObj;

    private Charactor_Controller charactorController;

    private bool isAIWon;
    private void Start()
    {
        charactorController = FindObjectOfType<Charactor_Controller>();
        Result.text = "Choose Your Card From The Right Pile";
        CurrWinedRound = 0;
        isAIWon = false;
        
    }
    private void Update()
    {
        if (CurrWinedRound >= TotalWinedRound)
        {
            Debug.Log("complete");
            Result.text = "You Won the Battle!";
            CardPuzzleGameobject.SetActive(false);
            
            TheEndingDoorObj.SetActive(true);
            charactorController.isInteracting = false;
        }
    }
    public void Play(string myChoice)
    {
        string randomChoice = Choices[Random.Range(0, Choices.Length)];

        if (isAIWon == false)
        {
            switch (randomChoice)
            {
                case "Rock":
                    switch (myChoice)
                    {
                        case "Rock":
                            Result.text = "Tie!";
                            break;

                        case "Paper":
                            Result.text = "The paper covers the rock, you win!";
                            CurrWinedRound++;
                            break;

                        case "Scissors":
                            Result.text = "The rock destroys the scissors, you lose!";
                            isAIWon = true;
                            break;

                    }

                    AIChoice.sprite = AIRock;
                    break;

                case "Paper":
                    switch (myChoice)
                    {
                        case "Rock":
                            Result.text = "The paper covers the rock, you lose!";
                            isAIWon = true;
                            break;

                        case "Paper":
                            Result.text = "Tie!";
                            break;

                        case "Scissors":
                            Result.text = "The scissors cuts the paper, you win!";
                            CurrWinedRound++;
                            break;

                    }

                    AIChoice.sprite = AIPaper;
                    break;

                case "Scissors":
                    switch (myChoice)
                    {
                        case "Rock":
                            Result.text = "The rock destroys the scissors, you win!";
                            CurrWinedRound++;
                            break;

                        case "Paper":
                            Result.text = "The scissors cuts the paper, you Lose!";
                            isAIWon = true;
                            break;

                        case "Scissors":
                            Result.text = "Tie!";
                            break;

                    }

                    AIChoice.sprite = AIScissors;
                    break;

            }


        }

        //Debug.Log("isWined " + isAIWined);
        else if (isAIWon == true) 
        {
            
            switch (myChoice)
        {
            case "Rock":
                Result.text = "The rock destroys the scissors, you win!";
                CurrWinedRound++;
                AIChoice.sprite = AIScissors;
                break;

            case "Paper":
                Result.text = "The paper covers the rock, you win!";
                CurrWinedRound++;
                AIChoice.sprite = AIRock;
                break;

            case "Scissors":                 
                Result.text = "The scissors cuts the paper, you win!";
                CurrWinedRound++;
                AIChoice.sprite = AIPaper;
                break;
        }

        }
    }

   
}
