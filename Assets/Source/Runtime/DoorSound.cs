using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource _openSound;

    private void OnDisable()
    {
        Instantiate(_openSound, transform.position, Quaternion.identity);
    }
}
