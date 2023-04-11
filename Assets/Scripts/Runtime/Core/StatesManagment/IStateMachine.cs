namespace Client.Runtime
{
    public interface IStateMachine 
    {
        AState Current { get; }
        void Register(AState state);
        void Enter<TState>() where TState : AState;
        void Exit();
    }
}