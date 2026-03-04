using System;
using UnityEngine;

namespace UI
{
    public abstract class Changable : MonoBehaviour
    {
        public event Action<float, float> ValueChange;

        protected void OnValueChanged(float currentValue, float maxValue)
        {
            ValueChange?.Invoke(currentValue, maxValue);
        }
    }
}