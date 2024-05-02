using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameRoom3");
    }
    public void OpenInstructions()
    {
        SceneManager.LoadScene("instructionsScene");
    }

    public void tutorial()
    {
        SceneManager.LoadScene("GameRoom1");
    }
}
