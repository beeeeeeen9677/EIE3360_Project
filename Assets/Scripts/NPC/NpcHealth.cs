using UnityEngine;

public class NpcHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    private Collider _collider;
    public AudioClip deathSound;
    public float deathSoundVolume = 1.0f; // Adjust the volume level as needed
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        _collider = GetComponent<Collider>();
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isDead)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        isDead = true;

        // Get the position of the Sound Manager (Audio Listener)
        Vector3 soundManagerPosition = new Vector3(263.5974f, 36.4f, 0f);

        // Play death sound effect with adjusted volume at the Sound Manager's position
        SoundManager.Instance.PlayDeathSound(deathSound, soundManagerPosition, deathSoundVolume);

        // Disable collider to prevent further damage
        _collider.enabled = false;

        // Disable other components or perform death animations
        Destroy(gameObject); // Optionally destroy the NPC object
    }

}
