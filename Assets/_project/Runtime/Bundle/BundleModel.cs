using System.Threading.Tasks;
using _project.Runtime.Core.Singleton;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _project.Runtime.Bundle
{
    public class BundleModel : SingletonModel<BundleModel>
    {
        public async Task<GameObject> LoadPrefab(string key, Transform parent)
        {
            var asyncOperationHandle = Addressables.InstantiateAsync(key,parent);
            await asyncOperationHandle.Task;
            return asyncOperationHandle.Result;
        }
        

        public async Task<Sprite> LoadAssetAsync(string key)
        {
            var asyncOperationHandle = Addressables.LoadAssetAsync<Sprite>(key);
            await asyncOperationHandle.Task;
            return asyncOperationHandle.Result;
        }
        
    }
}