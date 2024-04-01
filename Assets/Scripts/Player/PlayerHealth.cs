using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public AudioClip deathClip;                 // The sound effect of the player dying.
    public float health = 100f;
    private Animator anim;                      // Reference to the animator component.
    private PlayerMovement playerMovement;      // Reference to the player movement script.

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // If the timer has run out (implying health has run out), trigger death sequence
        if (Timer.instance != null && Timer.instance.failed)
        {
            PlayerDeathSequence();
        }
    }

    public void TakeDamage(float timeReduction)
    {
        // Reduce timer by specified amount upon taking damage
        if (Timer.instance != null)
        {
            Timer.instance.ChangeTime(-timeReduction); // Decrease timer, effectively reducing "health"
        }
    }

    private void PlayerDeathSequence()
    {
        // Play the dying sound effect at the player's location.
        AudioSource.PlayClipAtPoint(deathClip, transform.position);

        // Disable the movement and other player actions as needed.
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // Optionally, trigger any animations or effects associated with player death.
        anim.SetBool("Dead", true); // Assuming there's a "Dead" boolean parameter in your Animator

        // Additional death handling logic here (e.g., showing game over screen, resetting level, etc.)
    }
}
