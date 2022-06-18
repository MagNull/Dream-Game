using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

namespace Source.Slime_Components
{
    public class Slime : MonoBehaviour, ISlimeStateSwitching, ISlimeAbilityCaster, IDamageable
    {
        public event Action<SlimeState> StateChanged;
        public event Action StoneHit;
        private List<SlimeState> _allStates;
        private List<SlimeState> _availableStates;
        private int _currentState = -1;
        private Health _health;
        private SpriteRenderer _spriteRenderer;

        public void Init(List<SlimeState> allStates, List<SlimeState> startStates, Health health, 
            SpriteRenderer spriteRenderer)
        {
            _allStates = allStates;
            _availableStates = new List<SlimeState>();
            foreach (var startState in startStates)
            {
                AddState(startState.GetType());
            }
            _spriteRenderer = spriteRenderer;
            _health = health;
            SwitchState();
            enabled = true;
        }

        public SlimeState GetCurrentSlimeState() => _availableStates[_currentState];

        public float GetSpeedModificator() => _availableStates[_currentState].Speed * TimeShiftConstants.Constants["PlayerConstant"];

        public float GetJumpPowerModificator() => _availableStates[_currentState].JumpHeight;
        public float GetWeight() => _availableStates[_currentState].Weight;

        private int GetDamageModificator(object source) => _availableStates[_currentState].GetDamageModificator(source);
        
        public void AddState<T>() where T : SlimeState
        {
            var newState = _allStates.FirstOrDefault(s => s is T);
            if (typeof(T) == typeof(MagicState))
                _availableStates.Remove(_allStates.FirstOrDefault(x => x is SimpleState));
            if (!_availableStates.Contains(newState))
                _availableStates.Add(newState);
            newState.Init(gameObject);
            SwitchState<T>();
        }
        
        public void AddState(Type stateType) 
        {
            var newState = _allStates.FirstOrDefault(s => s.GetType() == stateType);
            if (typeof(Type) == typeof(MagicState))
                _availableStates.Remove(_allStates.FirstOrDefault(x => x is SimpleState));
            if (!_availableStates.Contains(newState))
                _availableStates.Add(newState);
            newState.Init(gameObject);
        }

        public void SwitchState()
        {
            if (_availableStates.Count == 0)
                throw new Exception("Slime hasn't any states");
            if(_currentState != -1)
                _availableStates[_currentState]?.Exit();
            _currentState++;
            _currentState %= _availableStates.Count;
            StateChanged?.Invoke(_availableStates[_currentState]);
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
            StateChanged?.Invoke(_availableStates[_currentState]);
            _availableStates[_currentState].Enter(_spriteRenderer);
        }

        public void ActivateSlimeAbility()
        {
            /*
            if (_availableStates[_currentState].GetType() == typeof(MagicState))
            {
                var magicCanvas = gameObject.transform.Find("MagicCanvas").gameObject;
                magicCanvas.SetActive(!magicCanvas.activeSelf);
            }
            */
            _availableStates[_currentState].ActivateAbility();

        }

        public void TakeDamage(int damage, object source)
        {
            var modificator = GetDamageModificator(source);
            if(modificator == 0)
                StoneHit?.Invoke();
            var resultDamage = damage * modificator;
            _health.TakeDamage(resultDamage);
        }

        private void FixedUpdate()
        {
            if (_availableStates[_currentState].Name == "MagicState")
                MagicState.Update();
        }

        public void OnDied()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}