using System;
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

    public void BindStateShifting(SlimeStateMachine slimeStateMachine)
    {
        _playerInput.Slime.ChangeState.performed += _ => slimeStateMachine.SwitchState();
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
    }
}
