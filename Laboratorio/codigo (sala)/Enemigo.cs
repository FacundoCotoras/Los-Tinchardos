using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopoCamino;

class Enemigo
{
    private Texture2D textura;
    private Rectangle rectangulo;
    private Vector2 posicion;
    private float velocidad;
    private bool activo;

    private Vector2[] camino;
    private int objetivo;
    private bool mirandoDerecha;

    public bool LlegoAlFinal { get; private set; }

    public Enemigo(Texture2D sprite, int ancho, int alto, float velocidad, Vector2[] camino)
    {
        textura = sprite;
        this.velocidad = velocidad;
        this.camino = camino;
        activo = true;
        rectangulo = new Rectangle(0, 0, ancho, alto);

        posicion = camino[0];
        objetivo = 1;
        mirandoDerecha = true;
        ActualizarRectangulo();
    }

    private void ActualizarRectangulo()
    {
        rectangulo.X = (int)(posicion.X - rectangulo.Width / 2f);
        rectangulo.Y = (int)(posicion.Y - rectangulo.Height / 2f);
    }

    public void update()
    {
        Vector2 hacia = camino[objetivo] - posicion;
        float distancia = hacia.Length();

        if (hacia.X > 0.1f) mirandoDerecha = true;
        else if (hacia.X < -0.1f) mirandoDerecha = false;

        if (distancia <= velocidad)
        {
            posicion = camino[objetivo];
            objetivo++;

            if (objetivo >= camino.Length)
            {
                LlegoAlFinal = true;
                activo = false;
                return;
            }
        }
        else
        {
            hacia.Normalize();
            posicion += hacia * velocidad;
        }

        ActualizarRectangulo();
    }

    public void draw(SpriteBatch sb)
    {
        if (activo)
        {
            SpriteEffects efecto = mirandoDerecha ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            sb.Draw(textura, rectangulo, null, Color.White, 0f, Vector2.Zero, efecto, 0f);
        }
    }
}
