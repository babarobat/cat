using UnityEngine;

namespace Conf
{
    [CreateAssetMenu(menuName = "Configs/library", fileName = "library")]
    public class Library : ScriptableObject
    {
        public Conf.Kick Kick;
        public Conf.Pet Pet;
        public Conf.Feed Feed;
        public Conf.Play Play;
        public Conf.Params Params;
    }
}
