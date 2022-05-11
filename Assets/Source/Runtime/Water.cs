using System;
using System.Collections;
using System.Collections.Generic;
using Source.Slime_Components;
using UnityEngine;

[RequireComponent(typeof(BuoyancyEffector2D))]
public class Water : MonoBehaviour
{
    [SerializeField]
    private float _surfaceLevelPerWeight;
    [SerializeField]
    private float _uppedBound;
    private BuoyancyEffector2D _buoyancyEffector2D;

    private void Awake()
    {
        _buoyancyEffector2D = GetComponent<BuoyancyEffector2D>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.TryGetComponent(out SlimeStateMachine stateMachine))
        {
            _buoyancyEffector2D.surfaceLevel =
                Mathf.Clamp(2 - _surfaceLevelPerWeight * stateMachine.GetWeight(), -0.5f, _uppedBound);
        }
    }
}