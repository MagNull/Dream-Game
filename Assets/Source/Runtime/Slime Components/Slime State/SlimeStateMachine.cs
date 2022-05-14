using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Source.Slime_Components
{
    public class SlimeStateMachine : MonoBehaviour
    {
        public event Action<SlimeState> StateChanged;
        private List<SlimeState> _allStates;
        private List<SlimeState> _availableStates;
        private int _currentState = -1;

        public void Init(List<SlimeState> startStates)
        {
            _allStates = startStates;
            _availableStates = new List<SlimeState>();
            AddState<SimpleState>();
        }

        public float GetSpeedModificator() => _availableStates[_currentState].Speed * TimeShiftConstants.Constants["PlayerConstant"];

        public float GetJumpPowerModificator() => _availableStates[_currentState].JumpHeight;
        public float GetWeight() => _availableStates[_currentState].Weight;

        public int GetDamageModificator(object source) => _availableStates[_currentState].GetDamageModificator(source);

        public void AddState<T>() where T : SlimeState
        {
            var newState = _allStates.FirstOrDefault(s => s is T);
            if (!_availableStates.Contains(newState))
                _availableStates.Add(newState);
            SwitchState();
        }

        private void SwitchState()
        {
            if (_availableStates.Count == 0)
                throw new Exception("Slime hasn't any states");
            _currentState++;
            _currentState %= _availableStates.Count;

            StateChanged?.Invoke(_availableStates[_currentState]);
        }

        public void ActivateSlimeAbility() => _availableStates[_currentState].ActivateAbility();

        public void OnDied()
        {
            Debug.Log("Died");
        }
    }
}