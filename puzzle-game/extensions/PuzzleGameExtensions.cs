using flower_game.game.extensions;
using Microsoft.Extensions.DependencyInjection;

namespace flower_game.game.extensions;



public static class FlowerGameServices
{
    
    public static Type GetService<Type>(this FlowerGame game)
    {
        return GameServices.Provider.GetService<Type>();
    }

    public static void RegisterServices(this FlowerGame game)
    {
        GameServices.RegisterServices(game);
    }
}