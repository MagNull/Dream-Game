using System;
using System.Collections;
using System.Collections.Generic;
using Source.Slime_Components;
using UnityEngine;

public class SlimeSound : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField]
    private AudioClip _jumpSound;
    [SerializeField]
    private AudioClip _groundedSound;
    [SerializeField]
    private AudioClip _stateChangedSound;
    [SerializeField]
    private AudioClip _stoneHitSound;
    [SerializeField]
    private AudioSource _timeAudioSource;
    [SerializeField]
    private AudioClip _timeSlowSound;
    [SerializeField]
    private AudioClip _timesUpSound;
    
    private SlimeMovement _slimeMovement;
    private AudioSource _audioSource;
    private Slime _slime;
    
    public void Init(SlimeMovement movement, Slime slime)
    {
        _slime = slime;
        _audioSource = GetComponent<AudioSource>();
        _slimeMovement = movement;
        enabled = true;
        _timeAudioSource.enabled = true;
    }

    public void OnGrounded()
    {
        if(_audioSource.isPlaying)
            return;
        PlaySound(_groundedSound);
    }

    public void OnTimeSlowed()
    {
        _timeAudioSource.clip = _timeSlowSound;
        _timeAudioSource.Play();
    }

    public void OnTimeNormal()
    {
        _timeAudioSource.clip = _timesUpSound;
        _timeAudioSource.Play();
    }

    private void OnEnable()
    {
        _slimeMovement.Jumped += OnJumped;
        _slime.StateChanged += OnSlimeStateChanged;
        _slime.StoneHit += OnStoneHit;
    }

    private void OnJumped() => PlaySound(_jumpSound);

    private void OnStoneHit() => PlaySound(_stoneHitSound);

    private void OnSlimeStateChanged() => PlaySound(_stateChangedSound);

    private void PlaySound(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }

    private void OnDisable()
    {
        _slimeMovement.Jumped -= OnJumped;
        _slime.StateChanged -= OnSlimeStateChanged;
        _slime.StoneHit -= OnStoneHit;
    }
}
