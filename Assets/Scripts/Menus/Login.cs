using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField Email_Input;
    public InputField Password_Input;
    public string inputEmail = "";
    public string inputPasswordv = "";

    public void InputEmail(string a)
    {
        a = Email_Input.text;
        
    }
    public void InputPassword()
    {
        //inputPassword = Password_Input.text;
        //Debug.Log(inputPassword.text);
    }
    public void LoginGame()
    {
        if (inputEmail!="")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("üres");
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }
}
