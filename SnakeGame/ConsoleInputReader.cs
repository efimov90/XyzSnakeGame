namespace SnakeGame;

internal partial class ConsoleInputReader : IInputReader
{
    public event EventHandler<InputEventArgs> InputActionCalled;

    public void Update()
    {
        if (Console.KeyAvailable)
        {
            var readKeyInfo = Console.ReadKey(true);

            switch (readKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    InputActionCalled?.Invoke(this, new InputEventArgs(InputAction.Up));
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    InputActionCalled?.Invoke(this, new InputEventArgs(InputAction.Down));
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    InputActionCalled?.Invoke(this, new InputEventArgs(InputAction.Left));
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    InputActionCalled?.Invoke(this, new InputEventArgs(InputAction.Right));
                    break;

                case ConsoleKey.Escape:
                    InputActionCalled?.Invoke(this, new InputEventArgs(InputAction.Exit));
                    break;

                default:
                    break;
            }
        }
    }
}
