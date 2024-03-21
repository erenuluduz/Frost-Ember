using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;
using DG.Tweening;

namespace _project.Runtime.Project.UI.Scripts.View
{
    public class PauseMenuScript : MonoBehaviour
    {
        public static bool _pauseMenu = false;
        public GameObject pauseMenuUI;
        public GameObject countdownUI;
        public TMP_Text countdownText;
        public Image canvasGroup;
        private float fadeDuration = 2f;

        private void Start()
        {
            canvasGroup.DOFade(0f, fadeDuration).OnComplete(() =>
            {
                canvasGroup.gameObject.SetActive(false);
            });
           
        }

        public void OnClickOption()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }

        async Task Countdown(int seconds)
        {
            int counter = seconds;
            while (counter > 0)
            {
                countdownText.text = counter.ToString();
                counter--;
                await Task.Delay(1000); 
            }
            countdownText.text = "GO!";
            await Task.Delay(1000); 

            Time.timeScale = 1f;
            countdownUI.SetActive(false);
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            countdownUI.SetActive(true);

            _ = Countdown(3); // Asenkron fonksiyonu başlat
        }

        public void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        } 
    }
}
