using _project.Runtime.Bundle;
using _project.Runtime.Core.UI.Scripts.Manager;
using _project.Runtime.Project.Launcher.Scripts.Manager.Bootstrap;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _project.Runtime.Project.UI.Scripts.MenuScripts
{
    public class MenuScript : MonoBehaviour
    {
        public float fadeDuration = 0.5f;
        public AudioSource clickSound; // Týklama sesi için AudioSource bileþeni

        public async void OnClickContinue()
        {
            SceneManager.LoadScene("Game");
            
            BundleModel.Instance = new BundleModel();
            
            var screenManager = ScreenManager.Instance;
            
            await screenManager.OpenScreen(ScreenKeys.GameMenuScreen, ScreenLayerKeys.FirstLayer);

            AudioSource audioSource = FindObjectOfType<AudioSource>(); // Eðer AudioSource component'i bu sahnede mevcut ise, onu bul
            if (audioSource != null)
            {
                AudioManagement.PlayMusic(audioSource); // Müziði çal
            }
            else
            {
                Debug.LogError("AudioSource is not found in the scene. Cannot play music.");
            }
        }
    



        public void OnClickLevels()
        {
            OpenLevelsMenu();
            if (clickSound != null)
            {
                clickSound.Play();
            }
        }
        public void OnClickForSettings()
        {
            OpenSettingsMenu();
            // Settings butonuna týklandýðýnda týklama sesini çal
           
        }
        
        private async void OpenLevelsMenu()
        {
            var screenManager = ScreenManager.Instance;

            await screenManager.OpenScreen(ScreenKeys.LevelSelectMenuScreen, ScreenLayerKeys.FirstLayer);
        }

        private async void OpenSettingsMenu()
        {
            var screenManager = ScreenManager.Instance;

            await screenManager.OpenScreen(ScreenKeys.SettingsMenuScreen, ScreenLayerKeys.FirstLayer);
        }
        
    }
}
