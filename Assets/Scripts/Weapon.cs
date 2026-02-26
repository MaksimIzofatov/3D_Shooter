using System;
using Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponName _weaponName;
        [SerializeField] private float _damage;
        [SerializeField] private int _maxMagazineCapacity;
        [SerializeField] private int _maxBulletsInInventory;
        [SerializeField] private GameObject _test;
        
        private Vector2 _screenShotPercent = new Vector2(0.5f, 0.5f);
        private int _bulletsInMagazine;
        private int _bulletsInInventory;

        private void Start()
        {
            _bulletsInMagazine = _maxMagazineCapacity;
            _bulletsInInventory = _maxBulletsInInventory;
        }

        public void Shot(Camera camera)
        {
            if (_bulletsInMagazine > 0)
            {
                Ray ray = camera.ViewportPointToRay(_screenShotPercent);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.TryGetComponent(out EnemyHealth enemy))
                    {
                        enemy.TakeDamage(_damage * Time.deltaTime);
                    }
                    Instantiate(_test, hit.point, Quaternion.identity);
                }
            }

            _bulletsInMagazine--;
            if (_bulletsInMagazine < 0)
            {
                _bulletsInMagazine = 0;
            }
        }

        public void Reload()
        {
            int bulletsToLoad = _maxMagazineCapacity - _bulletsInMagazine;
            if (bulletsToLoad <= _bulletsInInventory)
            {
                _bulletsInInventory -= bulletsToLoad;
            }
            else
            {
                bulletsToLoad = _maxBulletsInInventory;
                _bulletsInInventory = 0;
            } 
            
            _bulletsInMagazine += bulletsToLoad;
        }
    }

    public enum WeaponName
    {
        M4,
        PoliceGun,
        MachineGun
    }
}