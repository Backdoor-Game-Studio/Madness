using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System;
public class Ending : MonoBehaviour
{



    public Transform PlayerCamera;

    private void Update()
    {
        RaycastHit pillsHit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out pillsHit, 100))
        {

            if (pillsHit.transform.tag == "pills")
            {
                if (Input.GetKey(KeyCode.E))
                {

                    SceneManager.LoadScene(6);
                }

            }

        }
    }
}
