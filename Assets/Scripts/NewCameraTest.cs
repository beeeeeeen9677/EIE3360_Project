using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraTest : MonoBehaviour
{
    public float sensitivity = 2f;
    private Vector2 currentRotation;
    public GameObject player;
    private Vector3 offset;
    public GameObject UI;

    //Sets the depth bias on the GPU. Depth bias, also called depth offset, is a setting on the GPU that determines the depth at which it draws geometry. Adjust the depth bias to force the GPU to draw geometry on top of other geometry at the same depth.
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    //every frame but after Update() method is executed. Therefore, if you want to check and control something after the Update() method finishes its job, you need to use LateUpdate() method
    {
        transform.position = player.transform.position + offset;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || UI.activeInHierarchy || Timer.instance.failed)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        currentRotation.x += mouseX * sensitivity;
        currentRotation.y -= mouseY * sensitivity; // Invert Y-axis for mouse look

        currentRotation.y = Mathf.Clamp(currentRotation.y, -90f, 90f); // Limit vertical rotation

        transform.localEulerAngles = new Vector3(currentRotation.y, currentRotation.x, 0f);
    }

    
}