using System;

namespace Source.Slime_Components
{
    public class TimerManyTicks
    {
        private readonly Action _action;
        private float _currentTick;
        public bool isFinish;

        public TimerManyTicks(float duration, Action action)
        {
            _action = action;
            _currentTick = duration;
            isFinish = false;
        }

        public void Tick()
        {
            if (_currentTick <= 0)
                return;
            _currentTick -= 1f;
            if (_currentTick <= 0)
            {
                _action?.Invoke();
                isFinish = true;
            }
        }
    }
}