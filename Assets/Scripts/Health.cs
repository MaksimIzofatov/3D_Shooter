using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Health : MonoBehaviour
    {
        [SerializeField] private float _maxValue;
        
        private float _value;

        public event Action<Health> Died; 
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
        }

        public void TakeDamage(float amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Can't damage negative amount");
            }
            
            Value -= amount;

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
        }

        protected virtual void OnDeath()
        {
            Died?.Invoke(this);
        }
    }
}