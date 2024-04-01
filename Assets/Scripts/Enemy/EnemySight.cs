using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;   // Number of degrees, centred on forward, for the enemy see.
    public bool playerInSight;              // Whether or not the player is currently sighted.
    public Vector3 personalLastSighting;    // Last place this enemy spotted the player.
    public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);    // The default position if the player is not in sight.

    private UnityEngine.AI.NavMeshAgent nav;   // Reference to the NavMeshAgent component.
    private SphereCollider col; // Reference to the sphere collider trigger component.
    private Animator anim;              // Reference to the Animator.
    private GameObject player;          // Reference to the player.
    private Animator playerAnim;        // Reference to the player's animator component.
    private PlayerHealth playerHealth;  // Reference to the player's health script.
    private HashIDs hash;               // Reference to the HashIDs.

    void Awake()
    {
        // Setting up the references.
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(Tags.player);
        playerAnim = player.GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

        // Set the personal sighting and the previous sighting to the reset position.
        personalLastSighting = resetPosition;
    }

    void Update()
    {
        // If the player is alive...
        if (playerHealth.health > 0f)
            // ... set the animator parameter to whether the player is in sight or not.
            anim.SetBool(hash.playerInSightBool, playerInSight);
        else
            // ... set the animator parameter to false.
            anim.SetBool(hash.playerInSightBool, false);
    }

    void OnTriggerStay(Collider other)
    {
        // If the player has entered the trigger sphere...
        if (other.gameObject == player)
        {
            // By default the player is not in sight.
            playerInSight = false;

            
	// Create a vector from the enemy to the player and store the angle between it and forward.
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            // If the angle between forward and where the player is, is less than half the angle of view...
            if (angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                // ... and if a raycast towards the player hits something...
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    // ... and if the raycast hits the player...
                    if (hit.collider.gameObject == player)
                    {
                        // ... the player is in sight.
                        playerInSight = true;
                    }
                }
            }

            // Store the name hashes of the current states.
            int playerLayerZeroStateHash = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;
            int playerLayerOneStateHash = playerAnim.GetCurrentAnimatorStateInfo(1).fullPathHash;

            // If the player is running or is attracting attention...
            if (playerLayerZeroStateHash == hash.locomotionState || playerLayerOneStateHash == hash.shoutState)
            {
                // ... and if the player is within hearing range...
                if (CalculatePathLength(player.transform.position) <= col.radius)
                    // ... set the last personal sighting of the player to the player's current position.
                    personalLastSighting = player.transform.position;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the player leaves the trigger zone...
        if (other.gameObject == player)
            // ... the player is not in sight.
            playerInSight = false;
    }

    float CalculatePathLength(Vector3 targetPosition)
    {
        // Create a path and set it based on a target position.
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
        if (nav.enabled)
            nav.CalculatePath(targetPosition, path);

        // Create an array of points which is the length of the number of corners in the path + 2.
        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

        // The first point is the enemy's position.
        allWayPoints[0] = transform.position;

        // The last point is the target position.
        allWayPoints[allWayPoints.Length - 1] = targetPosition;

        


      // The points inbetween are the corners of the path.
        for (int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }

        // Create a float to store the path length that is by default 0.
        float pathLength = 0;

        // Increment the path length by an amount equal to the distance between each waypoint and the next.
        for (int i = 0; i < allWayPoints.Length - 1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }

        return pathLength;
    }
}