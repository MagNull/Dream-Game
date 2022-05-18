using UnityEngine;

public class DamageOnStepController : MonoBehaviour
{
    private Transform _playerTransform;
    private AudioSource _damageSound;

    void Start()
    {
        _damageSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable slimeHealth))
        {
            slimeHealth.TakeDamage(1, this);
            _damageSound.Play();
        }
    }
}
