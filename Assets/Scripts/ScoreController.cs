using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private int totalScore;
    private TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
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
