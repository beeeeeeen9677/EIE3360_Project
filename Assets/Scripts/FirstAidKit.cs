using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, -30, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Timer.instance.ChangeTime(15);
            Destroy(gameObject);
        }
    }
}
