using System;
using Source.Slime_Components;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class Buttin : MonoBehaviour
{
    public GameObject _gameObject;
    public Slime slime_object;
    private bool _isTurnOn;
    private bool _isNear;
    private AudioSource _audioSource;

    void Awake()
    {
        _isTurnOn = false;
        _isNear = false;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Slime slime))
        {
            _isNear = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Slime slime))
        {
            _isNear = false;
        }
    }

    private void Update()
    {   
        float weight = slime_object.GetWeight();
        if (_isNear && !_isTurnOn && weight > 1)
        {
            _isTurnOn = !_isTurnOn;
            _audioSource.Play();
            _gameObject.gameObject.SetActive(!_gameObject.activeSelf);
            transform.DOLocalMoveY(transform.position.y - 0.3f, 0.4f);
        }
    }
}
