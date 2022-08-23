using SMachine;

IState? _stateA;
IState? _stateB = default;
IState? _stateC = default;

_stateA = new State(
    update: () => { },
    start: () => Console.WriteLine("State A"),
    evt: e => e switch
    {
        'b' => _stateB,
        'c' => _stateC,
        _ => null
    });

_stateB = new State(
    update: () => { },
    start: () => Console.WriteLine("State B"),
    evt: e => e switch
    {
        'a' => _stateA,
        _ => null
    });

_stateC = new State(
    update: () => { },
    start: () => Console.WriteLine("State C - you can't go anywhere"));


var _currentState = _stateA;

int key;
do
{
    _currentState?.Execute();
    
    key = Console.Read();
    _currentState?.SetEvent(key, out _currentState);
} 
while(key != 'q');

Console.WriteLine("Exit");