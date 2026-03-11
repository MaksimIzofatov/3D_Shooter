using System;
using Player;
using UnityEngine;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        public static PauseMenu Instance { get; private set; }
        
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private InputReader _inputReader;

        private bool _isPaused;
        public bool IsPaused => _isPaused;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance);
            }


            Instance = this;
        }

        private void OnEnable()
        {
            _inputReader.Paused += ChangeState;
        }

        private void OnDisable()
        {
            _inputReader.Paused -= ChangeState;
        }

        public void Unpause()
        {
            Time.timeScale = 1;
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isPaused = false;
        }
        private void Pause()
        {
            Time.timeScale = 0;
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _isPaused = true;
        }

        private void ChangeState()
        {
            if(_isPaused) Unpause();
            else Pause();
        }
    }
}