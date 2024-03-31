using _project.Runtime.Core.UI.Scripts.Manager;
using _project.Runtime.Project.Launcher.Scripts.Manager.Bootstrap;
using _project.Runtime.Project.Test.Scripts;
using _project.Runtime.Project.UI.Scripts.View;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace _project.Runtime.Project.UI.Scripts
{
    public class SettingsScript : MonoBehaviour
    {
        public Image image; // Değiştirilecek Image bileşeni
        public Sprite[] soundSprites; // Sesin seviyesine karşılık gelen görüntülerin listesi
        private AudioSource audioSource; // Ses kaynağı

        private int maxSoundLevel; // Maksimum ses seviyesi
        private int soundLevel = 7; // Şu anki ses seviyesi

        void Start()
        {
            // Maksimum ses seviyesini ayarla
            maxSoundLevel = soundSprites.Length - 1;

            // Audio kaynağını etiketleme (tag) yoluyla bul
            audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
            SetImageSprite(soundLevel);
            UpdateSound();
        }

        public void IncreaseSoundLevel()
        {
            // Ses seviyesini artır ve buna karşılık gelen görüntüyü ayarla
            soundLevel = Mathf.Min(soundLevel + 1, maxSoundLevel);
            SetImageSprite(soundLevel);
            UpdateSound();
        }

        public void DecreaseSoundLevel()
        {
            // Ses seviyesini azalt ve buna karşılık gelen görüntüyü ayarla
            soundLevel = Mathf.Max(soundLevel - 1, 0);
            SetImageSprite(soundLevel);
            UpdateSound();
        }

        void SetImageSprite(int level)
        {
            // Ses seviyesine karşılık gelen görüntüyü ayarla
            image.sprite = soundSprites[level];
        }

        void UpdateSound()
        {
            // Ses seviyesini güncelle
            float volume = (float)soundLevel / maxSoundLevel;
            audioSource.volume = volume;
        }

        public async void OnClickBack()
        {
            if (GameScreenView.Instance.gamePlay)
            { 
                var screenManager = ScreenManager.Instance;

                screenManager.ClearLayer(ScreenLayerKeys.FirstLayer);
            }
            else
            {
                var screenManager = ScreenManager.Instance;

                await screenManager.OpenScreen(ScreenKeys.MainMenuScreen, ScreenLayerKeys.FirstLayer);

            }
        }
    }
}

