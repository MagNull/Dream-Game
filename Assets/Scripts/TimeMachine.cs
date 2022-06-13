using System.Collections;
using System.Collections.Generic;
using Source.Slime_Components;
using UnityEngine;

public class TimeMachine : MonoBehaviour
{
    public GameObject _gameObject_Past;
    public GameObject _gameObject_Present;
    private Animator _animations;
    private AudioSource _damageSound;
    private bool _isTurnOn;
    private bool _isNear;

    void Awake()
    {
        _damageSound = GetComponent<AudioSource>();
        _isTurnOn = false;
        _isNear = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
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
            _damageSound.Play();
            _gameObject_Past.gameObject.SetActive(!_gameObject_Past.activeSelf);
            _gameObject_Present.gameObject.SetActive(!_gameObject_Present.activeSelf);
        }
    }
}
