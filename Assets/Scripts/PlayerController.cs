using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float crouchOffsetY;
    public float crouchSizeY;
    public float playerSpeed;
    public float jumpForce;
    public HealthController healthController;
    public NavigationMenu gameOver;
    private BoxCollider2D collide;
    private float originalOffsetY;
    private float originalSizeY;
    private Rigidbody2D rigidBody2d;
    private bool onGround;
    private int groundLayer;
    private int health;
    private int maxHealth;

    void Start()
    {
        collide= gameObject.GetComponent<BoxCollider2D>();
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        originalOffsetY = collide.offset.y;
        originalSizeY = collide.size.y;
        groundLayer = LayerMask.NameToLayer("Ground");
        maxHealth = healthController.MaxHealth();
        health = maxHealth;
    }   
    void Update()
    {
        PlayerRun();
        PlayerJump();
        PlayerCrouch();
    }
     
    public void UpdateHealth(int h)
    {
        
        if (health > 0)
        {
            health = health + h;
            healthController.UpdateLives(health);
            if (health == 0)
            {
                PlayerDead();
            }
        }
    }
    public int GetHealth()
    {
        return health;
    }

    void HorizontalMovement(float horizontal)
    {
        Vector2 position = transform.position; //x and y axis
        position.x += horizontal * playerSpeed * Time.deltaTime;
        transform.position = position;
    }

    void PlayerRun()
    {   //Animation
        float horizontal= Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal > 0)
        {
            PlayerMovementSound();
            scale.x = Mathf.Abs(scale.x);
        }
        else if (horizontal < 0)
        {
            PlayerMovementSound();
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        //Movement
        
        HorizontalMovement(horizontal);
    }

    private void PlayerMovementSound()
    {
        Debug.Log("soundout");
        SoundManager soundManager = SoundManager.Instance;
        if(onGround && !soundManager.soundEffect.isPlaying)
        {
            Debug.Log("sound");
            soundManager.soundEffect.pitch = UnityEngine.Random.Range(1.4f, 2.0f);
            soundManager.Play(Sounds.PlayerMove);
        }
    }

    void PlayerCrouch()
    {

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
            collide.offset = new Vector2(collide.offset.x, crouchOffsetY);
            collide.size = new Vector2(collide.size.x, crouchSizeY);
        }
        else
        {
            animator.SetBool("isCrouch", false);
            collide.offset = new Vector2(collide.offset.x, originalOffsetY);
            collide.size = new Vector2(collide.size.x, originalSizeY);
        }

    }
    
    void PlayerJump()
    {
        float vertical = Input.GetAxis("Jump");
        if (vertical>0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        JumpMovement();
    }

    void JumpMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             if (onGround) {
                rigidBody2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
                Debug.Log("Jumped");
             }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            onGround = false;
        }
    }
    public void PlayerDead()
    {
        gameObject.GetComponent<PlayerController>().enabled = false;
        StartCoroutine(DeathAnimation());
        
    }

    IEnumerator DeathAnimation()
    {
        animator.Play("Player_death");
        yield return new WaitForSeconds(1f);
        gameOver.NavigationEnable();
    }
    

    
}
