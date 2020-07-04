using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        //Speed code
        PlayerRun();
        //Jump code
        PlayerJump();
        //Crouch code
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
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        if (Input.GetKey(KeyCode.LeftControl) == true)
        {
            animator.SetBool("isCrouch", true);
            collider.offset = new Vector2(collider.offset.x, 0.6f);
            collider.size = new Vector2(collider.size.x, 1.3f);
        }
        else
        {
            animator.SetBool("isCrouch", false);
            collider.offset = new Vector2(collider.offset.x, 1f);
            collider.size = new Vector2(collider.size.x, 2f);
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
