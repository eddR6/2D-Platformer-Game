using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float walkSpeed;
    public int damageValue;
    private float direction;

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
        position.x += direction * walkSpeed * Time.deltaTime;
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
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.UpdateHealth(-(damageValue));
        }
    }
}
