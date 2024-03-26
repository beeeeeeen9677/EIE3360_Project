using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SpherePlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Text score;
    public int collected;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collected = 0;
        speed = 30;
    }
    void FixedUpdate()
    /*Update() runs once per frame. FixedUpdate() can run once, zero, or several
    times per frame, depending on how many physics frames per second are set in the
    time settings and how fast/slow the framerate is.*/
    {
        float moveHorizontal = 0;
        float moveVertical = 0;
        moveHorizontal = Input.acceleration.x;
        moveVertical = Input.acceleration.y;

        if (Input.GetKey(KeyCode.A))
            moveHorizontal = -1;
        if (Input.GetKey(KeyCode.D))
            moveHorizontal = 1;
        if (Input.GetKey(KeyCode.W))
            moveVertical = 1;
        if (Input.GetKey(KeyCode.S))
            moveVertical = -1;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    
}
