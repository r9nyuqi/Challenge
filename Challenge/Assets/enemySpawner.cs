using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPreFabs;
    [SerializeField] private bool canSpawn = true;
    private GameObject[] getCount;

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

        if(count > 1)
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
                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            
            
        }
    }
}
