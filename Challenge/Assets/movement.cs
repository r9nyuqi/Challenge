using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    
    public Sprite white = Resources.Load<Sprite>("whiteSquare");
    public Sprite red = Resources.Load<Sprite>("redSwatch");
    public SpriteRenderer render;
    bool faceRight = true;
    float horizontalInput;
    float verticalInput;
    public float movespeed = 5f;
    public Rigidbody2D rb;
    public float qTimer = 0;
    public String qDisplay;
    public float wTimer = 0;
    public String wDisplay;
    public float eTimer = 0;
    public float fTimer = 0;
    public String eDisplay;
    public String fDisplay;
    public bool loadQ = true;
    public bool loadW = true;
    public bool loadE = true;
    public bool loadF = true;
    bool isQ = false;
    bool isW = false;
    public bool isE = false;
    public bool isF = false;


    private bool isDash = false;
  
    public float dashPower = 24f;
    public float dashTime = 0.2f;
    public float eTime = 0;
    public float fTime = 0;
    public float speedTime = 0;
    public bool speed = false;

    //Jonathan - Sound Fx
    public AudioSource myFx;
    public AudioClip DashFx;

    [SerializeField] private TrailRenderer tr;

    public Image healthBar;
    public float health = 100;
    public SpriteRenderer sp;

    public bool hasrightclick = false;

    public Light2D light;

    public Enemy enemy;
    public Enemy2 enemy2;
    public Enemy3 enemy3;
    public bool isheal = false;
    public float healtimer = 0;

    public AudioSource healSound;
    public AudioSource powerUp;
    public AudioSource dash;
    public AudioSource hit;
    // Start is called before the first frame update

    Vector2 move;
    Animator animator;

    public Scene scene;
    

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        

        if (isheal)
        {
            healtimer += Time.deltaTime;
            light.color = new Color(0, 1, 0, 1);
        }
        if(healtimer >= 0.5)
        {
            isheal = false;
            healtimer = 0;
            
        }
        if (hasrightclick && !isheal)
        {
            light.color = new Color(1, 0, 1, 1);
        }
        if(!hasrightclick && !isheal)
        {
            light.color = new Color(1, 1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            print(SceneManager.GetActiveScene().name); 
            if (SceneManager.GetActiveScene().name.Equals("GameRoom1") || SceneManager.GetActiveScene().name.Equals("GameRoom2"))
            {
                StartCoroutine(Skip());
            }
        }
        
        if (health <= 0)
        {
            scene = SceneManager.GetActiveScene();
           
            if (scene.name.Equals("GameRoom2"))
            {
                SceneManager.LoadScene("LossRoom");
            }
            else if(scene.name.Equals("GameRoom3"))
            {
                SceneManager.LoadScene("LossRoom2");
            }
            else if(scene.name.Equals("GameRoom4"))
            {
                SceneManager.LoadScene("LossRoom3");
            }


            //sp.enabled = false;
            //StartCoroutine(Loss());


        }
        if(!Input.GetKey(KeyCode.E))
        {
            move.x = Input.GetAxisRaw("Horizontal");

            horizontalInput = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        if (eTimer > 0)
        {
            eTimer -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E) && !isE && eTimer <= 0 && loadE && eTime ==0)
        {
            dash.Play(); 
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


        if (fTimer > 0)
        {
            fTimer -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.F) && fTimer <= 0 && loadF)
        {

           
            fTimer = (float)(5);
            loadF = false;
            


        }
        if(Input.GetKey(KeyCode.Mouse1) && hasrightclick)
        {
            
            hasrightclick = false;
        }
        //if (fTime > 0 && fTime < 0.25 && isF)
        //{
        //    eTime += Time.deltaTime;
        //    tr.emitting = true;
        //}
        //else if (eTime >= 0.25)
        //{
        //    tr.emitting = false;
        //    movespeed = 5f;
        //    isE = false;
        //    eTime = 0;

        //}
        if (Input.GetKeyUp(KeyCode.F))
        {
            loadF = true;
        }
        fDisplay = updateTimer(fTimer);

        

    }

    private void heal(float h)
    {
        if(health + h > 100)
        {
            health = 100;
        }
        else
        {
            health += h;
        }
        
        healthBar.fillAmount = health / 100;
    }

    private void FixedUpdate()
    {
       
        //rb.MovePosition(rb.position + move * movespeed * Time.deltaTime);
        rb.velocity = new Vector2(horizontalInput * movespeed, verticalInput * movespeed);
        //animator.SetFloat("speed", Math.Abs(rb.velocity.x) + Math.Abs(rb.velocity.y));

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
        //Jonathan - sound fx
        myFx.PlayOneShot(DashFx);
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        isDash = false;
        
    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("drops"))
        {
            isheal = true;
            Destroy(other.gameObject);
            heal(20);
            healSound.Play();
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(enemy.spawn || enemy.isdie)
            {
                
                
            }
            else
            {
                TakeDamage(10);
            }
            
        }
        if (other.gameObject.CompareTag("Enemy2"))
        {
            if (enemy2.spawn || enemy2.isdie)
            {


            }
            else
            {
                TakeDamage(10);
            }

        }

        if (other.gameObject.CompareTag("Enemy3"))
        {
            if (enemy3.spawn || enemy3.isdie)
            {


            }
            else
            {
                TakeDamage(10);
            }

        }


        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            TakeDamage(10);
        }

        if(other.gameObject.CompareTag("rightclickdrop"))
        {
            if(!hasrightclick)
            {
                Destroy(other.gameObject);
                hasrightclick = true;
                powerUp.Play();
                    
                
            }
        }
        if (other.gameObject.CompareTag("NavEnemy"))
        {
            transform.position = new Vector2((float)-7.97, (float)-3.9);
        }

    }

    public bool getHasRightClick()
    {
        return hasrightclick;
    }

    public void TakeDamage(float damage)
    {
        hit.Play();
        health -= damage;
        healthBar.fillAmount = health / 100;
    }

    private IEnumerator Loss()
    {
        WaitForSeconds wait = new WaitForSeconds(3);

        print("Test1");

        yield return wait;
        print("test");
        SceneManager.LoadScene("LossRoom");
        Destroy(gameObject);



    }

    private IEnumerator Skip()
    {
        WaitForSeconds wait = new WaitForSeconds(3);


        if (true)
        {

            yield return wait;
            print("test");
            SceneManager.LoadScene("GameRoom3");


        }
    }

}
