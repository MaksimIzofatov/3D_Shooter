using System;
using Enemy;
using UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponName _weaponName;
        [SerializeField] private ParticleSystem _bloodEffect;        
        [SerializeField] private float _damage;
        [SerializeField] private int _maxMagazineCapacity;
        [SerializeField] private int _maxBulletsInInventory;
        [SerializeField] private GameObject _test;
        
        private Vector2 _screenShotPercent = new Vector2(0.5f, 0.5f);
        private int _bulletsInMagazine;
        private int _bulletsInInventory;

        public event Action Shot; 
        public event Action Reloaded;
        public float CurrentBulletsInMagazine => _bulletsInMagazine;
        public float MaxBulletsInMagazine => _maxMagazineCapacity;

        private void Start()
        {
            _bulletsInMagazine = _maxMagazineCapacity;
            _bulletsInInventory = _maxBulletsInInventory;
        }

        public bool TryShot(Camera camera)
        {
            if (_bulletsInMagazine > 0)
            {
                Ray ray = camera.ViewportPointToRay(_screenShotPercent);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.TryGetComponent(out EnemyHealth enemy))
                    {
                        enemy.TakeDamage(_damage * Time.deltaTime);
                        var effect = Instantiate(_bloodEffect, hit.point, Quaternion.identity);
                        effect.transform.right = hit.normal;
                    }
                    Instantiate(_test, hit.point, Quaternion.identity);

                }
                _bulletsInMagazine--;
                Shot?.Invoke();
                return true;
            }

            return false;
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
            Reloaded?.Invoke();
        }
    }

    public enum WeaponName
    {
        M4,
        PoliceGun,
        MachineGun
    }
}