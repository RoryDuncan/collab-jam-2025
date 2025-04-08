using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace puzzle_game;

public class GameServices
{
    public static readonly ServiceCollection services = new();
    public static ServiceProvider Provider { get; set; }

    public static void RegisterServices(PuzzleGame game)
    {
        services.AddSingleton<PuzzleGame>(game);
        services.AddSingleton<Game>(game);
        services.AddSingleton<GraphicsDevice>(game.GraphicsDevice);
        services.AddSingleton<SpriteBatch>(new SpriteBatch(game.GraphicsDevice)); // should this be a singleton?
        services.AddSingleton<ContentManager>(game.Content);

        GameServices.Provider = services.BuildServiceProvider();
    }

}
