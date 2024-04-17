using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Sprite white = Resources.Load<Sprite>("whiteSquare");
    public Sprite red = Resources.Load<Sprite>("redSwatch");
    public SpriteRenderer render;
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

    private bool isDash = false;
  
    public float dashPower = 24f;
    public float dashTime = 0.2f;
    public float eTime = 0;
    public float speedTime = 0;
    public bool speed = false;

    [SerializeField] private TrailRenderer tr;
    

    // Start is called before the first frame update

    Vector2 move;
    Animator animator;
    // Update is called once per frame
    void Update()
    {

        if(!Input.GetKey(KeyCode.E))
        {
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
        }

        if (eTimer > 0)
        {
            eTimer -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E) && !isE && eTimer <= 0 && loadE && eTime ==0)
        {

            movespeed = 15f;
            isE = true;
            eTimer = (float)(3);
            loadE = false;
            eTime = (float)(0.1);


        }
        if(eTime > 0 && eTime < 0.25 && isE)
        {
            eTime += Time.deltaTime;
            tr.emitting = true;
        }
        else if(eTime >= 0.25)
        {
            tr.emitting = false;
            movespeed = 5f;
            isE = false;
            eTime = 0;

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            loadE = true;
        }
        eDisplay = updateTimer(eTimer);

        if(speed)
        {
            speedTime = (float)(0.1);
            speed = false;
        }
        if(speedTime > 0 && speedTime <= 5 && !isE )
        {
            speedTime += Time.deltaTime;
            movespeed = 7f;
        }
        else if(speedTime >= 5)
        {
            speedTime = 0;
            movespeed = 5f;
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

   

    String updateTimer(float time)
    {


        if (time <= 0) return "0";


        else return time.ToString("F1");
    }

    private IEnumerator Dash()
    {
        isDash = true;
        movespeed = 22;
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        isDash = false;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("drops"))
        {
            Destroy(other.gameObject);
            speed = true;
        }
        
    }


}
