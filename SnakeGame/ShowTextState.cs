namespace SnakeGame;
internal class ShowTextState
{
    public void RenderGameOverScreen(int level, int appleEaten, int length)
    {
        Console.Clear();
        Console.WriteLine("Game Over");
        Console.WriteLine("Statistics:");
        Console.WriteLine($"Level reached: {level}");
        Console.WriteLine($"Apples eaten on last level: {appleEaten}");
        Console.WriteLine($"Snake length: {length}");
    }
}
