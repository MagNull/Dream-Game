using System;
using System.Drawing.Printing;
using Source.Slime_Components;
using UnityEngine;

public class MagicState : SlimeState
{
    private bool _isAbilityActive = false;
    //private TimerManyTicks CoolDawnTimer;
    public override string Name
    { get => "MagicState"; }

    public override void ActivateAbility()
    {
        //if (CoolDawnTimer != null && !CoolDawnTimer.isFinish)
           // return;
        TimeShiftConstants.SetOtherConstant(_isAbilityActive ? 1 : 0);
        _isAbilityActive = !_isAbilityActive;
        //if (_isAbilityActive == false)
            //CoolDawnTimer = new TimerManyTicks(5f, 1f, () =>
           // {
            //    CoolDawnTimer = null;
            //});

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
