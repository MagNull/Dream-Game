using System;
using UnityEngine;

namespace Source.Slime_Components
{
    // [CreateAssetMenu(fileName = "Slime State", menuName = "Slime State")]
    [Serializable]
    public abstract class SlimeState
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _jumpHeight;

        public float Speed => _speed;

        public float JumpHeight => _jumpHeight;

        public abstract void ActivateAbility();

        public abstract int GetDamageModificator(object source);
    }
}