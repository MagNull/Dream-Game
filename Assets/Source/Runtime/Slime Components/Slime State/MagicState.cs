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
    [SerializeField]
    private GameObject _magicCanvas;
    [SerializeField]
    private GameObject _hourglasses;
    private static Timer _cooldownTimer;
    private static Timer _activeStateTimer;
    private static SlimeSound _slimeSound;
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
        _hourglasses.SetActive(true);
        _magicCanvas.SetActive(true);
        _slimeSound.OnTimeSlowed();
        TimeShiftConstants.SetOtherConstant(0);
        _isAbilityActive = true;
        _activeStateTimer = new Timer(_activateStateDuration, () =>
        {
            _activeStateTimer = null;
            TurnOffAbility();
        });
    }

    private void TurnOffAbility()
    {
        _isAbilityActive = false;
        _hourglasses.SetActive(false);
        _magicCanvas.SetActive(false);
        _slimeSound.OnTimeNormal();
        TimeShiftConstants.SetOtherConstant(1);
        _activeStateTimer = null;
        _cooldownTimer = new Timer(_cooldownDuration, () =>
        {
            _cooldownTimer = null;
        });
    }
    public static void Update()
    {
        if (_cooldownTimer != null)
        {
            _cooldownTimer.Tick(Time.deltaTime);
            //return "T1";
        }
        if (_activeStateTimer != null)
            _activeStateTimer.Tick(Time.deltaTime);

        //return "T";
    }
    
    public override int GetDamageModificator(object source) => 1;

    public override void Init(GameObject slimeGameObject)
    {
        _slimeSound = slimeGameObject.GetComponent<SlimeSound>();
        _cooldownTimer = null;
    }

    public override void Exit()
    {
        if (_isAbilityActive) 
            TurnOffAbility();
        _isAbilityActive = false;
    }
}
