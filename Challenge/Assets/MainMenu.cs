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
    public float timer;
    public bool started = false;
    public string room;
    public Canvas canvas;
    public void PlayGame()
    {
        
        
    }
    public void PlayGame2()
    {
        room = "GameRoom3";
        started = true;

    }
    public void PlayGame3()
    {
        started = true;
        room = "GameRoom4";
    }
    public void OpenInstructions()
    {
        SceneManager.LoadScene("instructionsScene");
    }

    public void tutorial()
    {
        room = "GameRoom1";
        started = true;
    }

    public void restart()
    {
        
       SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        scene = movement.scene.buildIndex;

        if(started)
        {

            timer = 1;
            animation.SetTrigger("Switch");
            started = false;
            canvas.sortingOrder = -100;
        }
        if(timer > 0 && timer < 5.2)
        {
            timer += Time.deltaTime;
        }
        else if (timer >= 5.2)
        {
            SceneManager.LoadScene(room);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<movement>();
      
    }

    


}
