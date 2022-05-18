using UnityEngine;

public class LeverController : MonoBehaviour
{
    private Animator _animations;
    private AudioSource _damageSound;
    private bool _isTurnOn;
    private static readonly int _leverOnAnim = Animator.StringToHash("LeverOnAnim");

    void Awake()
    {
        _animations = GetComponent<Animator>();
        _animations.SetBool(_leverOnAnim, false);
        _damageSound = GetComponent<AudioSource>();
        _isTurnOn = false;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetKey(KeyCode.F) && collision.CompareTag("Player") && !_isTurnOn)
        {
            _animations.SetBool(_leverOnAnim, true);
            print("Lever Interaction");
            _damageSound.Play();
            _isTurnOn = true;
        }
    }
}
