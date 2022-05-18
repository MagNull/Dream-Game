using System;
using UnityEngine;

namespace Source.Slime_Components
{
    [Serializable]
    public abstract class SlimeState
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _jumpHeight;
        [SerializeField]
        private float _weight;
        
        [SerializeField]
        private Color _stateColor;

        public float Speed => _speed;

        public float JumpHeight => _jumpHeight;

        public float Weight => _weight;

        public abstract void ActivateAbility();

        public abstract int GetDamageModificator(object source);

        public void Enter(SpriteRenderer spriteRenderer)
        {
            spriteRenderer.color = _stateColor;
        }
    }
}