using Conf;

namespace Client.Runtime
{
    public class CatBehaviour
    {
        private readonly Model _model;
        private readonly Library _library;
        private readonly CatStateFactory _catStateFactory = new();

        private CatState _current;

        public CatBehaviour(Model model, Library library)
        {
            _model = model;
            _library = library;
        }

        public void Connect(HUDView hud)
        {
            _catStateFactory.Connect(_model, hud , _library);
        }

        public void Start()
        {
            _model.OnMoodChanged += OnMoodChanged;
            OnMoodChanged();
        }

        private void OnMoodChanged()
        {
            _current?.Exit();
            _current = _catStateFactory.Create(_model.CurrentMood);
            _current.Enter();
        }

        public void CleanUp()
        {
            _catStateFactory.CleanUp();
            
            _model.OnMoodChanged -= OnMoodChanged;
            
            _current?.Exit();
            _current = default;
        }
    }
}