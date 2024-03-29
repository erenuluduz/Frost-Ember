using System.Collections.Generic;
using _project.Runtime.Core.Singleton;
using UnityEngine;
using System;
using System.Threading.Tasks;
using _project.Runtime.Bundle;

namespace _project.Runtime.Core.UI.Scripts.Manager
{
    [Serializable]
    public class ScreenLayer
    {
        public string Key;
        public Transform Layer;
    }
    public class ScreenManager : SingletonBehaviour<ScreenManager>
    {
        public List<ScreenLayer> Layers;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public async Task<GameObject> OpenScreen(string screenKey, string layerKey, bool clearLayer = true)
        {
            Transform layer = null;

            if(clearLayer)
            {
                ClearLayer(layerKey);
            }
            foreach (var screenLayer in Layers)
            {
                if (screenLayer.Key == layerKey)
                {
                    layer = screenLayer.Layer;
                    break;
                }
            }

            if (layer == null)
            {
                Debug.Log("Layer not found");
            }

            var loadPrefab = await BundleModel.Instance.LoadPrefab(screenKey, layer);
            return loadPrefab;
        }
        public void ClearLayer(string layerKey)
        {
            foreach (var screenLayer in Layers)
            {
                if (screenLayer.Key == layerKey)
                {
                    var layer = screenLayer.Layer;
                    foreach (Transform child in layer)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
        }
    }
}
