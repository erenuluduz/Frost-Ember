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
        public Image canvasGroup;
        public float fadeDuration = 2f;

        public void OnClickPlay()
        {
            canvasGroup.gameObject.SetActive(true);
            canvasGroup.color = new Color(0f, 0f, 0f,0f);
            // Siyah ekranı yavaşça açma animasyonu
            canvasGroup.DOFade(1f, fadeDuration).OnComplete(() =>
            {
                SceneManager.LoadScene("Launcher");
            });
        }

        public void OnClickForSettings()
        {
            OpenSettingsMenu();
        }

        private async void OpenSettingsMenu()
        {
            var screenManager = ScreenManager.Instance;

            await screenManager.OpenScreen(ScreenKeys.SettingsScreen, ScreenLayerKeys.FirstLayer);
        }
        
    }
}
