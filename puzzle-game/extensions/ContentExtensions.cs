
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Content;

namespace DesktopFriend.Core;

public static class MonoGameContentExtensions
{
    public static Texture2D LoadTexture(this ContentManager content, string filenameWithExtension)
    {
        using var stream = content.OpenStream(filenameWithExtension);
        return Texture2D.FromStream(content.GetGraphicsDevice(), stream);
    }
}