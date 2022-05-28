using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControls : MonoBehaviour
{
    private GameObject _activeWindow;
    private GameObject _previousWindow;

    public void ChangeWindow(GameObject window)
    {
        _previousWindow = _activeWindow;
        _activeWindow = window;
        
        _previousWindow.gameObject.SetActive(false);
        _activeWindow.gameObject.SetActive(true);
    }

    public void ShowPreviousWindow() => ChangeWindow(_previousWindow);
}
