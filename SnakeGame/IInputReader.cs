
namespace SnakeGame;

internal interface IInputReader
{
    event EventHandler<InputEventArgs> InputActionCalled;

    void Update();
}