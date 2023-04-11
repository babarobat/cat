using System;
using Conf;

namespace Client.Runtime
{
    public class CatStateFactory
    {
        private Model _model;
        private HUDView _hud;
        private Library _library;

        public void Connect(Model model, HUDView hud, Library library)
        {
            _model = model;
            _hud = hud;
            _library = library;
        }

        public CatState Create(CatMood mood)
        {
            return mood switch
            {
                BadMood data => new Bad(data, _model, _hud, _library),
                ExcellentMood data => new Excellent(data, _model, _hud, _library),
                GoodMood data => new Good(data, _model, _hud, _library),
                _ => throw new ArgumentOutOfRangeException(nameof(mood))
            };
        }

        public void CleanUp()
        {
            _model = default;
            _hud = default;
            _library = default;
        }
    }
}