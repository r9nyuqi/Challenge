using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmouse : MonoBehaviour
{
    private Vector2 cursorPos;
    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(cursorPos.x - transform.position.x, cursorPos.y - transform.position.y);

        rb.velocity = direction * speed;

    }
}
