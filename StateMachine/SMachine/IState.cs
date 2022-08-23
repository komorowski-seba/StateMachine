namespace SMachine
{
    public interface IState
    {
        void SetEvent(int evt, out IState newState);
        void Execute();
        void Reset();
    }
}