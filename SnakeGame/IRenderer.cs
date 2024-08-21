using System.Numerics;

namespace SnakeGame;
public interface IRenderer
{
    void DrawApple(Vector2 currentApplePosition);
    void DrawHeadAt(Vector2 head);
    void EraseAt(Vector2 coordinate);
    void RenderCoordinates(Vector2 coordinate);
    void RenderGameInfo(int level, int applesEaten, int applesToNextLevel);
    void RenderWalls(int height, int width);
}