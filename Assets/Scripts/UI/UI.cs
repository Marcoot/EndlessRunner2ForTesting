using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text coinsDisplay;
    public TMP_Text healthDisplay;
    public TMP_Text ScoreDisplay;
    Coins coins;
    Health health;
    Score score;
    void Start()
    {
        coins = GameObject.FindGameObjectWithTag("Player").GetComponent<Coins>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
    }
    void Update()
    {
        coinsDisplay.text = "Coins: " + coins.currentCoins.ToString();
        healthDisplay.text = "Health: " + health.currentHealth.ToString();
        ScoreDisplay.text = "Score: " + score.totalScore.ToString();
    }
}
