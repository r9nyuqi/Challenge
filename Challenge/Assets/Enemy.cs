using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public Rigidbody2D rb;
    public float rotateSpeed = 0.0025f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!target)
        {
            getTarget();
        }

        else
        {
            RotateTowardsTarget();
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void getTarget()
    {
        if(GameObject.FindGameObjectWithTag("Player").transform)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
       
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation,q,rotateSpeed);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            target = null;
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
