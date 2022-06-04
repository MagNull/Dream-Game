using Source.Slime_Components;
using UnityEngine;

public class SpikeDamager : MonoBehaviour
{
    private AudioSource _damageSound;

    private void Awake()
    {
        _damageSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
        {
            print("Damage");
            slime.TakeDamage(1, this);
        }
    }
}