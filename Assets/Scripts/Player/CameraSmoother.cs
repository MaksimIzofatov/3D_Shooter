using UI;
using UnityEngine;

namespace Player
{
    public class CameraSmoother : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _smoothValue;
        
        private Quaternion _lastRotation;

        private void Start()
        {
            _lastRotation = transform.rotation;
        }

        private void LateUpdate()
        {
            if (PauseMenu.Instance.IsPaused == false)
            {
                transform.rotation = Quaternion.Lerp(_lastRotation, transform.rotation, _smoothValue);
                transform.rotation = Quaternion.Euler(transform.eulerAngles + _offset);

                _lastRotation = transform.rotation;
            }
        }
    }
}