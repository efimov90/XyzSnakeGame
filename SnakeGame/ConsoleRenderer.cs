using System.Numerics;

namespace SnakeGame;
public class ConsoleRenderer : IRenderer, IDisposable
{
    private const char _snakeElementCharacter = '■';
    private const char _wallCharacter = '█';
    private const char _emptyCharacter = ' ';
    private const char _appleCharacter = '$';

    public ConsoleRenderer()
    {
        Console.CursorVisible = false;
    }

    public void RenderWalls(int height, int width)
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(new string(_wallCharacter, width));

        for (int y = 1; y < height - 1; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(_wallCharacter);
            Console.SetCursorPosition(width-1, y);
            Console.Write(_wallCharacter);
        }

        Console.SetCursorPosition(0, height - 1);
        Console.Write(new string(_wallCharacter, width));
    }

    public void RenderCoordinates(Vector2 coordinate)
    {
        var consoleWindowHeight = Console.WindowHeight;
        Console.SetCursorPosition(0, consoleWindowHeight - 1);
        Console.Write($"X: {coordinate.X}, Y: {coordinate.Y}                     ");
    }
    
    public void RenderGameInfo(int level, int applesEaten, int applesToNextLevel)
    {
        var consoleWindowHeight = Console.WindowHeight;
        Console.SetCursorPosition(0, consoleWindowHeight - 1);
        Console.Write($"Level: {level}, Apples: {applesEaten}/{applesToNextLevel}                     ");
    }

    public void DrawHeadAt(Vector2 coordinate)
    {
        Console.SetCursorPosition((int)coordinate.X, (int)coordinate.Y);
        Console.Write(_snakeElementCharacter);
    }

    public void EraseAt(Vector2 coordinate)
    {
        Console.SetCursorPosition((int)coordinate.X, (int)coordinate.Y);
        Console.Write(_emptyCharacter);
    }

    public void DrawApple(Vector2 coordinate)
    {
        Console.SetCursorPosition((int)coordinate.X, (int)coordinate.Y);
        Console.Write(_appleCharacter);
    }

    public void Dispose()
    {
        Console.CursorVisible = true;
    }
}
