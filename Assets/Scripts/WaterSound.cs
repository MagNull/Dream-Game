using System;
using System.Collections;
using System.Collections.Generic;
using Source.Slime_Components;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WaterSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource _waterEnterSound;
    [SerializeField]
    private AudioSource _waterStaySound;
    private bool _slimeStay;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent(out Slime _))
            return;
        
        _waterEnterSound.Play();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Slime _))
            return;
        _slimeStay = false;
        _waterStaySound.Stop();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(_slimeStay || !other.TryGetComponent(out Slime _))
            return;
        _slimeStay = true;
        _waterStaySound.Play();
    }
}
