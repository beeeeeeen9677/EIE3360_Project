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

    public GameObject FlammenWerfer;
    public GameObject Luger;
    public GameObject MP40;
    public GameObject STG44;
    public GameObject PanzerFaust;
    public GameObject PanzerSchreck;
    public GameObject k98;
    public GameObject MG42;

    void Start()
    {
        // Start the shooting coroutine
        StartCoroutine(Shoot());

        // Hide all weapons initially
        DeactivateAllWeapons();

        // Activate weapon based on the game object's tag
        ActivateWeaponByTag(gameObject.tag);
    }

    void DeactivateAllWeapons()
    {
        FlammenWerfer.SetActive(false);
        Luger.SetActive(false);
        MP40.SetActive(false);
        STG44.SetActive(false);
        PanzerFaust.SetActive(false);
        PanzerSchreck.SetActive(false);
        k98.SetActive(false);
        MG42.SetActive(false);
    }

    void ActivateWeaponByTag(string enemyTag)
    {
        DeactivateAllWeapons();

        switch (enemyTag)
        {
            case "wehrmacht_a":
                Luger.SetActive(true);
                Debug.Log("Luger Active");
                break;
            case "wehrmacht_b":
                k98.SetActive(true);
                Debug.Log("k98 Active");
                break;
            case "wehrmacht_c":
                FlammenWerfer.SetActive(true);
                Debug.Log("FlammenWerfer Active");
                break;
            case "schutzstaffel_a":
                MG42.SetActive(true);
                Debug.Log("MG42 Active");
                break;
            case "schutzstaffel_b":
                STG44.SetActive(true);
                Debug.Log("STG44 Active");
                break;
            default:
                Debug.LogWarning("Unknown enemy tag: " + enemyTag);
                break;
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate and update the distance to the player
            distanceToPlayer = Vector3.Distance(player.position, transform.position);
            animator.SetInteger("Status_walk", 1);

            // If within shooting range, then shoot; otherwise, track the player
            if (distanceToPlayer <= shootingRange)
            {
                animator.SetLayerWeight(animator.GetLayerIndex("K9_status"), 1); // Activate K9_status layer

                // Set status_k98 parameter to trigger shooting animation
                animator.SetInteger("status_k98", 2); // Set status_k98 to 2 for aiming the weapon
            }
            else
            {
                // Move towards the player
                agent.SetDestination(player.position);

                // Set walking animation
                animator.SetInteger("Status_walk", 1);
                animator.SetLayerWeight(animator.GetLayerIndex("K9_status"), 0); // Activate K9_status layer
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
                // Perform shooting action here (e.g., instantiate a bullet, play shooting sound, etc.)

                yield return new WaitForSeconds(1); // Delay before transitioning back to not_running state
            }

            yield return null;
        }
    }
}
