using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BarDisplay : MonoBehaviour
    {
        [SerializeField] private Changable _carier;
        [SerializeField] private Slider _slider;

        private void OnEnable()
        {
            _carier.ValueChange += UpdateValues;
        }

        private void OnDisable()
        {
            _carier.ValueChange -= UpdateValues;
        }

        private void UpdateValues(float curValue, float maxValue)
        {
            _slider.value = curValue / maxValue;
        }
    }
}