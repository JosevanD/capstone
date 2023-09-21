using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RPSManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Result;
    public Image AIChoice;

    public string[] Choices;
    public Sprite Rock, Paper, Scissors;

    [SerializeField]
    private int TotalWinedRound;
    private int CurrWinedRound;

    private bool isAIWined;
    private void Start()
    {
        CurrWinedRound = 0;
        isAIWined = false;
    }
    private void Update()
    {
        if (CurrWinedRound >= TotalWinedRound)
        {
            //Debug.Log("complete");
        
        }
    }
    public void Play(string myChoice)
    {
        string randomChoice = Choices[Random.Range(0, Choices.Length)];

        if (isAIWined == false)
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
                            isAIWined = true;
                            break;

                    }

                    AIChoice.sprite = Rock;
                    break;

                case "Paper":
                    switch (myChoice)
                    {
                        case "Rock":
                            Result.text = "The paper covers the rock, you lose!";
                            isAIWined = true;
                            break;

                        case "Paper":
                            Result.text = "Tie!";
                            break;

                        case "Scissors":
                            Result.text = "The scissors cuts the paper, you win!";
                            CurrWinedRound++;
                            break;

                    }

                    AIChoice.sprite = Paper;
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
                            isAIWined = true;
                            break;

                        case "Scissors":
                            Result.text = "Tie!";
                            break;

                    }

                    AIChoice.sprite = Scissors;
                    break;

            }


        }

        Debug.Log("isWined " + isAIWined);
        if (isAIWined == true) 
        {
            
            switch (myChoice)
        {
            case "Rock":
                Result.text = "The rock destroys the scissors, you win!";
                CurrWinedRound++;
                AIChoice.sprite = Scissors;
                break;

            case "Paper":
                Result.text = "The paper covers the rock, you win!";
                CurrWinedRound++;
                AIChoice.sprite = Rock;
                break;

            case "Scissors":                 
                Result.text = "The scissors cuts the paper, you win!";
                CurrWinedRound++;
                AIChoice.sprite = Paper;
                break;
        }

        }
    }
}
