using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject hintObj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hintObj.SetActive(true);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(-30, 0, -30) * Time.deltaTime);
    }
}
