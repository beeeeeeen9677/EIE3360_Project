using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimatorController : MonoBehaviour
{
    public Animator animator; // Enemy's Animator component
    public NavMeshAgent agent; // Enemy's NavMeshAgent component
    public Transform player; // Player's Transform component
    public float shootingRange = 100f; // Shooting range

    private float distanceToPlayer; // Distance to the player

    void Start()
    {
        // Start the shooting coroutine
        StartCoroutine(Shoot());
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate and update the distance to the player
            distanceToPlayer = Vector3.Distance(player.position, transform.position);

            // If within shooting range, then shoot; otherwise, track the player
            if (distanceToPlayer <= shootingRange)
            {
                // Stop moving
                agent.isStopped = true;

                // Set shooting animation layer, using status_k98 parameter
                animator.SetBool("Status_Shooting", false); // Stop previous shooting animation if any
                animator.SetLayerWeight(animator.GetLayerIndex("K9_status"), 1); // Activate K9_status layer

                // Set status_k98 parameter to trigger shooting animation
                animator.SetInteger("status_k98", 2); // Set status_k98 to 2 for aiming the weapon
            }
            else
            {
                // Move towards the player
                agent.isStopped = false;
                agent.SetDestination(player.position);

                // Set walking animation
                animator.SetInteger("Status_walk", 1);

                // Ensure shooting animation is stopped
                animator.SetLayerWeight(animator.GetLayerIndex("K9_status"), 0); // Deactivate K9_status layer
            }
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            // Check if status_k98 equals 2 for aiming weapon
            if (animator.GetInteger("status_k98") == 2)
            {
                // Transition to Aim_weapon state
                animator.SetInteger("status_k98", 0); // Set status_k98 to 0 to return to not_running state

                // Perform shooting action here (e.g., instantiate a bullet, play shooting sound, etc.)

                yield return new WaitForSeconds(1); // Delay before transitioning back to not_running state
            }

            yield return null;
        }
    }
}
