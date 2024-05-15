using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public movement movement;
    public int scene;
    public GameObject player;
    public Animator animation;
    
    public void PlayGame()
    {
        
        start("GameRoom2");
    }
    public void PlayGame2()
    {
        start("GameRoom3");
        
    }
    public void PlayGame3()
    {
        start("GameRoom4");
    }
    public void OpenInstructions()
    {
        SceneManager.LoadScene("instructionsScene");
    }

    public void tutorial()
    {
        start("GameRoom1");
    }

    public void restart()
    {
        
       SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        scene = movement.scene.buildIndex;
        
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<movement>();
      
    }

    private IEnumerator start(string room)
    {
        animation.SetTrigger("Switch");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(room);

    }


}
