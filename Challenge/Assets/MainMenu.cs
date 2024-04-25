using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameRoom1");
    }
    public void OpenInstructions()
    {
        SceneManager.LoadScene("instructionsScene");
    }
}
