using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float chaseSpeed = 1000000f;       // Increase chase speed for faster pursuit.

    private UnityEngine.AI.NavMeshAgent nav;           // Reference to the nav mesh agent.
    private Transform player;            // Reference to the player's transform;
    private Vector3 lastPlayerPosition;  // Store the last known position of the player.

    void Awake()
    {
        // Setting up the references.
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming your player has a tag "Player"
    }

    void Update()
    {
        // Always chase the player
        ChasePlayer();
    }

    void ChasePlayer()
    {
        // Ensure nav mesh agent is enabled before setting destination
        if (!nav.enabled) return;

        // Set the destination for the NavMeshAgent to the player's position or last known position.
        Vector3 targetPosition = player.position;

        // If the player is moving, update the target position to the last known player position.
        if (player.position != lastPlayerPosition)
        {
            targetPosition = lastPlayerPosition;
        }

        // Set the destination for the NavMeshAgent.
        nav.SetDestination(targetPosition);

        // Set the appropriate speed for the NavMeshAgent.
        nav.speed = chaseSpeed;

        // Update the last known player position.
        lastPlayerPosition = player.position;
    }
}