using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

public class logicScript : MonoBehaviour
{
    public int playerScore;
    public TMP_Text scoreText;
    public TMP_Text minText;
    public TMP_Text secText;

    public TMP_Text bestMinText;
    public TMP_Text bestSecText;

    public GameObject gameOverScreen;
    public float countTimer = 0;
    public int countTimerINT;
    public float currentDifficulty = 0.00f;
    public float spawnDifficulty;
    private float currentBestTime;
    private bool difficultyIncreased = false;
    private bool spawnIncreased = false;
    public swordScript swordLogic;

    private void Start()
    {
        spawnDifficulty = 1;
        swordLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<swordScript>();
        currentBestTime = PlayerPrefs.GetFloat("BestTime", 0);

        bestMinText.text = Math.Floor(currentBestTime / 60).ToString("00");
        bestSecText.text = Math.Floor(currentBestTime % 60).ToString("00");


    }
    public void Update()
    {
        
        
        // if game is not over, keep counting the time
        if (swordLogic.notGameOver == true)
        {
            countTimer = countTimer + Time.deltaTime;
        }
        

        

        countTimerINT = Mathf.RoundToInt(countTimer);

        minText.text = Math.Floor(countTimer / 60).ToString("00");

        secText.text = Math.Floor(countTimer % 60).ToString("00");

        //track if current time is more that best time record

        if (countTimer > currentBestTime && swordLogic.notGameOver == true)
        {
            PlayerPrefs.SetFloat("BestTime", countTimer);
            currentBestTime = countTimer;
            bestMinText.text = Math.Floor(currentBestTime / 60).ToString("00");
            bestSecText.text = Math.Floor(currentBestTime % 60).ToString("00");
        }

        if (countTimerINT % 10 == 0 && countTimerINT >=1 && spawnIncreased == false)
        {
            spawnDifficulty += 1.5f;
            spawnIncreased = true;
            
        } 
        else if (countTimerINT % 10 != 0)
        {
            spawnIncreased = false;
        }



        if (countTimerINT % 20 == 0 && difficultyIncreased == false)
        {
            
            currentDifficulty += 0.50f;
            difficultyIncreased = true;
        }
        else if(countTimerINT % 20 != 0)
        {
            difficultyIncreased = false;
        }

        Debug.Log(currentDifficulty);

    }

    public void addScore(int scoreToAdd)
    {
           
        
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
            
        
        
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {


        highScoreCheck();
        gameOverScreen.SetActive(true);
        
    }

    public void exitGame()
    {
        Application.Quit();
    }

    void highScoreCheck()
    {
        if (swordLogic.notGameOver == true)
        {
            if(countTimer > currentBestTime)
            {
                PlayerPrefs.SetFloat("BestTime", countTimer);
            }



        }
    }
}
