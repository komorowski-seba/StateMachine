# StateMachine

A simple state machine for building character behavior in games

```c#
IState? _stateA;
IState? _stateB = default;
IState? _stateC = default;
```

State describe at the follows

```c#
_stateA = new State(
    update: () => { },
    start: () => Console.WriteLine("State A"),
    end: () => { },
    evt: e => e switch
    {
        'b' => _stateB,
        'c' => _stateC,
        _ => null
    });
```

In **evt** we describe what states we can migrate to
from current to next state.
We do this by method

```c#
void SetEvent(int evt, out IState newState)

_currentState = _stateA
_currentState.SetEvent(eventId, out _currentState)
```

State update

```c#
_currentState.Execute()
```