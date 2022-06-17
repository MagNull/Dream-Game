using Source.Slime_Components;
using UnityEngine;

public class MagicState : SlimeState
{
    private bool _isAbilityActive = false;
    [SerializeField]
    private float _activateStateDuration;
    [SerializeField]
    private float _cooldownDuration;
    private SlimeSound _slimeSound;
    private static Timer _cooldownTimer;
    private static Timer _activeStateTimer;
    public override string Name
    { get => "MagicState"; }

    public override void ActivateAbility()
    {
        if (_cooldownTimer != null)
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
        Debug.Log(0);
        TimeShiftConstants.SetOtherConstant(0);
        _isAbilityActive = true;
        Debug.Log(_activateStateDuration);
        _activeStateTimer = new Timer(_activateStateDuration, () =>
        {
            _activeStateTimer = null;
            TurnOffAbility();
        });
        _slimeSound.OnTimeSlowed();
    }

    private void TurnOffAbility()
    {
        Debug.Log(1);
        TimeShiftConstants.SetOtherConstant(1);
        _activeStateTimer = null;
        _isAbilityActive = false;
        _cooldownTimer = new Timer(_cooldownDuration, () =>
        {
            _cooldownTimer = null;
        });
        _slimeSound.OnTimeNormal();
    }
    public static void Update()
    {
        _cooldownTimer?.Tick(Time.deltaTime);
        _activeStateTimer?.Tick(Time.deltaTime);
    }
    
    public override int GetDamageModificator(object source) => 1;

    public override void Init(GameObject slimeGameObject)
    {
        _slimeSound = slimeGameObject.GetComponent<SlimeSound>();
    }

    public override void Exit()
    {
        if (_isAbilityActive)
            TurnOffAbility();
        _isAbilityActive = false;
    }
}
