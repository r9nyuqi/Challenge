using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    bool faceRight = true;
    float horizontalInput;
    public float movespeed = 5f;
    public Rigidbody2D rb;
    // Start is called before the first frame update

    Vector2 move;
    Animator animator;
    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            horizontalInput = Input.GetAxis("Horizontal");
            animator.SetBool("AD", true);
        }
        else
        {
            animator.SetBool("AD", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            horizontalInput = 0f;
            animator.SetBool("W", true);
        }
        else
        {
            animator.SetBool("W", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            horizontalInput = 0f;
            animator.SetBool("S", true);
        }
        else
        {
            animator.SetBool("S", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * movespeed * Time.deltaTime);
        rb.velocity = new Vector2(horizontalInput * movespeed, rb.velocity.y);
        animator.SetFloat("speed", Math.Abs(rb.velocity.x) + Math.Abs(rb.velocity.y));

    }

    void flip()
    {
        if (faceRight && horizontalInput < 0f || !faceRight && horizontalInput > 0f)
        {
            faceRight = !faceRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
}
