using UnityEngine;

public class DamageOnStepController : MonoBehaviour
{
    private Transform _playerTransform;
    private Animator _animations;
    private AudioSource _damageSound;

    void Start()
    {
        _animations = GetComponent<Animator>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _damageSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MakeDamage();
        }
    }

    void MakeDamage()
    {
        print("Damage!");
        _damageSound.Play();
    }
}
