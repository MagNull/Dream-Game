using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyable : MonoBehaviour
{
    private void Awake()
    {
        var obj = FindObjectOfType<DontDestroyable>();
        if (obj && obj != this)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}