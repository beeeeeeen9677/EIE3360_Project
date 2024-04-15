using UnityEngine;

public class PlayerMovementAnimator : MonoBehaviour
{
    private Animator playerAnimator; // Player's Animator component
    private Rigidbody playerRigidbody; // Player's Rigidbody component
    private Transform cameraTransform; // Camera's Transform component

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent < Rigidbody>();
        cameraTransform = Camera.main.transform; // Get the main camera's transform
    }

    void Update()
    {
        // Get input for horizontal and vertical movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction relative to the camera's forward direction
        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = moveVertical * cameraForward + moveHorizontal * cameraTransform.right;

        // Set the player's rotation based on the movement direction
        if (moveDirection.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Set the speed parameter in the animator
        float speed = playerRigidbody.velocity.magnitude;
        playerAnimator.SetFloat("Speed", speed);

        // Set the IsRunning parameter based on speed
        if (speed > 0.1f)
        {
            playerAnimator.SetBool("IsRunning", true);
        }
        else
        {
            playerAnimator.SetBool("IsRunning", false);
        }
    }
}
