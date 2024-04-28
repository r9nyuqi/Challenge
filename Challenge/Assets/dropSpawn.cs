using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropSpawn : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] dropsPrefabs;
    [SerializeField] private bool canSpawn = true;
    private GameObject[] getCount;

    [SerializeField] private Transform top;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform bot;

 

    public int maxDrops;

    public int count;

    public float radius;

    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("drops");
        count = getCount.Length;



        if (count > maxDrops)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            if (canSpawn)
            {
                int ran = Random.Range(0, dropsPrefabs.Length);
                GameObject DropsToSpawn = dropsPrefabs[ran];
                int ranX = (int)Random.Range(left.position.x, right.position.x);
                int ranY = (int)Random.Range(bot.position.y, top.position.y);
                Vector2 pos = new Vector2(ranX, ranY);
                if (notOverlapWall(pos))
                {
                    Instantiate(DropsToSpawn, pos, Quaternion.identity);
                }
            }
            timer = 0;
        }
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            //getCount = GameObject.FindGameObjectsWithTag("Enemy");
            //int count = getCount.Length;
            //if(count < 1)
            {

                yield return wait;
                int ran = Random.Range(0, dropsPrefabs.Length);
                GameObject DropsToSpawn = dropsPrefabs[ran];
                int ranX = (int)Random.Range(left.position.x, right.position.x);
                int ranY = (int)Random.Range(bot.position.y, top.position.y);
                Vector2 pos = new Vector2(ranX, ranY);

                if (notOverlapWall(pos))
                {
                    Instantiate(DropsToSpawn, pos, Quaternion.identity);
                }

            }

        }


    }

    private bool notOverlapWall(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius);
        return (colliders.Length == 0);
    }


}

