using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EntityMovement : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    private Vector3 rndVector;
    private Animator animator;

    public static float speed = 10000f;
    private float walk = speed;
    private float run = speed * 2f;
    //Entity use default gravity (9.81) with rigibody and box colider
    public float detectionRadius = 1000f;
    public float fieldOfView = 180f;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
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
            else if (Vector3.Distance(player.position, transform.position) < 100f)
            {
                return true;
            }
            else return false;

        } else return false;
    }

    private void FollowPlayer(Vector3 Player)
    {
        Debug.Log("chasing");
        // Move towards the player
        agent.destination = player.position;
        //agent.SetDestination(Player);
        agent.speed = run;

        if (Vector3.Distance(player.position, transform.position) < 100f)
        {
            SceneManager.LoadScene(7);
        }


    }

    private void Walking()
    {
        Debug.Log("walking");
            rndVector.x = agent.pathStatus == NavMeshPathStatus.PathComplete ? Random.Range(0, 10000) : rndVector.x;
            rndVector.z = agent.pathStatus == NavMeshPathStatus.PathComplete ? Random.Range(0, 10000) : rndVector.y;

            agent.destination = rndVector;
            agent.speed = walk;
    }

    private void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        if (isSeePlayer(directionToPlayer))
        {
            FollowPlayer(directionToPlayer);
        }
        else
        {
            Walking();
        }
    }
}
