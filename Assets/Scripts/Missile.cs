using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            Destroy(gameObject); 
            Instantiate(explosion, transform.position+Vector3.down*50, Quaternion.identity);
        }
    }
}
