using System;
using Source.Slime_Components;
using UnityEngine;

public class MagicState : SlimeState
{
    [SerializeField]
    private float _gravitationReduceCoefficient;
    private Rigidbody2D _rigidbody2D;
    private bool _isAbilityActive;
    public override void ActivateAbility()
    {
        if (_isAbilityActive)
            TimeShiftConstants.SetOtherConstant(1);
        else
            TimeShiftConstants.SetOtherConstant(0);
        _isAbilityActive = !_isAbilityActive;
    }
    public override int GetDamageModificator(object source) => 1;

    public override void Init(GameObject slimeGameObject)
    {
        if (slimeGameObject.TryGetComponent(out Rigidbody2D rigidbody2D))
            _rigidbody2D = rigidbody2D;
        else
            throw new Exception("Incorrect Air state initialization");
    }

    public override void Exit()
    {
        if (_isAbilityActive)
            TimeShiftConstants.SetOtherConstant(1);
        _isAbilityActive = false;
    }
}
