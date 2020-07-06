using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float crouch_offset_y;
    public float crouch_size_y;
    private BoxCollider2D collide;
    private float original_offset_y;
    private float original_size_y;


    void Start()
    {
         collide= gameObject.GetComponent<BoxCollider2D>();
        original_offset_y = collide.offset.y;
        original_size_y = collide.size.y;
    }
    void Update()
    {
        PlayerRun();
        PlayerJump();
        PlayerCrouch();
    }

    void PlayerRun()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

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

    }
}
