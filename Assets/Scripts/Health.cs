using System;
using UI;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Health : Changable
    {
        [SerializeField] private float _maxValue;
        
        private float _value;

        public event Action<Health> Died; 
        public event Action TookDamage; 
        public float Value
        {
            get => _value;

            set
            {
                _value = Mathf.Clamp(value, 0, _maxValue);
            }
        }

        private void Start()
        {
            _value = _maxValue;
            OnValueChanged(Value, _maxValue);
        }

        public void TakeDamage(float amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Can't damage negative amount");
            }
            
            Value -= amount;
            TookDamage?.Invoke();
            OnValueChanged(Value, _maxValue);

            if (Value == 0)
            {
                OnDeath();
            }
        }

        public void Heal(float amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Can't heal negative amount");
            }
            
            Value += amount;
            OnValueChanged(Value, _maxValue);
        }

        protected virtual void OnDeath()
        {
            Died?.Invoke(this);
        }
    }
}