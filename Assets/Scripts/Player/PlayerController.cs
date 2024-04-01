using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb2;
    public float speed2 = 1;
    private Vector3 currentVelocity;

    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Timer.instance.cleared)
            return;

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

        Vector3 moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float moveAngle = angle * Mathf.Deg2Rad;

            rb2.velocity = new Vector3(Mathf.Sin(moveAngle) * speed2, 0, Mathf.Cos(moveAngle) * speed2);
        }
        else
        {
            // 松开按键时停止施加力
            rb2.velocity = Vector3.zero;
        }
    }
}
