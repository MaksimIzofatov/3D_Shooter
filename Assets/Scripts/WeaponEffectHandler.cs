using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class WeaponEffectHandler : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private ParticleSystem _particleSystem;

        private void OnEnable()
        {
            _weapon.Shot += HandlerShotEffect;
        }

        private void OnDisable()
        {
            _weapon.Shot -= HandlerShotEffect;
        }

        private void HandlerShotEffect()
        {
            _particleSystem.Play();
        }
    }
}