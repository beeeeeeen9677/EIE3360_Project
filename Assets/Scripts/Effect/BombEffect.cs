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
        if (other.tag == "Player")
        {
            PlayerHealthBeach playerHP = other.GetComponent<PlayerHealthBeach>();
            playerHP.decreaseHP();
            _collider.enabled = false;
        }
        else if (other.tag == "wehrmacht_c")
        {
            NpcHealth npcHp = other.GetComponent<NpcHealth>();
            npcHp.TakeDamage(20); // Adjust the amount of damage as needed
            //_collider.enabled = false;
        }
    }

    private void Update()
    {
        effectTime -= Time.deltaTime;
        if (effectTime <= 0)
            _collider.enabled = false;

        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
