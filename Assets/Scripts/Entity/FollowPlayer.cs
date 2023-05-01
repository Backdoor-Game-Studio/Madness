using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 5f;
    public float fieldOfView = 90f;

    private void Start()
    {
        // Get the ground layer mask
        int groundLayerMask = LayerMask.GetMask("Ground");

        // Check if the entity is above the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayerMask))
        {
            // Adjust the entity position to be above the ground
            transform.position = hit.point + Vector3.up * 0.05f;
            Debug.Log("földön vok");
        }
    }

    private void Update()
    {
        // Check if player is within detection radius
        if (Vector3.Distance(player.position, transform.position) <= detectionRadius)
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Check if player is within field of view
            if (Vector3.Angle(directionToPlayer, transform.forward) <= fieldOfView / 2f)
            {
                // Rotate towards the player
                transform.rotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

                // Move towards the player
                transform.position += transform.forward * Time.deltaTime;
            }
        }
    }
}
