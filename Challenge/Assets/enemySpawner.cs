using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] public float spawnRate;
    [SerializeField] private GameObject[] dropsPrefabs;
    [SerializeField] private bool canSpawn = true;
    private GameObject[] getCount;
    private GameObject[] getCount2;
    private GameObject[] getCount3;

    [SerializeField] private Transform top;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform bot;
    public float timer;


    public int maxDrops;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Spawner());
        timer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        
        getCount = GameObject.FindGameObjectsWithTag("Enemy");
        getCount2 = GameObject.FindGameObjectsWithTag("Enemy2");
        getCount3 = GameObject.FindGameObjectsWithTag("Enemy3");

        count = getCount.Length + getCount2.Length + getCount3.Length;

        if(count > maxDrops)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }
        

        timer += Time.deltaTime;

        if(timer >= spawnRate)
        {
            timer = 0;
            if(canSpawn)
            {
                int ran = Random.Range(1, 7);
                GameObject DropsToSpawn;
                if (ran >= 1 && ran <= 3)
                {
                    DropsToSpawn = dropsPrefabs[0];
                }
                else if (ran >= 3 && ran <= 5)
                {
                    DropsToSpawn = dropsPrefabs[1];
                }
                else
                {
                    DropsToSpawn = dropsPrefabs[2];
                }
               
                Instantiate(DropsToSpawn, transform.position, Quaternion.identity);
            }
        }

    

    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            print("spawning");
            //getCount = GameObject.FindGameObjectsWithTag("Enemy");
            //int count = getCount.Length;
            //if(count < 1)
            {
                yield return wait;
                int ran = Random.Range(0, dropsPrefabs.Length);
                GameObject DropsToSpawn = dropsPrefabs[ran];
                
                
               Instantiate(DropsToSpawn, transform.position, Quaternion.identity);
                

            }

        }
    }


   

}

