using System;
using System.Collections.Generic;
using DefaultNamespace;
using UI;
using UnityEngine;

namespace Player
{
    public class Shooter : Changable
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private List<Weapon> _weapons;
        
        private Weapon _currentWeapon;

        public event Action Shot;
        public event Action Reloaded;
        
        private void Start()
        {
            SwitchWeapon(1);
            OnValueChanged(_currentWeapon.CurrentBulletsInMagazine, _currentWeapon.MaxBulletsInMagazine);
        }

        private void OnEnable()
        {
            _inputReader.Shot += Shoot;
            _inputReader.WeaponSwitched += SwitchWeapon;
            _inputReader.Reloaded += Reload;
        }

        private void OnDisable()
        {
            _inputReader.Shot -= Shoot;
            _inputReader.WeaponSwitched -= SwitchWeapon;
            _inputReader.Reloaded -= Reload;
        }

        private void Shoot()
        {
            if (_currentWeapon.TryShot(_camera))
            {
                Shot?.Invoke();
                OnValueChanged(_currentWeapon.CurrentBulletsInMagazine, _currentWeapon.MaxBulletsInMagazine);
            }
        }

        private void Reload()
        {
            _currentWeapon.Reload();
            Reloaded?.Invoke();
            OnValueChanged(_currentWeapon.CurrentBulletsInMagazine, _currentWeapon.MaxBulletsInMagazine);
        }

        private void SwitchWeapon(int weaponIndex)
        {
            if(_currentWeapon != null)
                _currentWeapon.gameObject.SetActive(false);
            
            _currentWeapon = _weapons[weaponIndex - 1];
            _currentWeapon.gameObject.SetActive(true);
        }
    }
}