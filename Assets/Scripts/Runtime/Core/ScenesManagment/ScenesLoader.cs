using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Client.Runtime
{
    public class ScenesLoader : IScenesLoader
    {
        private readonly ICoroutines _coroutineHolder;

        public ScenesLoader(ICoroutines coroutineHolder)
        {
            _coroutineHolder = coroutineHolder;
        }

        public void Load(string name, LoadSceneMode mode = LoadSceneMode.Additive, Action<float> onProgress = null, Action onComplete = null)
        {
            _coroutineHolder.StartCoroutine(LoadInternal(name, mode, onProgress, onComplete));
        }

        public void Unload(string name)
        {
            SceneManager.UnloadSceneAsync(name);
        }

        private IEnumerator LoadInternal(string name, LoadSceneMode mode = LoadSceneMode.Additive, Action<float> onProgress = null, Action onComplete = null)
        {
            var loading = SceneManager.LoadSceneAsync(name, mode);
            while (!loading.isDone)
            {
                onProgress?.Invoke(loading.progress);
                yield return null;
            }
            onComplete?.Invoke();
        }
    }
}