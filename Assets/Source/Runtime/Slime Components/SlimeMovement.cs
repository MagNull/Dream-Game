using System;
using UnityEngine;

namespace Source.Slime_Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SlimeMovement : MonoBehaviour
    {
        public event Action Jumped;
        public Vector2 Velocity => _rigidbody2D.velocity * new Vector2(1, _rigidbody2D.gravityScale);

        [SerializeField]
        private float _baseSpeed = 1;
        [SerializeField]
        private float _baseJumpHeight;
        private SpriteRenderer _spriteRenderer;

        private Rigidbody2D _rigidbody2D;
        private GroundChecking _groundChecking;
        private Func<float> _getSpeedModificator;
        private Func<float> _getJumpModificator;

        public void Init(Rigidbody2D rigidbody2D, Func<float> getSpeedModificator, Func<float> getJumpModificator, 
            GroundChecking groundChecking)
        {
            _rigidbody2D = rigidbody2D;
            _getSpeedModificator = getSpeedModificator;
            _getJumpModificator = getJumpModificator;
            _groundChecking = groundChecking;
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void Move(Vector2 movement)
        {
            var newVelocity = _baseSpeed * movement * _getSpeedModificator.Invoke();
            newVelocity.y = _rigidbody2D.velocity.y + movement.y;
            _rigidbody2D.velocity = newVelocity;
        }

        public void Jump()
        {
            if(!_groundChecking.IsGrounded)
                return;
            Jumped?.Invoke();
        }

        public void StartJump()
        {
            var jumpForce = Mathf.Sqrt(_baseJumpHeight * _getJumpModificator.Invoke() * 2 *
                                       (Mathf.Abs(Physics.gravity.y * _rigidbody2D.gravityScale)));
            _rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        private void FixedUpdate()
        {
            LookAtMovement();
        }

        private void LookAtMovement()
        {
            if (Velocity.sqrMagnitude == 0)
                return;

            var directionVector = Vector3.Cross(_rigidbody2D.velocity, Vector3.up);
            if(directionVector != Vector3.zero)
                _spriteRenderer.flipX = Quaternion.LookRotation(directionVector, Vector3.up).eulerAngles.y > 0;
        }
    }
}