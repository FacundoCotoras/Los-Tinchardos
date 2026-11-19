using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopoCamino;

class Mapa
{
    public const int Ancho = 1224;
    public const int Alto = 816;

    private Texture2D textura;

    public static readonly Vector2[] Camino =
    {
        new Vector2(  70, 118),
        new Vector2( 492, 118),
        new Vector2( 492, 303),
        new Vector2( 855, 303),
        new Vector2( 855, 552),
        new Vector2( 335, 552),
        new Vector2( 335, 703),
        new Vector2(1035, 703),
        new Vector2(1035, 582),
        new Vector2(1160, 582)
    };

    public Mapa(Texture2D fondo)
    {
        textura = fondo;
    }

    public void draw(SpriteBatch sb)
    {
        sb.Draw(textura, new Rectangle(0, 0, Ancho, Alto), Color.White);
    }
}
