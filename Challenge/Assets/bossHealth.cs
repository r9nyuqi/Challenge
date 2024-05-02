using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class bossHealth : MonoBehaviour
{

    public Image healthBar;
    public float health = 100;
    public GameObject bullet;
    public Transform bulletPos;
    public float timer;
    public Transform player;
    private bool hasLineOfSight = false;

    public Light2D light;
    public bool isdie = false;
    public float dieTimer = 0;
    public Rigidbody2D rb;
    public Animator animator;
    public AudioSource wallbreak;
    public AudioSource hit;

    public Sprite sp1, sp2, sp3;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Health", health);

        if(health < 75 && health >= 50)
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
        }
        else if (health < 50 && health >= 25)
        {
            GetComponent<SpriteRenderer>().sprite = sp2;
        }
        else if (health < 25)
        {
            GetComponent<SpriteRenderer>().sprite = sp3;
        }
        if (health <= 0)
        {
            isdie = true;
            health = 1;
            wallbreak.Play();
            animator.SetTrigger("Bossdie");
            
        }
        if (isdie)
        {

            dieTimer += Time.deltaTime;
            
            rb.excludeLayers = LayerMask.GetMask("Player");
            rb.excludeLayers += LayerMask.GetMask("Ignore Raycast");
            
        }

        if (dieTimer >= 1)
        {
            print("destroy");
            Destroy(gameObject);
        }
        timer += Time.deltaTime;

        if(timer >= 2 && hasLineOfSight)
        {
            light.color = new Color((float)0.24, (float)0.09, (float)(0.03), 1);
            timer = 0;
            shoot();

        }
        else
        {
            light.color = new Color(1, (float)0.92, (float)0.016, 1);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("rightclick"))
        {
            TakeDamage(20);
            Destroy(other.gameObject);
            hit.Play();
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.position - transform.position);
        if (ray.collider)
        {
          
            hasLineOfSight = ray.collider.CompareTag("Player");
        }
        if (hasLineOfSight)
        {
           
            Debug.DrawRay(transform.position, player.position - transform.position, Color.green);
        }
        else
        {

            
            Debug.DrawRay(transform.position, player.position - transform.position, Color.red);
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

}
