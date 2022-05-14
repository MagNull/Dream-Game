using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;
using UnityEngine;

public class TimeShiftConstants : MonoBehaviour
{
    public static Dictionary<string, float> Constants;

    void Start()
    {
        Constants = new Dictionary<string, float>();
        Constants["PlayerConstant"] = 1;
        Constants["OtherConstant"] = 1;
    }

    public static void UpdateAllExceptPlayer(float newValue)
    {
        var constantsKeysForUpdate = new List<string>();
        constantsKeysForUpdate = Constants
            .Where(constant => constant.Key != "PlayerConstant")
            .Select(constant => constant.Key)
            .ToList();
        constantsKeysForUpdate.ForEach(key => Constants[key] = newValue);
    }
}
