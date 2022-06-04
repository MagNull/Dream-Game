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
        TimeShiftConstants.SetOtherConstant(0);
        _isAbilityActive = true;
        _activeStateTimer = new TimerManyTicks(_activateStateDuration, () =>
        {
            _activeStateTimer = null;
            TurnOffAbility();
        });
    }

    private void TurnOffAbility()
    {
        TimeShiftConstants.SetOtherConstant(1);
        _activeStateTimer = null;
        _isAbilityActive = false;
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

    public override void Init(GameObject slimeGameObject) { }

    public override void Exit()
    {
        if (_isAbilityActive)
            TimeShiftConstants.SetOtherConstant(1);
        _isAbilityActive = false;
    }
}
