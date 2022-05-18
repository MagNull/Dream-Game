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
        if (collision.TryGetComponent(out SlimeStateMachine _))
        {
            _damageSound.Play();
            print("the player got into a dangerous substance");
        }
    }
}
