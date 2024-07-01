using System.Numerics;

namespace SnakeGame;
public class ConsoleRenderer : IRenderer
{
    private const char _snakeElementCharacter = '■';
    private const char _emptyCharacter = ' ';

    public void RenderCoordinates(Vector2 coordinate)
    {
        Console.SetCursorPosition(0, 0);
        Console.Write($"X: {coordinate.X}, Y: {coordinate.Y}                     ");
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
}
