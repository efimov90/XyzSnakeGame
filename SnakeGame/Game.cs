using System.Numerics;

namespace SnakeGame;
internal class Game
{
    private readonly Random _random = new();
    private readonly IInputReader _inputReader;
    private readonly IRenderer _renderer;
    private readonly ShowTextState _showTextState;
    private double _tickSeconds = 1d;
    private double _secondsFromLastUpdate = 0d;

    private DateTime _lastUpdateTime = DateTime.Now;
    private bool _running = false;
    private Snake _snake = new(5, 5);
    private Vector2 _currentApplePosition;
    private int _currentAppleMaxX = 10;
    private int _currentAppleMaxY = 10;

    private int _appleEaten = 0;
    private int _applesToNextLevel = 10;

    private double _levelTickModifier = 0.1d;
    private int _levelApplesToNextLevelModifier = 2;

    private int _level = 1;

    public Game(IInputReader inputReader, IRenderer renderer, ShowTextState showTextState)
    {
        _inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
        _renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
        _showTextState = showTextState ?? throw new ArgumentNullException(nameof(showTextState));
        _inputReader.InputActionCalled += OnInputActionCalled;
    }

    public async Task RunAsync()
    {
        _running = true;
        _renderer.RenderWalls(_currentAppleMaxX + 2, _currentAppleMaxY + 2);
        CreateApple();

        while (_running)
        {
            var currentTime = DateTime.Now;

            var deltaTime = currentTime - _lastUpdateTime;

            Update(deltaTime.TotalSeconds);

            _lastUpdateTime = currentTime;
        }

        _showTextState.RenderGameOverScreen(_level, _appleEaten, _snake.Length);

        await Task.CompletedTask;
    }

    private void OnInputActionCalled(object? sender, InputEventArgs e)
    {
        switch (e.InputAction)
        {
            case InputAction.Up:
                _snake.SetDirection(0, -1);
                break;
            case InputAction.Down:
                _snake.SetDirection(0, 1);
                break;
            case InputAction.Left:
                _snake.SetDirection(-1, 0);
                break;
            case InputAction.Right:
                _snake.SetDirection(1, 0);
                break;
            case InputAction.Exit:
                _running = false;
                break;
        }
    }

    private void Update(double totalSeconds)
    {
        _secondsFromLastUpdate += totalSeconds;

        if (_secondsFromLastUpdate < _tickSeconds)
        {
            return;
        }

        _inputReader.Update();

        if (_currentApplePosition == _snake.NextHeadPosition)
        {
            _snake.EatApple(_currentApplePosition);
            _appleEaten++;

            if (_appleEaten == _applesToNextLevel)
            {
                LevelUp();
            }

            CreateApple();
        }
        else if (_snake.NextHeadPosition.X == 0
            || _snake.NextHeadPosition.Y == 0
            || _snake.NextHeadPosition.X == _currentAppleMaxX + 1
            || _snake.NextHeadPosition.Y == _currentAppleMaxY + 1
            || _snake.IsInsideButNotHead(_snake.NextHeadPosition))
        {
            _running = false;
        }
        else
        {
            _renderer.EraseAt(_snake.Move());
        }

        _renderer.DrawHeadAt(_snake.CurrentHeadPosition);

        _renderer.RenderGameInfo(_level, _appleEaten, _applesToNextLevel);

        _secondsFromLastUpdate = 0;
    }

    private void LevelUp()
    {
        _level++;
        _appleEaten = 0;
        _applesToNextLevel += _levelApplesToNextLevelModifier;
        _tickSeconds -= _tickSeconds * _levelTickModifier;
    }

    private void CreateApple()
    {
        while (_snake.IsInside(_currentApplePosition) || _currentApplePosition == Vector2.Zero)
        {
            _currentApplePosition = new Vector2(_random.Next(1, _currentAppleMaxX + 1), _random.Next(1, _currentAppleMaxY + 1));
        }

        _renderer.DrawApple(_currentApplePosition);
    }
}
