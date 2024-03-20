using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

namespace _project.Runtime.Project.Test.Scripts
{
    public class PauseMenuScript : MonoBehaviour
    {
        public static bool _pauseMenu = false;
        public GameObject pauseMenuUI;

        public void OnClickOption()
        { 
            _pauseMenu = true;
        }

        private void Update()
        {
            if (_pauseMenu == true)
                Pause();
            else
                Resume();
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            _pauseMenu = false;
        }

        public void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            _pauseMenu = true;
        }

        public void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _pauseMenu = false;
        }
    }
}
