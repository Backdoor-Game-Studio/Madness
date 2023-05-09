using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDied : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Restart()
    {
        SceneManager.LoadScene(4);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
