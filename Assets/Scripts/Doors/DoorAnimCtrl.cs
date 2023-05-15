using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimCtrl : MonoBehaviour
{
  private Animator animator;
    private bool doorOpen=false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if(!doorOpen)
        {
            animator.Play("OpenDoor", 0, 0f);
            doorOpen = true;
        }
        else
        {
            animator.Play("CloseDoor", 0, 0f);
            doorOpen = false;
        }
        

        
    }

}
