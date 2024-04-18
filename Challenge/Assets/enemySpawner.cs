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
                
                int ran = Random.Range(0, enemyPreFabs.Length);
                GameObject enemyToSpawn = enemyPreFabs[ran];
                
               
                Instantiate(enemyToSpawn, getSpawnableArea(), Quaternion.identity);
                
                
            
            
        }
    }



    private Vector3 getSpawnableArea()
    {
        int count = 0;
        int max = 200;
        int notSpawn1 = LayerMask.NameToLayer("Wall");
        int notSpawn2 = LayerMask.NameToLayer("Player");

        bool valid = false;
        float x = Random.RandomRange(-8, 24);
        float y = Random.RandomRange(-4, 14);
        Vector3 position = new Vector3(x, y, 0);

        while (!valid && count < max)
        {
            x = Random.RandomRange(-8, 24);
            y = Random.RandomRange(-4, 14);
            position = new Vector3(x, y, 0);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 3f);
            bool isInvalidCollision = false;
            foreach (Collider2D collider in colliders)
            {
                if(collider.gameObject.layer == notSpawn1 || collider.gameObject.layer == notSpawn2)
                {
                    print("hit");
                    isInvalidCollision = true;
                    break;
                }
            }

            if(!isInvalidCollision)
            {
                valid = true;
            }
            count++;
        }

        if(!valid)
        {
            Debug.LogWarning("no available spawn");
        }

        return position;

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
