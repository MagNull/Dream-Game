using System;
using Source.Slime_Components;
using UnityEngine;

public class MagicState : SlimeState
{
    private bool _isAbilityActive = false;
    [SerializeField]
    private float _activateStateDuration;
    [SerializeField]
    private float _cooldownDuration;
    private static TimerManyTicks _cooldownTimer;
    private static TimerManyTicks _activeStateTimer;
    private static GameObject _slimeGameObject;
    public override string Name
    { get => "MagicState"; }

    public override void ActivateAbility()
    {
        if (_cooldownTimer != null && !_cooldownTimer.isFinish)
            return;
        if (_isAbilityActive)
        {
            TurnOffAbility();
        }
        else if (!_isAbilityActive)
        {
            TurnOnAbility();
        }
    }

    private void TurnOnAbility()
    {
        SwitchMask();
        TimeShiftConstants.SetOtherConstant(0);
        _isAbilityActive = true;
        _activeStateTimer = new TimerManyTicks(_activateStateDuration, () =>
        {
            _activeStateTimer = null;
            TurnOffAbility();
        });
    }

    private void SwitchMask()
    {
        if (_slimeGameObject != null)
        {
            var magicCanvas = _slimeGameObject.transform.Find("MagicCanvas").gameObject;
            magicCanvas.SetActive(!magicCanvas.activeSelf);
        }
    }

    private void TurnOffAbility()
    {
        SwitchMask();
        TimeShiftConstants.SetOtherConstant(1);
        _activeStateTimer = null;
        _isAbilityActive = false;
        var a = GameObject.Find("MagicCanvasScript");
        var b = GameObject.Find("Canvas");
        _cooldownTimer = new TimerManyTicks(_cooldownDuration, () =>
        {
            _cooldownTimer = null;
        });
    }
    public static void Update()
    {
        if (_cooldownTimer != null)
        {
            _cooldownTimer.Tick();
            //return "T1";
        }
        if (_activeStateTimer != null)
            _activeStateTimer.Tick();

        //return "T";
    }
    
    public override int GetDamageModificator(object source) => 1;

    public override void Init(GameObject slimeGameObject)
    {
        _slimeGameObject = slimeGameObject;
    }

    public override void Exit()
    {
        if (_isAbilityActive)
        {
            SwitchMask();
            TimeShiftConstants.SetOtherConstant(1);
        }
        _isAbilityActive = false;
    }
}
