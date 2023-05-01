using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnim;

    private bool DoorOpen;
    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if(!DoorOpen)
        {
            Debug.Log("OpenDoor()");
            doorAnim.Play("OpenDoor", 0, 0.0f);
            DoorOpen = true;
        }
        else
        {
            Debug.Log("CloseDoor()");
            doorAnim.Play("CloseDoor",0,0.0f);
            DoorOpen = false;
        }
    }
}
