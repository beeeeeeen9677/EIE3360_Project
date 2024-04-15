using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb2;
    public float speed2 = 1;
    private Vector3 currentVelocity;
    private AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip oneShotAudioClip; // Define a public AudioClip variable for the shout audio

    public FixedJoystick joystick;

    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    void FixedUpdate()
    {
        if (Timer.instance.cleared)
            return;

        float moveHorizontal = 0;
        float moveVertical = 0;


        //moveHorizontal = joystick.Horizontal;
        //moveVertical = joystick.Vertical;

        // Get input for horizontal and vertical movement
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        // Create a vector for the movement direction based on input
        Vector3 moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            // Calculate the angle based on the camera's orientation
            float angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float moveAngle = angle * Mathf.Deg2Rad;

            // Calculate the movement velocity based on the corrected angle
            Vector3 movementVelocity = new Vector3(Mathf.Sin(moveAngle) * speed2, 0, Mathf.Cos(moveAngle) * speed2);

            // Apply the movement velocity to the rigidbody
            rb2.velocity = movementVelocity;
        }
        else
        {
            // Stop the player if there is no input
            rb2.velocity = Vector3.zero;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Play the shout audio when the "X" key is pressed
            audioSource.PlayOneShot(oneShotAudioClip, 1.0f); // Play the assigned audio clip with full volume
        }
    }
}
