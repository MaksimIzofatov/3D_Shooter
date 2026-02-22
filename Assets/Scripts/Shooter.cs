using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private List<Weapon> _weapons;
        
        private Weapon _currentWeapon;


        private void Start()
        {
            _currentWeapon  = _weapons[0];
        }

        private void OnEnable()
        {
            _inputReader.Shot += Shot;
        }

        private void OnDisable()
        {
            _inputReader.Shot += Shot;
        }

        private void Shot()
        {
            _currentWeapon.Shot(_camera);
        }

        private void SwitchWeapon()
        {
            
        }
    }
}