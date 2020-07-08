using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float crouchOffsetY;
    public float crouchSizeY;
    public float playerSpeed;
    public float jumpForce;
    private BoxCollider2D collide;
    private float originalOffsetY;
    private float originalSizeY;
    private Rigidbody2D rigidBody2d;
    private bool onGround;
    private bool jumpCalled;

    void Start()
    {
        collide= gameObject.GetComponent<BoxCollider2D>();
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        originalOffsetY = collide.offset.y;
        originalSizeY = collide.size.y;
        jumpCalled = false;
    }
    void Update()
    {
        PlayerRun();
        PlayerJump();
        PlayerCrouch();
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
            scale.x = Mathf.Abs(scale.x);
        }
        else if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        //Movement
        HorizontalMovement(horizontal);
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
        JumpMovement(vertical);
    }

    void JumpMovement(float vertical)
    {
        if (vertical>0)
        {
            //jumpCalled is avoid 2-3 times added force which has something to do with jump axis
            if (onGround && !jumpCalled) {
                rigidBody2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
                Debug.Log("---??"+vertical);
                jumpCalled = true;
            }

        }
        else
        {
            jumpCalled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onGround = false;
        }
    }

}
