using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    //Sets the depth bias on the GPU. Depth bias, also called depth offset, is a setting on the GPU that determines the depth at which it draws geometry. Adjust the depth bias to force the GPU to draw geometry on top of other geometry at the same depth.
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    //every frame but after Update() method is executed. Therefore, if you want to check and control something after the Update() method finishes its job, you need to use LateUpdate() method
    {
        transform.position = player.transform.position + offset;
    }
}
