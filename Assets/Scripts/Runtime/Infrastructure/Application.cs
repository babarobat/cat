using Conf;

namespace Client.Runtime
{
    public class Application 
    {
        private readonly IPreloader _preloader;
        private readonly IScenesLoader _scenesLoader;
        private readonly Library _library;

        private Game _game;

        public Application(IScenesLoader scenesLoader, IPreloader preloader, Library library)
        {
            _scenesLoader = scenesLoader;
            _preloader = preloader;
            _library = library;
        }

        public void Initialize()
        {
            var model = new Model();
            model.SetMood(_library.Params.InitialMood);
            
            _game = new Game(_scenesLoader, _preloader, model, _library);
            _game.Initialize();
        }

        public void Start()
        {
            _game.Start();
        }
    }
}