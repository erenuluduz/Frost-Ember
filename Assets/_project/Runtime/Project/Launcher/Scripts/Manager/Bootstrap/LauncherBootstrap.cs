using System;
using _project.Runtime.Bundle;
using _project.Runtime.Core.UI.Scripts.Manager;
using _project.Runtime.Project.UI.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _project.Runtime.Project.Launcher.Scripts.Manager.Bootstrap
{
    public class LauncherBootstrap : MonoBehaviour
    {
        private async void Awake()
        {
            BundleModel.Instance = new BundleModel();
            
            var screenManager = ScreenManager.Instance;
            
            await screenManager.OpenScreen(ScreenKeys.MainMenuScreen, ScreenLayerKeys.FirstLayer);
        }
    }
}
