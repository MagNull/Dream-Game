using System.Collections;
using System.Collections.Generic;
using Source.Slime_Components;
using UnityEngine;

public class BreakWallAction : MonoBehaviour
{
    public void Init()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
        {
            foreach (Transform child in transform)
            {
                var childRigidbody2D = child.gameObject.GetComponent<Rigidbody2D>();
                childRigidbody2D.gravityScale = 10;
            }
        }
    }
}
