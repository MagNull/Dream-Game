using System.Collections.Generic;
using Sirenix.OdinInspector;
using Source.Slime_Components;
using UnityEngine;

[RequireComponent(typeof(BuoyancyEffector2D))]
public class BuoyancyObject : SerializedMonoBehaviour
{
    [SerializeField]
    private Dictionary<float, float> _levelPerWeight = new Dictionary<float, float>();
    private BuoyancyEffector2D _buoyancyEffector2D;

    private void Awake()
    {
        _buoyancyEffector2D = GetComponent<BuoyancyEffector2D>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.TryGetComponent(out Slime slime))
        {
            _buoyancyEffector2D.surfaceLevel = _levelPerWeight[slime.GetWeight()];
        }
    }
}