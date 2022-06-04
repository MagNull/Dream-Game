using System;
using UnityEngine;

namespace Source.Slime_Components
{
    public class AirState : SlimeState
    {
        [SerializeField]
        private float _gravitationReduceCoefficient;
        private Rigidbody2D _rigidbody2D;
        private bool _isAbilityActive;

        public override string Name
        { get => "AirState"; }

        public override void ActivateAbility()
        {
            if (_isAbilityActive)
            {
                _rigidbody2D.gravityScale /= _gravitationReduceCoefficient;
                _isAbilityActive = false;
            }
            else
            {
                _rigidbody2D.gravityScale *= _gravitationReduceCoefficient;
                _isAbilityActive = true;
            }
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
            {
                _rigidbody2D.gravityScale /= _gravitationReduceCoefficient;
                _isAbilityActive = false;
            }
        }
    }
}