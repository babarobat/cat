using Conf;

namespace Client.Runtime
{
    public class Good : CatState
    {
        private readonly GoodMood _data;
        private readonly Model _model;
        private readonly HUDView _hud;
        private readonly Library _library;

        public Good(GoodMood data, Model model, HUDView hud, Library library)
        {
            _data = data;
            _model = model;
            _hud = hud;
            _library = library;
        }

        public override void Enter()
        {
            _hud.SetMoodLabel(_data.Label);

            _hud.Connect(OnPlayClick, OnFeedClick, OnPetClick, OnKickClick);
        }

        private void OnKickClick()
        {
            //some custom logic
            React(_library.Kick);
        }

        private void OnPetClick()
        {
            //some custom logic
            React(_library.Pet);
        }

        private void OnFeedClick()
        {
            //some custom logic
            React(_library.Feed);
        }

        private void OnPlayClick()
        {
            //some custom logic
            React(_library.Play);
        }

        private void React(UserAction action)
        {
            var reaction = _data.GetReactionOrDefault(action);
            _hud.SetReactionLabel(reaction.CatAction.Label);
            _model.SetMood(reaction.NextMood);
        }

        public override void Exit()
        {
        }
    }
}