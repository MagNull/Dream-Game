using System.Collections;
using System.Collections.Generic;
using Source.Slime_Components;
using UnityEngine;

public class CollectiblesBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
        {

        }
    }
}
