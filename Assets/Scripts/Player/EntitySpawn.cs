using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using System;

public class EntitySpawn : MonoBehaviour
{
    public GameObject Entity;
    public Transform PlayerCamera;


    private void Start()
    {
        Entity.SetActive(false);
    }
    

    private void Update()
    {
        RaycastHit pillsHit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out pillsHit, 100))
        {
            
            if (pillsHit.transform.tag== "pills")
            {
                if(Input.GetKey(KeyCode.E))
                {
                    Destroy(pillsHit.transform.GameObject());
                    Entity.SetActive(true);
                    Invoke("NextMap", 1f);
                    
                    
                }
                
            }

        }
    }

    private void NextMap()
    {
        SceneManager.LoadScene(4);
    }
}
