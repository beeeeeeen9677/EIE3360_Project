using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TerrainScannerDEMO;

public class BombManager : MonoBehaviour
{
    [SerializeField]
    private SensorDetector sd;
    [SerializeField]
    private GameObject missilePrefab;
    private PlayerController player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("LaunchMissile", 2f, 7f);

    }

    

    private void LaunchMissile() //shoot player
    {
        sd.StartSensorP(player.transform.position);
        ShootMissile(player.transform.position);
    }

    private void ShootMissile(Vector3 position)
    {
        Instantiate(missilePrefab, position + Vector3.up * 500, Quaternion.Euler(0f, 0f, -90f));
    }

    public void StopAttacking()
    {
        Destroy(this);
    }
}
