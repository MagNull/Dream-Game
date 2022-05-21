using Source.Slime_Components;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    private Animator _animations;
    private AudioSource _damageSound;
    private bool _isTurnOn;
    private bool _isNear;
    private static readonly int _leverOnAnim = Animator.StringToHash("LeverInteraction");

    void Awake()
    {
        _animations = GetComponent<Animator>();
        _animations.SetBool(_leverOnAnim, false);
        _damageSound = GetComponent<AudioSource>();
        _isTurnOn = false;
        _isNear = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Slime slime))
            _isNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
            _isNear = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isNear)
        {
            print("Lever Interaction");
            _isTurnOn = !_isTurnOn;
            _animations.SetBool(_leverOnAnim, _isTurnOn);
            _damageSound.Play();
        }
    }
}
