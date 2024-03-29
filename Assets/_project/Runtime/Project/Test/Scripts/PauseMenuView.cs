using System.Threading.Tasks;
using _project.Runtime.Core.UI.Scripts.Manager;
using _project.Runtime.Project.Launcher.Scripts.Manager.Bootstrap;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _project.Runtime.Project.Test.Scripts
{
    public class PauseMenuView : MonoBehaviour
    {
        public Button soundsOnButton;
        public Button soundsOffButton;
        public GameObject pauseMenuUI;
        public TMP_Text countdownText;
        public GameObject countdownUI;
    
    
        public void OnClickMainMenu()
        {
            var screenManager = ScreenManager.Instance;
            screenManager.OpenScreen(ScreenKeys.MainMenuScreen, ScreenLayerKeys.FirstLayer);
            Time.timeScale = 1f;
        }

        public void OnClickSoundOnOffButton() //müzik kısmı eklenecek
        {
            if (soundsOnButton.IsActive())
            {
                soundsOffButton.gameObject.SetActive(true);
                soundsOnButton.gameObject.SetActive(false);
            }
            else
            {
                soundsOffButton.gameObject.SetActive(false);
                soundsOnButton.gameObject.SetActive(true);
            }
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
