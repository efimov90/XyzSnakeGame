using Microsoft.Extensions.DependencyInjection;
using SnakeGame;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IInputReader, ConsoleInputReader>()
    .AddSingleton<IRenderer, ConsoleRenderer>()
    .AddSingleton<Game>()
    .BuildServiceProvider();

var game = serviceProvider.GetRequiredService<Game>();
await game.RunAsync();
