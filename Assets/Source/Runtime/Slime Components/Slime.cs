using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

namespace Source.Slime_Components
{
    public class Slime : MonoBehaviour, ISlimeStateSwitching, ISlimeAbilityCaster, IDamageable
    {
        private List<SlimeState> _allStates;
        private List<SlimeState> _availableStates;
        private int _currentState = -1;
        private Health _health;
        private SpriteRenderer _spriteRenderer;

        public void Init(List<SlimeState> startStates, Health health, SpriteRenderer spriteRenderer)
        {
            _allStates = startStates;
            _availableStates = new List<SlimeState>();
            _spriteRenderer = spriteRenderer;
            _health = health;
            enabled = true;
            AddState<SimpleState>();
        }

        public float GetSpeedModificator() => _availableStates[_currentState].Speed * TimeShiftConstants.Constants["PlayerConstant"];

        public float GetJumpPowerModificator() => _availableStates[_currentState].JumpHeight;
        public float GetWeight() => _availableStates[_currentState].Weight;

        private int GetDamageModificator(object source) => _availableStates[_currentState].GetDamageModificator(source);
        
        public void AddState<T>() where T : SlimeState
        {
            var newState = _allStates.FirstOrDefault(s => s is T);
            if (!_availableStates.Contains(newState))
                _availableStates.Add(newState);
            newState.Init(gameObject);
            SwitchState<T>();
        }

        public void SwitchState()
        {
            if (_availableStates.Count == 0)
                throw new Exception("Slime hasn't any states");
            _availableStates[_currentState]?.Exit();
            _currentState++;
            _currentState %= _availableStates.Count;
            print(_currentState);
            _availableStates[_currentState].Enter(_spriteRenderer);
        }

        private void SwitchState<TState>() where TState : SlimeState
        {
            var stateIndex = _availableStates.FindLastIndex(s => s is TState);
            if(stateIndex == -1)
                return;
            if(_currentState != -1)
                _availableStates[_currentState].Exit();
            
            _currentState = stateIndex;
            _availableStates[_currentState].Enter(_spriteRenderer);
        }

        public void ActivateSlimeAbility() => _availableStates[_currentState].ActivateAbility();

        public void TakeDamage(int damage, object source)
        {
            var modificator = GetDamageModificator(source);
            var resultDamage = damage * modificator;
            _health.TakeDamage(resultDamage);
        }

        public void OnDied()
        {
            Debug.Log("Died");
        }

        private void OnEnable()
        {
            _health.Died += OnDied;
        }

        private void OnDisable()
        {
            _health.Died -= OnDied;
        }
    }
}