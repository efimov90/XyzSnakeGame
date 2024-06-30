using System.Numerics;

namespace SnakeGame;
public class ConsoleRenderer : IRenderer
{
    public void RenderCoordinates(Vector2 coordinate)
    {
        Console.SetCursorPosition(0, 0);
        Console.Write($"X: {coordinate.X}, Y: {coordinate.Y}                     ");
    }
}
