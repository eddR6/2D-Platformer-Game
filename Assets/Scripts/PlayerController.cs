using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float crouch_offset_y;
    public float crouch_size_y;
    public float player_speed;
    public float jump_force;
    private BoxCollider2D collide;
    private float original_offset_y;
    private float original_size_y;
    private Rigidbody2D rigid;
    private bool onGround;

    void Start()
    {
        collide= gameObject.GetComponent<BoxCollider2D>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        original_offset_y = collide.offset.y;
        original_size_y = collide.size.y;
    }
    void Update()
    {
        PlayerRun();
        PlayerJump();
        PlayerCrouch();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }

    void HorizontalMovement(float horizontal)
    {
        Vector2 position = transform.position; //x and y axis
        position.x += horizontal * player_speed * Time.deltaTime;
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
            collide.offset = new Vector2(collide.offset.x, crouch_offset_y);
            collide.size = new Vector2(collide.size.x, crouch_size_y);
        }
        else
        {
            animator.SetBool("isCrouch", false);
            collide.offset = new Vector2(collide.offset.x, original_offset_y);
            collide.size = new Vector2(collide.size.x, original_size_y);
        }

    }

    void PlayerJump()
    {
        float vertical = Input.GetAxisRaw("Jump");
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
        if (vertical > 0)
        {
            if (onGround)
            rigid.AddForce(new Vector2(0f,jump_force), ForceMode2D.Force);
        }
    }

    
}
