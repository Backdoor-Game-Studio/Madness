using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System;
public class Sleeping : MonoBehaviour
{


    
    public Transform PlayerCamera;

    private void Update()
    {
        RaycastHit bedHit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out bedHit, 100))
        {

            if (bedHit.transform.tag == "Bed")
            {
                if (Input.GetKey(KeyCode.E))
                {
                   
                    SceneManager.LoadScene(5);
                }

            }

        }
    }
}
