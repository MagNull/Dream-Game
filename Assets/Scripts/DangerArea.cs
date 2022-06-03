using Source.Slime_Components;
using UnityEngine;

public class DangerArea : MonoBehaviour
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
            //if (slime.GetCurrentState() == )
            _damageSound.Play();
            slime.TakeDamage(1, this);
            print("the player got into a dangerous substance");
        }
    }
}
