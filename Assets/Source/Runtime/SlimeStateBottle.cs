using System;
using System.Collections;
using System.Collections.Generic;
using Source.Slime_Components;
using UnityEngine;

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out SlimeStateMachine slimeStateMachine))
        {
            switch (_slimeState)
            {
                case SlimeState.AIR:
                    slimeStateMachine.AddState<AirState>();
                    break;
                case SlimeState.STONE:
                    slimeStateMachine.AddState<StoneState>();
                    break;
                case SlimeState.MAGIC:
                    slimeStateMachine.AddState<AirState>();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
