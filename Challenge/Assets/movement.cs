using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Sprite white;
    public Sprite red;
    bool faceRight = true;
    float horizontalInput;
    public float movespeed = 5f;
    public Rigidbody2D rb;
    public float qTimer = 0;
    public String qDisplay;
    public float wTimer = 0;
    public String wDisplay;
    public float eTimer = 0;
    public String eDisplay;
    public bool loadQ = true;
    public bool loadW = true;
    public bool loadE = true;
    bool isQ = false;
    bool isW = false;
    public bool isE = false;

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
        if (qTimer > 0)
        {
            qTimer -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q) && !isQ && qTimer <= 0 && loadQ)
        {
            isQ = true;
            
            qTimer = (float)(0.5);
            loadQ = false;
           
        }
        else
        {
            isQ = false;
            
        }

        qDisplay = updateTimer(qTimer);
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
    String updateTimer(float time)
    {


        if (time <= 0) return "0";


        else return time.ToString("F1");
    }
}
