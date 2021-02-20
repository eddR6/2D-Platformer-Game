using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int totalScore;
    private Text scoreText;
    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        totalScore = 0;
        RefreshScore(totalScore);
        
    }

    public void ScoreToAdd(int score)
    {
        RefreshScore(score);

    }

    private void RefreshScore(int score)
    {
        totalScore += score;
        scoreText.text = "Score: "+totalScore;
    }
}
