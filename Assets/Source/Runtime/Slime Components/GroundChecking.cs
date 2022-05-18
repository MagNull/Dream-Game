using System;
using UnityEngine;

namespace Source.Slime_Components
{
    public class GroundChecking : MonoBehaviour
    {
        public bool IsGrounded { get; private set; }
        [SerializeField]
        private Transform _checkPoint;
        [SerializeField]
        private float _checkRadius;
        [SerializeField]
        private LayerMask _groundLayer;

        private void FixedUpdate() =>
            IsGrounded = Physics2D.OverlapCircle(_checkPoint.position, _checkRadius, _groundLayer);

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_checkPoint.position, _checkRadius);
        }
    }
}