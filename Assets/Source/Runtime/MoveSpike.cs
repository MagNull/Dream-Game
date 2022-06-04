using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class MoveSpike : MonoBehaviour
{
    [SerializeField]
    private float _moveDuration;
    [SerializeField]
    private float _duration;

    private void Start()
    {
        StartCoroutine(Idle());
    }

    private IEnumerator Idle()
    {
        var zeroPos = transform.position;
        while (true)
        {
            var move = 
                transform.DOMove(zeroPos - Vector3.up * transform.localScale.y, _moveDuration);
            move.timeScale = TimeShiftConstants.Constants["OtherConstant"];
            yield return new WaitForSeconds(_duration);
            move = transform.DOMove(zeroPos, _moveDuration);
            move.timeScale = TimeShiftConstants.Constants["OtherConstant"];
            yield return new WaitForSeconds(_duration);
        }
    }
}