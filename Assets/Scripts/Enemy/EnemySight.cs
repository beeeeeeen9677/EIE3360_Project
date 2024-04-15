using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public float detectionRange = 10f;
    public LayerMask playerLayer;

    [HideInInspector]
    public Transform player;
    [HideInInspector]
    public bool playerDetected = false;

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Player"))
            {
                player = col.transform;
                playerDetected = true;
                break;
            }
        }

        if (!playerDetected)
        {
            player = null;
        }
    }
}
