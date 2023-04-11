using UnityEngine;

namespace Conf
{
    [CreateAssetMenu(menuName = "Configs/params", fileName = "params")]
    public class Params : ScriptableObject
    {
        public Conf.CatMood InitialMood;
    }
}