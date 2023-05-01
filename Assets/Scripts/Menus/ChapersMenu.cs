using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapersMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Chaper1()
    {
        SceneManager.LoadScene(3);
    }
    public void Chaper2() 
    {
        SceneManager.LoadScene(4);
    }
    public void Chaper3()
    {
        SceneManager.LoadScene(5);
    }
    public void Back()
    {
        SceneManager.LoadScene(1);
    }

}
