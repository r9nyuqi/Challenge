using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;

        if(timer >= 2 && hasLineOfSight)
        {
            timer = 0;
            shoot();
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
