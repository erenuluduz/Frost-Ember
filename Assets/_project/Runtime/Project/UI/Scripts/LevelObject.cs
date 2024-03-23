using _project.Runtime.Core.Singleton;
using _project.Runtime.Core.UI.Scripts.Manager;
using _project.Runtime.Project.Launcher.Scripts.Manager.Bootstrap;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _project.Runtime.Project.UI.Scripts
{
    public class LevelObject : SingletonBehaviour<LevelObject>
    {
        public Button levelButton;
        public void UnlockedLevel()
        {
          if (LevelSelectScript.currentLevel == LevelSelectScript.UnlockedLevels)
          { 
              LevelSelectScript.UnlockedLevels++;
              PlayerPrefs.SetInt("UnlockedLevels",LevelSelectScript.UnlockedLevels);
          }
          SceneManager.LoadScene("Menu");
        }
    }
}
    
