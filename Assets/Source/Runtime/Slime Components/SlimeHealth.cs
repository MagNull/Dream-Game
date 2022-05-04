using System;
using UnityEngine;

namespace Source.Slime_Components
{
    public class SlimeHealth : MonoBehaviour
    {
        public event Action Died;
        private SlimeState _slimeState;
        private int _value;
        
        public void Init(int value, SlimeStateMachine slimeStateMachine)
        {
            _value = value;
            slimeStateMachine.StateChanged += OnStateChanged;
        }

        public void TakeDamage(int damage, object source)
        {
            var modificator = _slimeState.GetDamageModificator(source);
            var resultDamage = damage * modificator;
            if(_value <= 0)
                return;
            
            _value -= resultDamage;
            if(_value <= 0)
                Died?.Invoke();
        }

        private void OnStateChanged(SlimeState slimeState) => _slimeState = slimeState;
    }
}