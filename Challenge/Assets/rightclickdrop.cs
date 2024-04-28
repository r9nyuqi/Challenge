using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightclickdrop : MonoBehaviour
{

    public movement movement;
    public Rigidbody2D rb;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<movement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (movement.getHasRightClick())
        {
            rb.excludeLayers = LayerMask.GetMask("Player");
            
           
        }
        else
        {
            rb.excludeLayers = LayerMask.GetMask("Enemy");
            rb.includeLayers = LayerMask.GetMask("Player");
        }
    }
}
