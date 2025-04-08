using Microsoft.Extensions.DependencyInjection;
using puzzle_game;
namespace puzzle_game.game.extensions;



public static class PuzzleGameServices
{

    public static Type GetService<Type>(this PuzzleGame game)
    {
        return GameServices.Provider.GetService<Type>();
    }

    public static void RegisterServices(this PuzzleGame game)
    {
        GameServices.RegisterServices(game);
    }
}