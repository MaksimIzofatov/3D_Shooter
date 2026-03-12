using System;
using DefaultNamespace;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        private void Start()
        {
            Time.timeScale = 1;
        }

        public void Play()
        {
            SceneSystem.LoadScene(SceneName.Game);
        }

        public void Exit()
        {
            SceneSystem.Exit();
        }
    }
}