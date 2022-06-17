using System;
using System.Collections;
using System.Collections.Generic;
using Source.Slime_Components;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SlimeStateBottle : MonoBehaviour
{
    enum SlimeState
    {
        AIR,
        STONE,
        MAGIC
    }

    [SerializeField]
    private SlimeState _slimeState;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out ISlimeStateSwitching slimeStateMachine))
        {
            _audioSource.Play();
            switch (_slimeState)
            {
                case SlimeState.AIR:
                    slimeStateMachine.AddState<AirState>();
                    break;
                case SlimeState.STONE:
                    slimeStateMachine.AddState<StoneState>();
                    break;
                case SlimeState.MAGIC:
                    slimeStateMachine.AddState<MagicState>();
                    break;
            }

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
