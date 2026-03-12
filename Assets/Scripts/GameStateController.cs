using System;
using Player;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _player;
        [SerializeField] private CanvasGroup _loseScreen; 
        [SerializeField] private CanvasGroup _winScreen; 
        [SerializeField] private EnemyTracker _enemyTracker; 

        private void OnEnable()
        {
            _player.Died += Lose;
            _enemyTracker.AllEnemiesDied += Win;
        }

        private void OnDisable()
        {
            _player.Died -= Lose;
            _enemyTracker.AllEnemiesDied -= Win;
        }

        public void Restart()
        {
            SceneSystem.RestartScene();
            Time.timeScale = 1;
        }

        private void Lose(Health _)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _loseScreen.alpha = 1;
            _loseScreen.blocksRaycasts = true;
            _loseScreen.interactable = true;
            Time.timeScale = 0;
        }

        private void Win()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _winScreen.alpha = 1;
            _winScreen.blocksRaycasts = true;
            _winScreen.interactable = true;
            Time.timeScale = 0;
        }
    }
}