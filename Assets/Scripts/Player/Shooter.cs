using System;
using System.Collections.Generic;
using Player;
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
            SwitchWeapon(1);
        }

        private void OnEnable()
        {
            _inputReader.Shot += Shot;
            _inputReader.WeaponSwitched += SwitchWeapon;
            _inputReader.Reloaded += Reload;
        }

        private void OnDisable()
        {
            _inputReader.Shot -= Shot;
            _inputReader.WeaponSwitched -= SwitchWeapon;
            _inputReader.Reloaded -= Reload;
        }

        private void Shot()
        {
            _currentWeapon.Shot(_camera);
        }

        private void Reload()
        {
            _currentWeapon.Reload();
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