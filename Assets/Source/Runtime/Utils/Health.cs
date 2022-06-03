using System;

namespace Source.Slime_Components
{
    public class Health
    {
        public event Action Died;
        private int _value;
        
        public Health(int value, Action act)
        {
            Died = act;
            _value = value;
        }

        public void TakeDamage(int damage)
        {
            if(_value <= 0)
                return;
            
            _value -= damage;
            if(_value <= 0)
                Died?.Invoke();
        }
    }
}