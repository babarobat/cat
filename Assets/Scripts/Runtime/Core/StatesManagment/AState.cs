namespace Client.Runtime
{
    public abstract class AState 
    {
        public abstract void Enter();
        public abstract void Exit();
    }
}