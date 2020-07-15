﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float walkSpeed;
    private float direction;
    public PlayerController playerController;
    public HealthController healthController;
    public GameObject gameOver;

    void Start()
    {
        direction = 1.0f;
       
        
    }

    void Update()
    {
        EnemyWalk();
        
    }
    void EnemyWalk()
    {
        Vector2 position = transform.position;
        position.x+= direction * walkSpeed * Time.deltaTime;
        transform.position = position;
    }
    public void Flip()
    {
        direction = -direction;
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            int health = playerController.GetHealth();
            if (health > 0)
            {
                playerController.DecreaseHealth(-1);
                healthController.UpdateLives(health - 1);
                if (health - 1 == 0)
                {

                    GameOverUI();
                }
            }
            
        }
    }

    void GameOverUI()
    {
        playerController.enabled = false;
        gameOver.SetActive(true);
    }
}