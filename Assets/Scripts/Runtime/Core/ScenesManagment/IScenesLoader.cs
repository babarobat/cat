using System;
using UnityEngine.SceneManagement;

namespace Client.Runtime
{
    public interface IScenesLoader
    {
        void Load(string name, LoadSceneMode mode = LoadSceneMode.Additive, Action<float> onProgress = null, Action onComplete = null);
        void Unload(string name);
    }
}