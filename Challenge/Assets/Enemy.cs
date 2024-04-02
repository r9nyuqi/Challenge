using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public Rigidbody2D rb;
    public float rotateSpeed = 0.0025f;
    public bool hasLineOfSight = false;

    Vector2 waypoint;
    [SerializeField] float maxDistance;
    [SerializeField] float range;
    private Vector3 lastVelocity;
    public bool bounce = false;
    public float bounceTime;
    public float currentRotation;
    private Vector3 currDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int rotation = Random.RandomRange(0, 359);
        rb.rotation = rotation;

        

    }

    // Update is called once per frame
    void Update()
    {

        currentRotation = rb.rotation;
        lastVelocity = rb.velocity;
        if (!target)
        {
            getTarget();
        }
        

        else
        {
            if (hasLineOfSight)
            {
                RotateTowardsTarget();
                
            }
            //if(bounce)
            //{
            //    bounceTime = 1;

            //}
            //if(bounceTime > 0 && bounceTime < 2)
            //{
            //    bounceTime += Time.deltaTime;
            //    rb.rotation += 0.5f;
            //    bounce = false;

            //}
            //if(bounceTime >= 2)
            //{
            //    bounceTime = 0;
            //}
            
            
        }




    }

    private void FixedUpdate()
    {


        currDir = new Vector3(transform.position.x, transform.position.y, 0);
        RaycastHit2D ray = Physics2D.Raycast(transform.position, target.position - transform.position);
        if (ray.collider)
        {
            hasLineOfSight = ray.collider.CompareTag("Player");
        }
        if (hasLineOfSight)
        {
            rb.velocity = transform.up * speed;
            Debug.DrawRay(transform.position, target.position - transform.position, Color.green);
        }
        else
        {
         
            rb.velocity = transform.up * speed;
            Debug.DrawRay(transform.position, target.position - transform.position, Color.red);
        }
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

    private void bounceOffWal()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Inverse(transform.localRotation), 1);

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
        else if (other.gameObject.CompareTag("Wall"))
        {
            Vector3 newDir = new Vector3(transform.position.x, transform.position.y, 0);
            float newDirValue = Mathf.Atan2(newDir.y - currDir.y, newDir.x - currDir.x);
            float newDirValueDeg = (180 / Mathf.PI) * newDirValue;
            transform.rotation = Quaternion.Euler(0, 0, newDirValueDeg);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            rb.rotation =  other.rigidbody.rotation - 180;
            other.rigidbody.rotation += rb.rotation - 180;
        }
    }

    private void setNewDistance()
    {
        waypoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }


   
}
