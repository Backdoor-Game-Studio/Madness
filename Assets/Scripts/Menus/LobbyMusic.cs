using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMusic : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("LobbyMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
