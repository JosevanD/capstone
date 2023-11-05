using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RPSManager : MonoBehaviour
{
    
    public TMP_Text Result;
    public TMP_Text playerScore;
    public TMP_Text EnemyScore;
    private int playerWinCount;
    private int enemyWinCount;
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
        playerWinCount = 0;
        enemyWinCount = 0;
        
    }
    private void Update()
    {
        if (CurrWinedRound >= TotalWinedRound)
        {
            /*Debug.Log("complete");
            Result.text = "You Won the Battle!";
            CardPuzzleGameobject.SetActive(false);
            
            TheEndingDoorObj.SetActive(true);
            charactorController.isInteracting = false;*/
            StartCoroutine(Countdown(3));
        }
        playerScore.text = "" +  playerWinCount;
        EnemyScore.text = "" + enemyWinCount;
    }
    public void Play(string myChoice)
    {
        string randomChoice = Choices[Random.Range(0, Choices.Length)];

        if (enemyWinCount < 2)
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
                            playerWinCount++;
                            CurrWinedRound++;
                            break;

                        case "Scissors":
                            Result.text = "The rock destroys the scissors, you lose!";
                            enemyWinCount++;
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
                            enemyWinCount++;
                            isAIWon = true;
                            break;

                        case "Paper":
                            Result.text = "Tie!";
                            break;

                        case "Scissors":
                            Result.text = "The scissors cuts the paper, you win!";
                            playerWinCount++;
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
                            playerWinCount++;
                            CurrWinedRound++;
                            break;

                        case "Paper":
                            Result.text = "The scissors cuts the paper, you Lose!";
                            enemyWinCount++;
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
        else if (enemyWinCount == 2) 
        {
            
            switch (myChoice)
        {
            case "Rock":
                Result.text = "The rock destroys the scissors, you win!";
                playerWinCount++;
                CurrWinedRound++;
                AIChoice.sprite = AIScissors;
                break;

            case "Paper":
                Result.text = "The paper covers the rock, you win!";
                playerWinCount++;
                CurrWinedRound++;
                AIChoice.sprite = AIRock;
                break;

            case "Scissors":                 
                Result.text = "The scissors cuts the paper, you win!";
                playerWinCount++;
                CurrWinedRound++;
                AIChoice.sprite = AIPaper;
                break;
        }

        }
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
        Result.text = "You Won the Battle!";
        CardPuzzleGameobject.SetActive(false);

        TheEndingDoorObj.SetActive(true);
        charactorController.isInteracting = false;

    }


}
