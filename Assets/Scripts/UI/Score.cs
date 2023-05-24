using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Score : MonoBehaviour
{
    Coins coins;
    PlayerMovement playerMovement;
    public int playerSteps;
    public float timer;
    private float interval = 0.1f;
    public int totalScore;
    private void Start()
    {
        coins = GameObject.FindGameObjectWithTag("Player").GetComponent<Coins>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //if (playerMovement.gameStarted)
        //{ 
        if (playerMovement.gameStarted)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                playerSteps++;
                timer = 0f;
            }
            totalScore = playerSteps + (10 * coins.currentCoins);
        }
        //}
    }
    void ScoreDisplay()
    {
        //scoreDisplay = playerSteps + (10 * coins.currentCoins);
    }

}
