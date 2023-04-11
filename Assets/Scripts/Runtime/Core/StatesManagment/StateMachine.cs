using System;
using System.Collections.Generic;

namespace Client.Runtime
{
    public class StateMachine : IStateMachine
    {
        public AState Current { get; private set; }
        
        private readonly Dictionary<Type, AState> _states = new();

        public void Register(AState state)
        {
            var type = state.GetType();
            if (_states.ContainsKey(type))
            {
                throw new Exception($"State {type.Name} already registered");
            }
            _states[type] = state;
        }

        public void Enter<TState>() where TState : AState
        {
            ExitCurrent();
            Current = _states[typeof(TState)];
            EnterCurrent();
        }

        private void EnterCurrent()
        {
            Current.Enter();
        }

        private void ExitCurrent()
        {
            if (Current is not null)
            {
                Current?.Exit();
            }
        }

        public void Exit()
        { 
            ExitCurrent();
            Current = default;
        }
    }
}