using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimatorController : MonoBehaviour
{
    public Animator animator; // Enemy's Animator component
    public NavMeshAgent agent; // Enemy's NavMeshAgent component
    public Transform player; // Player's Transform component

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
        // Set walking animation
        animator.SetInteger("Status_walk", 1);

        // Activate the corresponding weapon status based on the active weapon
        SetWeaponStatus();

        // Set aiming animation for the active weapon
        SetAimingAnimation();
    }

    void SetWeaponStatus()
    {
        if (Luger.activeSelf)
        {
            animator.SetInteger("Status_LugerP08", 2); // Set status_Luger to 2 for aiming the Luger
        }
        else if (k98.activeSelf)
        {
            animator.SetInteger("status_k98", 2); // Set status_k98 to 2 for aiming the k98
        }
        else if (FlammenWerfer.activeSelf)
        {
            animator.SetInteger("Flammenwerfer_status", 2); // Set status_FlammenWerfer to 2 for aiming the FlammenWerfer
        }
        else if (MG42.activeSelf)
        {
            animator.SetInteger("Status_MG42", 2); // Set status_MG42 to 2 for aiming the MG42
        }
        else if (STG44.activeSelf)
        {
            animator.SetInteger("Status_stg44", 2); // Set status_STG44 to 2 for aiming the STG44
        }
    }

    void SetAimingAnimation()
    {
        // Perform aiming animation based on the active weapon, no need to check player's position
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            // Check if the active weapon status equals 2 for aiming
            // Perform shooting action here (e.g., instantiate a bullet, play shooting sound, etc.)

            yield return new WaitForSeconds(1); // Delay before transitioning back to not_running state

            yield return null;
        }
    }
}
