using System;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyTracker : MonoBehaviour
    {
        [SerializeField] private List<EnemyHealth> _enemies;

        private int _enemyCount = 0;
        
        public event Action AllEnemiesDied;

        private void OnEnable()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Spawned += OnEnemySpawn;
                enemy.Died += OnEnemyDied;
            }
        }

        private void OnDisable()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Spawned -= OnEnemySpawn;
                enemy.Died -= OnEnemyDied;
            }
        }

        private void OnEnemySpawn()
        {
            _enemyCount++;
        }

        private void OnEnemyDied(Health _)
        {
            _enemyCount--;

            if (_enemyCount == 0)
            {
                AllEnemiesDied.Invoke();
            }
        }
    }
}