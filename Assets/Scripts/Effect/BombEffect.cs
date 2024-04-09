using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            Rigidbody playerRB = other.GetComponent<Rigidbody>();
            Vector3 direction = (transform.position - playerRB.position).normalized;

            playerRB.AddForce(Vector3.up*5000 , ForceMode.Impulse);

            Destroy(gameObject);
        }
    }
}
