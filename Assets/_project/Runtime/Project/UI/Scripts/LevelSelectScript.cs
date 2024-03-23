using System;
using _project.Runtime.Core.UI.Scripts.Manager;
using _project.Runtime.Project.Launcher.Scripts.Manager.Bootstrap;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _project.Runtime.Project.UI.Scripts
{
    public class LevelSelectScript : MonoBehaviour
    {
        public LevelObject[] levelObjects;
        public static int currentLevel;
        public static int UnlockedLevels;
        public Image blackScreen;
        private float _fadeDuration = 2f;
        
        public void OnClickLevel(int levelNumber)
        {
            currentLevel = levelNumber;
            blackScreen.gameObject.SetActive(true);
            blackScreen.color = new Color(0f, 0f, 0f,0f);
            blackScreen.DOFade(1f, _fadeDuration).OnComplete(() =>
            {
                for (int i = 0; i < levelObjects.Length; i++)
                {
                    SceneManager.LoadScene("Level" + (currentLevel + 1)); // Seviye isimlerini Level1, Level2... olarak kabul ediyoruz.
                }
            });
        }
        
        public async void OnClickBack()
        {
            var screenManager = ScreenManager.Instance;

            await screenManager.OpenScreen(ScreenKeys.MainMenuScreen, ScreenLayerKeys.FirstLayer);
        }

        private void Start()
        {
            UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 0);
            for (int i = 0; i < levelObjects.Length; i++)
            {
                if (UnlockedLevels >= i)
                {
                    levelObjects[i].levelButton.interactable = true;
                }
            }
        }
    }
}
