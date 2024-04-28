using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] public float spawnRate;
    [SerializeField] private GameObject[] dropsPrefabs;
    [SerializeField] private bool canSpawn = true;
    private GameObject[] getCount;

    [SerializeField] private Transform top;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform bot;
    


    public int maxDrops;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
        getCount = GameObject.FindGameObjectsWithTag("Enemy");
        count = getCount.Length;

        canSpawn = true;
        
        

    

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

