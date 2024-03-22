using _project.Runtime.Core.UI.Scripts.Manager;
using _project.Runtime.Project.Launcher.Scripts.Manager.Bootstrap;
using UnityEngine;

namespace _project.Runtime.Project.UI.Scripts
{
    public class SettingsScript : MonoBehaviour
    {
        public async void OnClickBack()
        {
            var screenManager = ScreenManager.Instance;

            await screenManager.OpenScreen(ScreenKeys.MainMenuScreen, ScreenLayerKeys.FirstLayer);
        }
    }
}
