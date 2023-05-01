using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityMovement : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    private Vector3 rndVector;

    public static float speed = 100f;
    private float walk = speed;
    private float run = speed * 2f;
    //Entity use default gravity (9.81) with rigibody and box colider
    public float detectionRadius = 25f;
    public float fieldOfView = 180f;
    private bool isSeePlayer(Vector3 directionToPlayer)
    {

        // Check if player is within detection radius
        if (Vector3.Distance(player.position, transform.position) <= detectionRadius)
        {

            // Check if player is within field of view
            if (Vector3.Angle(directionToPlayer, transform.forward) <= fieldOfView)
            {
                return true;
            }
            // Check if player too close Entity
            else if (Vector3.Distance(player.position, transform.position) < 10f)
            {
                return true;
            }
            else return false;

        } else return false;
    }

    private void FollowPlayer()
    {

        // Move towards the player
        agent.destination = player.position;
        agent.speed = run;
     
    }

    private void Walking()
    {
            rndVector.x = agent.pathStatus == NavMeshPathStatus.PathComplete ? Random.Range(0, 1000) : rndVector.x;
            rndVector.z = agent.pathStatus == NavMeshPathStatus.PathComplete ? Random.Range(0, 1000) : rndVector.y;

            agent.destination = rndVector;
            agent.speed = walk;
    }

    private void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        if (isSeePlayer(directionToPlayer))
        {
            FollowPlayer();
        }
        else
        {
            Walking();
        }
    }
}
