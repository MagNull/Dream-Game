using System;
using UnityEngine;

namespace Source.Slime_Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SlimeMovement : MonoBehaviour
    {
        public event Action Jumped;
        public Vector2 Velocity => _rigidbody2D.velocity;

        [SerializeField]
        private float _baseSpeed = 1;
        [SerializeField]
        private float _baseJumpHeight;

        private Rigidbody2D _rigidbody2D;
        private Func<float> _getSpeedModificator;
        private Func<float> _getJumpModificator;

        private GroundChecking _groundChecking;

        public void Init(Rigidbody2D rigidbody2D, Func<float> getSpeedModificator, Func<float> getJumpModificator,
            GroundChecking groundChecking)
        {
            _rigidbody2D = rigidbody2D;
            _getSpeedModificator = getSpeedModificator;
            _getJumpModificator = getJumpModificator;
            _groundChecking = groundChecking;
        }

        public void Move(Vector2 movement)
        {
            var newVelocity = _baseSpeed * movement * _getSpeedModificator.Invoke();
            newVelocity.y = _rigidbody2D.velocity.y;
            _rigidbody2D.velocity = newVelocity;
            LookAtMovement();
        }

        public void Jump()
        {
            if (!_groundChecking.IsGrounded)
                return;
            Jumped?.Invoke();
        }

        public void StartJump()
        {
            var jumpForce = Mathf.Sqrt(_baseJumpHeight * _getJumpModificator.Invoke() * -2 *
                                         (Physics2D.gravity.y * _rigidbody2D.gravityScale));
            _rigidbody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        private void LookAtMovement()
        {
            if (Velocity.sqrMagnitude == 0)
                return;

            transform.rotation =
                Quaternion.LookRotation(Vector3.forward * Mathf.Sign(Velocity.x), transform.up);
        }
    }
}