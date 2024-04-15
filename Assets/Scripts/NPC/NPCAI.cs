using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour
{
    public float followSpeed = 5f; // Adjust the follow speed as needed
    public Transform player;

    private UnityEngine.AI.NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (player == null)
        {
            Debug.LogError("Player transform not assigned to NPCAI script. Please assign the player transform.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        nav.SetDestination(player.position);
        nav.speed = followSpeed;
    }
}
