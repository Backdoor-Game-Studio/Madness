using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform PlayerCamera;

    public bool key0 = false;
    public bool key1 = false;
    public bool key2 = false;
    public float MaxDistance = 5;

    private void useDoor(RaycastHit door)
    {

        switch (door.transform.GameObject().name)
        {
            case "Door0":
                if (key0)
                {
                    Destroy(door.transform.GameObject());
                    return;
                }
                else return;

            case "Door1":
                if (key1)
                {
                    Destroy(door.transform.GameObject());
                    return;
                }
                else return;

            case "Door2":
                if (key2)
                {
                    Destroy(door.transform.GameObject());
                    return;
                }
                else return;
        }

        //Z�r n�lk�li ajt� script
        Destroy(door.transform.GameObject());
    }

    private void targetIsDoor()
    {
        RaycastHit doorHit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorHit, MaxDistance))
        {
            if (doorHit.transform.tag == "Door")
            {
                useDoor(doorHit);
            }

        }
    }

    private void targetIsKey()
    {
        RaycastHit keyHit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out keyHit, MaxDistance))
        {
            if (keyHit.transform.tag == "Key")
            {
                setKeyToInventory(keyHit);
            }

        }
    }

    private void setKeyToInventory(RaycastHit key)
    {

        switch (key.transform.GameObject().name)
        {
            case "Key0":
                key0 = true;
                Destroy(key.transform.GameObject());
                break;

            case "Key1":
                key1 = true;
                Destroy(key.transform.GameObject());
                break;

            case "Key2":
                key2 = true;
                Destroy(key.transform.GameObject());
                break;

            default:
                break;
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            targetIsKey();
            targetIsDoor();
        }
    }
}
