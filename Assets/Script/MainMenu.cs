using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ClickToStart()
    {
        Debug.Log("Start Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ClickToQuit()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
