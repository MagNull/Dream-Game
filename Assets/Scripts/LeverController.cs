using UnityEngine;

public class LeverController : MonoBehaviour
{
    private Animator _animations;
    private AudioSource _damageSound;
    private bool _isTurnOn;
    void Start()
    {
        _animations = GetComponent<Animator>();
        _animations.SetBool("LeverOnAnim", false);
        _damageSound = GetComponent<AudioSource>();
        _isTurnOn = false;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetKey(KeyCode.F) && collision.CompareTag("Player") && !_isTurnOn)
        {
            _animations.SetBool("LeverOnAnim", true);
            print("LeverIteraction");
            _damageSound.Play();
            _isTurnOn = true;
        }
    }
}
