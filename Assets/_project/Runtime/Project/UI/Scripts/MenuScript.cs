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

        public void OnClickContinue()
        {
            var currentLevel = LevelSelectScript.UnlockedLevels;
            var screenManager = ScreenManager.Instance;
            SceneManager.LoadScene("Level" + (currentLevel + 1)); // Seviye isimlerini Level1, Level2... olarak kabul ediyoruz.
        }

        public void OnClickLevels()
        {
            OpenLevelsMenu();
        }
        public void OnClickForSettings()
        {
            OpenSettingsMenu();
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
