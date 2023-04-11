using System;
using Conf;

namespace Client.Runtime
{
    public class Model 
    {
        public CatMood CurrentMood { get; private set; }
        public event Action OnMoodChanged;

        public void SetMood(CatMood mood)
        {
            CurrentMood = mood;
            OnMoodChanged?.Invoke();
        }
    }
}