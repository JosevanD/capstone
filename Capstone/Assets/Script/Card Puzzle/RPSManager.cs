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

    
    private AudioSource CardAudioSource;

    [Header("Card Battle SFX")]
    public AudioClip WonClip;

    private Charactor_Controller charactorController;

    private bool isAIWon;
    private void Start()
    {
        CardAudioSource = GetComponent<AudioSource>();
        charactorController = FindObjectOfType<Charactor_Controller>();
        Result.text = "First to Get 3 points Wins";
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
            CardAudioSource.PlayOneShot(WonClip);
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
                            Result.text = "you win!";
                            playerWinCount++;
                            CurrWinedRound++;
                            break;

                        case "Scissors":
                            Result.text = "you lose!";
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
                            Result.text = "you lose!";
                            enemyWinCount++;
                            isAIWon = true;
                            break;

                        case "Paper":
                            Result.text = "Tie!";
                            break;

                        case "Scissors":
                            Result.text = "you win!";
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
                            Result.text = "you win!";
                            playerWinCount++;
                            CurrWinedRound++;
                            break;

                        case "Paper":
                            Result.text = "you Lose!";
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
                Result.text = "you win!";
                playerWinCount++;
                CurrWinedRound++;
                AIChoice.sprite = AIScissors;
                break;

            case "Paper":
                Result.text = "you win!";
                playerWinCount++;
                CurrWinedRound++;
                AIChoice.sprite = AIRock;
                break;

            case "Scissors":                 
                Result.text = "you win!";
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
        //CardAudioSource.Stop();
        
        Result.text = "You Won the Battle!";
        CardPuzzleGameobject.SetActive(false);

        TheEndingDoorObj.SetActive(true);
        charactorController.isInteracting = false;

    }


}
