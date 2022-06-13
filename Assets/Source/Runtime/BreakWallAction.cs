using System.Collections;
using System.Collections.Generic;
using Source.Slime_Components;
using UnityEngine;

public class BreakWallAction : MonoBehaviour
{
    Rigidbody2D rb;
    public Slime slime_object;
    private bool _isTurnOn;
    private bool _isNear;

    void Awake()
    {
        _isTurnOn = false;
        _isNear = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
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
        if (_isNear && !_isTurnOn)
        {
            float weight = slime_object.GetWeight();
            int i = 1;
            if (weight > 1)
            {
                _isTurnOn = true;
                rb.simulated = false;
                foreach (Transform child in transform)
                {
                    child.position += Vector3.left * 0.3f * i;
                    i *= -1;
                    var childRigidbody2D = child.gameObject.GetComponent<Rigidbody2D>();
                    childRigidbody2D.gravityScale = 10;
                }
            }
        }
    }
}