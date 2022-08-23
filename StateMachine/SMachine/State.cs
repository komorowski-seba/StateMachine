namespace SMachine;

public class State : IState
{
    private enum Status
    {
        start = 0,
        update = 1,
        end = 2
    }

    private readonly Action? _start;
    private readonly Action _update;
    private readonly Action? _end;
    private readonly Func<int, IState?>? _evt;
    private Status _currentStatus;

    public State(
        Action update, 
        Func<int, IState?>? evt = null, 
        Action? start = null , 
        Action? end = null)
    {
        _start = start;
        _update = update;
        _end = end;
        _evt = evt;
        _currentStatus = Status.start;
    }
        
    public void SetEvent(int evt, out IState newState)
    {
        var restult = _evt?.Invoke(evt);
        if (restult == null)
        {
            newState = this;
            return;
        }

        _currentStatus = Status.end;
        _end?.Invoke();
        newState = restult;
        newState.Reset();
    }

    public void Reset()
        => _currentStatus = Status.start;
        
    public void Execute()
    {
        switch (_currentStatus)
        {
            case Status.update:
                _update.Invoke();
                return;
                
            case Status.start:
                _currentStatus = Status.update;
                _start?.Invoke();
                _update.Invoke();
                return;
        }
    }
}