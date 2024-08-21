using System.Numerics;

namespace SnakeGame;
public class Snake
{
    private Vector2 _currentHeadDirection = Vector2.Zero;
    private Queue<Vector2> _body = new();

    public Snake(int x, int y)
    {
        _body.Enqueue(new Vector2(x, y));
    }

    public Vector2 NextHeadPosition => CurrentHeadPosition + _currentHeadDirection;
    public Vector2 CurrentHeadPosition => _body.Last();
    public Vector2 CurrentTailPosition => _body.Peek();

    internal void SetDirection(int x, int y)
    {
        _currentHeadDirection.X = x;
        _currentHeadDirection.Y = y;
    }

    internal Vector2 Move()
    {
        _body.Enqueue(NextHeadPosition);
        return _body.Dequeue();
    }

    internal void EatApple(Vector2 appleCoordinate)
    {
        _body.Enqueue(appleCoordinate);
    }

    internal bool IsInside(Vector2 vector2) => _body.Contains(vector2);

    internal bool IsInsideButNotHead(Vector2 vector2) =>
        _body.SkipLast(1).Contains(vector2);

    internal int Length => _body.Count;
}
