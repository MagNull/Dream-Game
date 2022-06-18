using System;
using Source.Runtime;
using Source.Runtime.UI___HUD;
using Source.Slime_Components;
using UnityEngine;

public class InputBindings : MonoBehaviour
{
    private PlayerInput _playerInput;
    private SlimeMovement _movement;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    public void BindMovement(SlimeMovement movement)
    {
        _movement = movement; ;
        _playerInput.Slime.Jump.performed += _ => _movement.Jump();
    }

    public void BindStateShifting(ISlimeStateSwitching slimeStateMachine)
    {
        _playerInput.Slime.ChangeState.performed += _ => slimeStateMachine.SwitchState();
    }

    public void BindAbilityCast(ISlimeAbilityCaster abilityCaster)
    {
        _playerInput.Slime.ActivateAbility.performed += _ => abilityCaster.ActivateSlimeAbility();
    }

    public void BindPause(Pause pause)
    {
        _playerInput.UI.Pause.performed += _ => pause.ChangePauseState();
        pause.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        var inputMovement = _playerInput.Slime.Movement.ReadValue<Vector2>();
        _movement.Move(inputMovement);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _movement.Move(Vector2.zero);
    }
}
