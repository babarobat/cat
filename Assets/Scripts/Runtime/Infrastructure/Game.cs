using Conf;

namespace Client.Runtime
{
    public class Game
    {
        private readonly IScenesLoader _scenesLoader;
        private readonly IPreloader _preloader;
        private readonly IStateMachine _gameStates;
        private readonly Model _model;
        private readonly Library _library;

        public Game(IScenesLoader scenesLoader, IPreloader preloader, Model model, Library library)
        {
            _scenesLoader = scenesLoader;
            _preloader = preloader;
            _library = library;
            _model = model;

            _gameStates = new StateMachine();
        }

        public void Initialize()
        {
            _gameStates.Register(new CatSimulatorState(_scenesLoader, _preloader, _library, _model));
        }

        public void Start()
        {
            _gameStates.Enter<CatSimulatorState>();
        }
    }
}