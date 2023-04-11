using Conf;
using UnityEngine;

namespace Client.Runtime
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Coroutines _coroutines = default;
        [SerializeField] private Preloader _preloader = default;
        [SerializeField] private Library _library = default;

        private Application _application;

        private void Start()
        {
            _preloader.Show();

            DontDestroyOnLoad(this);
            name = "[application]";

            var sceneLoader = new ScenesLoader(_coroutines);
            
            _application = new Application(sceneLoader, _preloader, _library);
            _application.Initialize();
            
            _application.Start();
        }
    }
}
