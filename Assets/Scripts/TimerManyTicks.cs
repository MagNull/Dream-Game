using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Source.Slime_Components
{
    public class TimerManyTicks: MonoBehaviour
    {
        private readonly Action _action;
        private float _currentTick;
        public bool isFinish;
        private float tickDelta;

        public void FixedUpdate()
        {
            this.Tick();
        }

        public TimerManyTicks(float duration, float delta, Action action)
        {
            _action = action;
            _currentTick = duration;
            isFinish = false;
            tickDelta = delta;
        }

        public void Tick()
        {
            if (_currentTick <= 0)
                return;
            _currentTick -= tickDelta;
            if (_currentTick <= 0)
            {
                _action?.Invoke();
                isFinish = true;
            }
        }
    }
}