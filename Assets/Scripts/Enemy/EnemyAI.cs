using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float chaseSpeed = 100f;
    public float chaseRange = 100f;
    public Transform[] waypoints;

    private UnityEngine.AI.NavMeshAgent nav;
    private Transform player;
    private Vector3 lastPlayerPosition;
    private bool isChasingPlayer = false;
    private int currentWaypointIndex = 0;

    void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        SetNextWaypoint();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            isChasingPlayer = true;
            ChasePlayer();
        }
        else
        {
            isChasingPlayer = false;
            PatrolBetweenWaypoints();
        }
    }

    void ChasePlayer()
    {
        if (!nav.enabled) return;

        nav.SetDestination(player.position);
        nav.speed = chaseSpeed;
        lastPlayerPosition = player.position;
    }

    void PatrolBetweenWaypoints()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints found. Please assign waypoints to the EnemyAI script.");
            return;
        }

        if (!isChasingPlayer)
        {
            if (nav.remainingDistance < 0.5f)
            {
                SetNextWaypoint();
            }
        }
    }

    void SetNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        nav.SetDestination(waypoints[currentWaypointIndex].position);
        nav.speed = chaseSpeed;

        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}
