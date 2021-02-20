using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int totalScore;
    private Text scoreText;

    public int TotalScore { get => totalScore; set => totalScore = value; }
    public Text ScoreText { get => scoreText; set => scoreText = value; }

    void Start()
    {
        ScoreText = gameObject.GetComponent<Text>();
        TotalScore = 0;
        RefreshScore(TotalScore);
        
    }

    public void ScoreToAdd(int score)
    {
        RefreshScore(score);

    }

    public void RefreshScore(int score)
    {
        TotalScore += score;
        ScoreText.text = "Score: "+TotalScore;
    }
}
