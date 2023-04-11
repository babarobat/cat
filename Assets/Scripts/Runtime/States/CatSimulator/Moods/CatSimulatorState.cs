using Conf;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Client.Runtime
{
    public class CatSimulatorState : AState
    {
        private const string Scene = "main";

        private readonly IScenesLoader _scenes;
        private readonly IPreloader _preloader;
        private readonly CatBehaviour _catBehaviour;

        private CatSimulatorSceneContext _catSimulatorSceneContext;

        public CatSimulatorState(IScenesLoader scenes, IPreloader preloader, Library library, Model model)
        {
            _scenes = scenes;
            _preloader = preloader;

            _catBehaviour = new(model, library);
        }

        public override void Enter()
        {
            _preloader.Show();

            _scenes.Load(Scene, LoadSceneMode.Single, onComplete: OnSceneLoaded);
        }

        private void OnSceneLoaded()
        {
            _catSimulatorSceneContext = Object.FindObjectOfType<CatSimulatorSceneContext>();
            
            _catBehaviour.Connect(_catSimulatorSceneContext.HudView);
            _catBehaviour.Start();

            _preloader.Hide();
        }
        
        public override void Exit()
        {
            _catBehaviour.CleanUp();
            _catSimulatorSceneContext.CleanUp();

            _catSimulatorSceneContext = default;
        }
    }
}