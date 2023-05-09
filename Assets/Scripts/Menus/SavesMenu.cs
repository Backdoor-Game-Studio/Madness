using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public Save Save;
    public Position Position;
    public Items Items;
}

[System.Serializable]
public class Save
{
    public string name;
    public string utc;
    public string date;
    public string time;
}

[System.Serializable]
public class Position
{
    public string map;
    public Coordinates player;
    public Coordinates entity;
}

[System.Serializable]
public class Coordinates
{
    public string x;
    public string y;
    public string z;
}

[System.Serializable]
public class Items
{
    public Flashlight flashlight;
}

[System.Serializable]
public class Flashlight
{
    public string power;
    public string batterylevel;
}

[System.Serializable]
public class SaveDataCollection
{
    public SaveData[] data;
}

public class SavesMenu : MonoBehaviour
{
    private struct Tokens
    {
        public string accessToken;
        public string refreshToken;
    }

    public string username = Login.inputUsername;
    public string password = Login.inputPassword;

    public static string resultData = Login.resultData;
    Tokens dataObject = JsonUtility.FromJson<Tokens>(resultData);

    private static string url = "https://api.backdoorgame.studio/saves/getsaves";

    //private void Start()
    //{
    //    StartCoroutine(Saves(url, dataObject.accessToken));
    //}


    IEnumerator Saves(string url, string bearer)
    {
        var request = new UnityWebRequest(url, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + bearer);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(request.downloadHandler.text);
            viewSave(request.downloadHandler.text.Replace("\"data\":", ""));
        }
        else
        {
            Debug.Log("GET request failed: " + request.error);
        }

    }

    private void viewSave(string json)
    {

        SaveDataCollection data = JsonUtility.FromJson<SaveDataCollection>(json);

        Debug.Log(data.data[0].Save.name);


    }


    // Start is called before the first frame update
    public void Save1()
    {
        
    }
    public void Save2() 
    {
        
    }
    public void Save3()
    {
        
    }
    public void Save4()
    {
        
    }
    public void Save5()
    {
        
    }
    public void Back()
    {
        SceneManager.LoadScene(1);
    }

}
