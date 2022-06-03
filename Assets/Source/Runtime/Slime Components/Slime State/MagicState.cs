using System;
using Source.Slime_Components;
using UnityEngine;

public class MagicState : SlimeState
{
    private bool _isAbilityActive;

    public override void ActivateAbility()
    {
        TimeShiftConstants.SetOtherConstant(_isAbilityActive ? 1 : 0);
        _isAbilityActive = !_isAbilityActive;
    }
    public override int GetDamageModificator(object source) => 1;

    public override void Init(GameObject slimeGameObject) { }

    public override void Exit()
    {
        if (_isAbilityActive)
            TimeShiftConstants.SetOtherConstant(1);
        _isAbilityActive = false;
    }
}
