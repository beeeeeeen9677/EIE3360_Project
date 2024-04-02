using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float shootingRange = 10f; // Range within which the enemy will shoot
    public float damagePerShot = 20f; // Damage inflicted per shot
    public float shotInterval = 1f; // Interval between shots
    public AudioClip shotClip; // Audio clip for the shot

    private Transform player; // Reference to the player's transform
    private PlayerHealth playerHealth; // Reference to the player's health
    private bool canShoot = true; // Flag to control shooting interval

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= shootingRange && canShoot)
        {
            Shoot();
            canShoot = false;
            StartCoroutine(ResetShotInterval());
        }
    }

    void Shoot()
    {
        // Play the gunshot sound
        AudioSource.PlayClipAtPoint(shotClip, transform.position);

        // Reduce player's health
        playerHealth.TakeDamage(damagePerShot);
        Debug.Log(playerHealth);
    }

    IEnumerator ResetShotInterval()
    {
        yield return new WaitForSeconds(shotInterval);
        canShoot = true;
    }
}
