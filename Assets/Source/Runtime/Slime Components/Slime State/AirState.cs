﻿using System;
using UnityEngine;

namespace Source.Slime_Components
{
    public class AirState : SlimeState
    {
        [SerializeField]
        private float _gravitationReduceCoefficient;
        [SerializeField]
        private GameObject _feather;
        private Rigidbody2D _rigidbody2D;
        private bool _isAbilityActive;

        public override string Name
        {
            get => "AirState";
        }

        public override void ActivateAbility()
        {
            if (_isAbilityActive)
            {
                _feather.SetActive(false);
                _rigidbody2D.gravityScale /= _gravitationReduceCoefficient;
                _isAbilityActive = false;
            }
            else
            {
                _feather.SetActive(true);
                _rigidbody2D.gravityScale *= _gravitationReduceCoefficient;
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x,
                    _rigidbody2D.velocity.y * _gravitationReduceCoefficient);
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
                _feather.SetActive(true);
                _rigidbody2D.gravityScale /= _gravitationReduceCoefficient;
                _isAbilityActive = false;
            }
        }
    }
}