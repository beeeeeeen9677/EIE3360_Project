using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;
    [SerializeField]
    private float effectTime = 2.5f;
    [SerializeField]
    private float lifetime = 4f;
    

    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            PlayerHealthBeach playerHP = other.GetComponent<PlayerHealthBeach>();

            //Debug.Log("Hit");
            playerHP.decreaseHP();
            _collider.enabled = false;
        }
    }

    private void Update()
    {
        effectTime -= Time.deltaTime;
        if ( effectTime <=0 )
            _collider.enabled = false;

        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
