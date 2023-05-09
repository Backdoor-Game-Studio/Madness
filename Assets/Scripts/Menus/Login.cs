using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using System.IO;
using System.Net;
using UnityEngine.Networking;
using System;
using System.Text;

public class Login : MonoBehaviour
{
    public InputField Username_Input;
    public InputField Password_Input;
    public TextMeshProUGUI errorText;
    public static string resultData = "Loading";

    public static string inputUsername = "";
    public static string inputPassword = "";

    private static string pattern = "^[A-Za-z0-9_\\.]+$";
    Regex rg = new Regex(pattern);

    void Start()
    {
        errorText.text = "";

    }

    public void usernameInput(string username)
    {
        inputUsername = username;
    }
    public void passwordInput(string password)
    {
        inputPassword = password;
    }

    private string inputValidCheck()
    {
        if (inputUsername == "" || inputPassword == "") return "Username or Password input is empty!";
        if (inputUsername.Length < 6 || inputUsername.Length > 16 || inputPassword.Length < 6) return "The username must be between 6 and 16 characters, password must be at least 6 characters long!";
        if (!rg.IsMatch(inputUsername)) return "The username can only contain upper and lower case letters of the English alphabet, numbers, low line and dot characters!";

        return "";
    }

    IEnumerator LoginApi(string url, string json)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            resultData = request.downloadHandler.text;
            if (request.downloadHandler.text.Contains("accessToken"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else errorText.text = request.downloadHandler.text;
        }
        else
        {
            Debug.Log("POST request failed: " + request.error);
        }
    }

    private struct loginStruct
    {
        public string username;
        public string password;
    }

    public void LoginGame()
    {
        if (inputValidCheck() == "")
        {
            string url = "https://api.backdoorgame.studio/auth/login";

            loginStruct loginData = new loginStruct();
            loginData.username = inputUsername;
            loginData.password = inputPassword;

            string payload = JsonUtility.ToJson(loginData);
            StartCoroutine(LoginApi(url, payload));
        }
        else errorText.text = inputValidCheck();

    }
    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }
}
