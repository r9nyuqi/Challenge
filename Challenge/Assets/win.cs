using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class win : MonoBehaviour
{
    public int roomIndex;
    // Start is called before the first frame update
    void Start()
    {
        roomIndex = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            print("test");
            StartCoroutine(Win());
        }
    }

    private IEnumerator Win()
    {
        WaitForSeconds sec = new WaitForSeconds(2);
        if (true)
        {
            yield return sec;
            
            SceneManager.LoadScene(roomIndex, LoadSceneMode.Single);
        }
    }
}
