using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }
    public void Chapters()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }
    public void Logout()
    {
        Debug.Log("Logging out");
    }
}
