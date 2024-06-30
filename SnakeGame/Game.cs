using System.Numerics;

namespace SnakeGame;
internal class Game
{
    private readonly TimeSpan _tickSpan = TimeSpan.FromSeconds(1);
    private readonly IInputReader _inputReader;
    private readonly IRenderer _renderer;
    private bool _running = false;
    private Vector2 _currentHeadDirection = Vector2.Zero;
    private Vector2 _currentHeadPosition = new Vector2(5, 5);

    public Game(IInputReader inputReader, IRenderer renderer)
    {
        _inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
        _renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));

        _inputReader.InputActionCalled += OnInputActionCalled;
    }

    public async Task RunAsync()
    {
        _running = true;

        while (_running)
        {
            Update();

            await Task.Delay(_tickSpan);
        }
    }

    private void OnInputActionCalled(object? sender, InputEventArgs e)
    {
        switch (e.InputAction)
        {
            case InputAction.Up:
                _currentHeadDirection = new Vector2(0, -1);
                break;
            case InputAction.Down:
                _currentHeadDirection = new Vector2(0, 1);
                break;
            case InputAction.Left:
                _currentHeadDirection = new Vector2(-1, 0);
                break;
            case InputAction.Right:
                _currentHeadDirection = new Vector2(1, 0);
                break;
            case InputAction.Exit:
                _running = false;
                break;
        }
    }

    private void Update()
    {
        _inputReader.Update();

        _currentHeadPosition += _currentHeadDirection;

        _renderer.RenderCoordinates(_currentHeadPosition);
    }
}
