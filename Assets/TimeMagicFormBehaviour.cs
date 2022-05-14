using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMagicFormBehaviour : MonoBehaviour
{
    private static bool _isTimeShiftActivatePrevious;
    private static float _formTimer;
    private static float _coolDawnTimer;
    private static bool _isCoolDawn;
    void Start()
    {
        _isTimeShiftActivatePrevious = false;
        _formTimer = 0f;
        _coolDawnTimer = 0f;
        _isCoolDawn = false;
    }

    void Update()
    {
        //print(_formTimer + "f");
        //print(_coolDawnTimer + "c");
        _formTimer -= Time.deltaTime;
        _coolDawnTimer -= Time.deltaTime;
        if (_formTimer <= 0)
            OnChange();
        if (_coolDawnTimer <= 0)
            _isCoolDawn = false;
    }

    public static void OnChange()
    {
        if (_isTimeShiftActivatePrevious)
        {
            print("deactivate");
            TimeShiftConstants.UpdateAllExceptPlayer(1);
            _coolDawnTimer = 1f;
            //_isTimeShiftActivatePrevious = !_isTimeShiftActivatePrevious;
            _isCoolDawn = true;
        }
        else if (!_isCoolDawn)
        {
            print("activate");
            TimeShiftConstants.UpdateAllExceptPlayer(0);
            _formTimer = 1f;
            _isTimeShiftActivatePrevious = !_isTimeShiftActivatePrevious;
        }
    }
}
