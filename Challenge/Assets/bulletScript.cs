using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float timer = 0;

    [SerializeField] private FieldOfView fieldofView;

    public AudioSource hit;

    float rot;

    Vector3 direction;
    Vector3 rotation;
    Vector3 startingPos;
    Vector3 previousPosition = Vector3.zero;

    [SerializeField] Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;
        rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        startingPos = transform.position;

        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(target == null && (rb.velocity.x == 0 || rb.velocity.y == 0))
        {
            Destroy(gameObject);
        }

        
            Vector3 currentPosition = rb.position;
            Vector3 currentDirection = (currentPosition - previousPosition).normalized;
            fieldofView.setOrigin(transform.position);
           
            previousPosition = currentDirection;
        
       
        if (timer < 5)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);

        }
        if (other.gameObject.CompareTag("Enemy1"))
        {
            hit.Play();

        }
        if (other.gameObject.CompareTag("Enemy2"))
        {
            hit.Play();

        }
        if (other.gameObject.CompareTag("Enemy3"))
        {
            hit.Play();

        }
        if (other.gameObject.CompareTag("boss"))
        {
            hit.Play();

        }
    }



}
