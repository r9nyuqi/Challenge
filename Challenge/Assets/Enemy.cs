using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed;
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
    public bool loss = false;
    public float lossTime;
    public int roomIndex;

    public float vTimer;
    public bool vStart = false;
    private Vector3 direction = new Vector3(1,1,0);
    public float timer;
    public bool spawn;
    
   
    // Start is called before the first frame update
    void Start()
    {

        
        roomIndex = 2;
        float angleChange = Random.Range(-90f, 90f);
        Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
        direction = rotation * direction;
        spawn = true;
       


    }

    // Update is called once per frame
    void Update()
    {
        //if(rb.velocity.x <0.5 && rb.velocity.y <0.5)
        //{
        //    rb.AddForce(transform.up * 15f);
        //}
        currentRotation = rb.rotation;
        lastVelocity = rb.velocity;

        timer += Time.deltaTime;


        if(timer >= 1)
        {
            spawn = false;
        }
        
        if(Mathf.Abs(rb.velocity.y) <= 0.01 && Mathf.Abs(rb.velocity.x) <= 0.01 && !vStart)
        {
            vTimer = (float)0.01;
            vStart = true;

           
        }
        if(Mathf.Abs(rb.velocity.y) > 0.01 || Mathf.Abs(rb.velocity.x) > 0.01)
        {
            vTimer = 0;
            vStart = false;
        }
        if (vTimer > 0.00 && vTimer < 2)
        {
            vTimer += Time.deltaTime;
        }
        else if (vTimer >= 2)
        {
            Destroy(gameObject);
        }


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
            rb.velocity = transform.up * (speed+1);
            Debug.DrawRay(transform.position, target.position - transform.position, Color.green);
        }
        else
        {
         
            rb.velocity = direction * speed;
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
           
            
            
          
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("rightclick"))
        {
           
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            
           
            var speed = lastVelocity.magnitude;
            direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
          
            
        }

        
        //else if (other.gameObject.CompareTag("Wall"))
        //{
        //    Vector3 newDir = new Vector3(transform.position.x, transform.position.y, 0);
        //    float newDirValue = Mathf.Atan2(newDir.y - currDir.y, newDir.x - currDir.x);
        //    float newDirValueDeg = (180 / Mathf.PI) * newDirValue;
        //    transform.rotation = Quaternion.Euler(0, 0, newDirValueDeg);
        //}
        //else if (other.gameObject.CompareTag("Enemy"))
        //{
        //    rb.rotation =  other.rigidbody.rotation - 180;
        //    other.rigidbody.rotation += rb.rotation - 180;
        //}
    }

    

    private void setNewDistance()
    {
        waypoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }


   
}
