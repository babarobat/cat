using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Conf
{
    public abstract class CatMood : ScriptableObject
    {
        public string Label;
        public List<Reaction> Reactions;

        [Serializable]
        public class Reaction 
        {
            public UserAction OnAction;
            public CatAction CatAction;
            public CatMood NextMood;
        }

        public Reaction GetReactionOrDefault(UserAction onAction) =>
            Reactions.FirstOrDefault(x => x.OnAction == onAction);
    }
}