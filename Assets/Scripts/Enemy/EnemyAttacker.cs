using System;
using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _attackDistance;
        [SerializeField] private PlayerHealth _player;
        [SerializeField] private EnemyAnimationEventHandler _animationEvent;

        private bool _isAttacking;
        
        public event Action Attacking;

        private void OnEnable()
        {
            _animationEvent.AttackedAnimationMiddle += Attack;
            _animationEvent.AttackedAnimationEnded += AllowAttacking;
            _animationEvent.HitAnimationEnded += AllowAttacking;
        }

        private void Update()
        {
            if (!_isAttacking && IsPlayerNear())
            {
                StartAttacking();
            }
        }

        private void OnDisable()
        {
            _animationEvent.AttackedAnimationMiddle -= Attack;
            _animationEvent.AttackedAnimationEnded -= AllowAttacking;
            _animationEvent.HitAnimationEnded -= AllowAttacking;
        }

        private void StartAttacking()
        {
            _isAttacking = true;
            Attacking?.Invoke();
        }

        private void Attack()
        {
            if (IsPlayerNear())
            {
                _player.TakeDamage(_damage);
            }
        }

        private void AllowAttacking()
        {
            _isAttacking = false;
        }

        private bool IsPlayerNear()
        {
            return Vector3.Distance(transform.position, _player.transform.position) <= _attackDistance;
        }
    }
}