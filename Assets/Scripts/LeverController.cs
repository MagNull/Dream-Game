using Source.Slime_Components;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject _gameObject;
    private Animator _animations;
    private AudioSource _audioSource;
    private bool _isTurnOn;
    private bool _isNear;
    private static readonly int _leverInteraction = Animator.StringToHash("LeverInteraction");

    void Awake()
    {
        _animations = GetComponent<Animator>();
        _animations.SetBool(_leverInteraction, false);
        _audioSource = GetComponent<AudioSource>();
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
            _isTurnOn = !_isTurnOn;
            if (_isTurnOn)
                _animations.Play("LeverOnAnim");
            else
                _animations.Play("LeverOffAnim");
            _audioSource.Play();
            _gameObject.gameObject.SetActive(!_gameObject.activeSelf);
        }
    }
}
