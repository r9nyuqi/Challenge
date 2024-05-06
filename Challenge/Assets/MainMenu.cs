using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public movement movement;
    public int scene;
    public void PlayGame()
    {
        SceneManager.LoadScene("GameRoom3");
    }
    public void PlayGame2()
    {
        SceneManager.LoadScene("GameRoom4");
    }
    public void OpenInstructions()
    {
        SceneManager.LoadScene("instructionsScene");
    }

    public void tutorial()
    {
        SceneManager.LoadScene("GameRoom1");
    }

    public void restart()
    {
       SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        scene = movement.scene.buildIndex;
        
    }
}
