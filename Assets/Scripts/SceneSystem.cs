using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public static class SceneSystem
    {
        public static void LoadScene(SceneName sceneName)
        {
            SceneManager.LoadScene(sceneName.ToString());
        }

        public static void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public static void Exit()
        {
            Application.Quit();
        }
    }

    public enum SceneName
    {
        Menu,
        Game
    }
}