using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public void OpenDoor()
    {
        var door1 = transform.GetChild(0);
        var door2 = transform.GetChild(1);
        door1.gameObject.SetActive(false);
        door2.gameObject.SetActive(false);
    }
}
