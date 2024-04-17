using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPreFabs;
    [SerializeField] private bool canSpawn = true;
    private GameObject[] getCount;
    public int maxEnemy;

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

        if(count > maxEnemy)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }

    }

    
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        
  
        while(canSpawn)
        {

                
                yield return wait;
                float x = Random.RandomRange(-8, 24);
                float y = Random.RandomRange(-4, 14);
                Vector3 pos = new Vector3(x, y, 0);
                int ran = Random.Range(0, enemyPreFabs.Length);
                GameObject enemyToSpawn = enemyPreFabs[ran];
                
               
                Instantiate(enemyToSpawn, pos, Quaternion.identity);
                
                
            
            
        }
    }

    private void OnCollisionEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Win"))
        {
            float x = Random.RandomRange(-8, 24);
            float y = Random.RandomRange(-4, 14);
            transform.position = new Vector3(x, y, 0);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            print("wall");
            float x = Random.RandomRange(-8, 24);
            float y = Random.RandomRange(-4, 14);
            transform.position = new Vector3(x, y, 0);
        }

    }


}
