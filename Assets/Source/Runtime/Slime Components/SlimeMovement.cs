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

        private Rigidbody2D _rigidbody2D;
        private Func<float> _getSpeedModificator;
        private Func<float> _getJumpModificator;

        public void Init(Rigidbody2D rigidbody2D, Func<float> getSpeedModificator, Func<float> getJumpModificator)
        {
            _rigidbody2D = rigidbody2D;
            _getSpeedModificator = getSpeedModificator;
            _getJumpModificator = getJumpModificator;
        }

        public void Move(Vector2 movement)
        {
            var newVelocity = _baseSpeed * movement * _getSpeedModificator.Invoke();
            newVelocity.y = _rigidbody2D.velocity.y + movement.y;
            _rigidbody2D.velocity = newVelocity;
        }

        public void Jump() => Jumped?.Invoke();

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
            if(Velocity.sqrMagnitude == 0)
                return;
            
            transform.rotation =
                Quaternion.LookRotation(Vector3.Cross(_rigidbody2D.velocity, transform.up),
                    -Physics.gravity * _rigidbody2D.gravityScale);
            Debug.Log(-Physics.gravity.normalized * _rigidbody2D.gravityScale);
        }
    }
}