using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockObject : MonoBehaviour
{
    private float lifetime = 19;

    [SerializeField]
    private Timer _timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _timer.DecreaseTime();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, -30, 0) * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if(lifetime <= 0 )
            Destroy(gameObject);
    }
}
