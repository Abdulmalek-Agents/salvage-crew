using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using SalvageCrew.Core;
using SalvageCrew.Data;

namespace SalvageCrew.Mission
{
    public class WreckLoader : MonoBehaviour, IService
    {
        public void Register() => Services.Register(this);

        private SceneInstance? _loaded;

        public IEnumerator LoadWreck(WreckData wreck)
        {
            if (wreck == null || !wreck.sceneReference.RuntimeKeyIsValid()) yield break;
            var op = wreck.sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
            yield return op;
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                _loaded = op.Result;
                SceneManager.SetActiveScene(_loaded.Value.Scene);
                Debug.Log($"[WreckLoader] Loaded {wreck.wreckId}");
            }
        }

        public IEnumerator UnloadWreck()
        {
            if (!_loaded.HasValue) yield break;
            var op = Addressables.UnloadSceneAsync(_loaded.Value);
            yield return op;
            _loaded = null;
        }
    }
}
