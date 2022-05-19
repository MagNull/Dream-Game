using System;
using UnityEngine;

namespace Source.Slime_Components
{
    [RequireComponent(typeof(Animator))]
    public class SlimeAnimator : MonoBehaviour
    {
        private readonly int _velocityXHash = Animator.StringToHash("Velocity X");
        private readonly int _velocityYHash = Animator.StringToHash("Velocity Y");
        private readonly int _jumpHash = Animator.StringToHash("Jump");
        private readonly int _groundedHash = Animator.StringToHash("Grounded");
        private readonly int _dieHash = Animator.StringToHash("Die");

        private Animator _animator;
        private GroundChecking _groundChecking;
        private SlimeMovement _movement;

        public void Init(Animator animator, SlimeMovement movement, Health health, GroundChecking groundChecking)
        {
            _movement = movement;
            _animator = animator;
            _groundChecking = groundChecking;
            health.Died += OnDied;
            movement.Jumped += OnJumped;
        }

        private void OnJumped()
        {
            _animator.SetTrigger(_jumpHash);
        }
        
        private void OnDied()
        {
            _animator.SetTrigger(_dieHash);
        }

        private void OnTimeStop()
        {
            
        }

        private void FixedUpdate()
        {
            _animator.SetFloat(_velocityXHash, Mathf.Abs(_movement.Velocity.x));
            _animator.SetFloat(_velocityYHash, _movement.Velocity.y);
            _animator.SetBool(_groundedHash, _groundChecking.IsGrounded);
        }
    }
}