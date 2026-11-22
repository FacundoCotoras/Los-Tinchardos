using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense;

class Oleadas
{
    public const int Total = 5;

    private static readonly int[]   enemigosPorOleada  = { 6, 8, 10, 12, 15 };
    private static readonly int[]   framesEntreEnemigos = { 100, 85, 75, 65, 55 };
    private static readonly float[] velocidadPorOleada = { 2.0f, 2.3f, 2.6f, 2.9f, 3.2f };

    private const int pausaInicial = 120;
    private const int pausaEntreOleadas = 180;

    private bool enPausa;
    private int framesPausa;
    private int generados;
    private int contador;

    public int Actual { get; private set; }

    public bool Completadas { get; private set; }

    public Oleadas()
    {
        Reiniciar();
    }

    public void Reiniciar()
    {
        Actual = 1;
        Completadas = false;
        generados = 0;
        enPausa = true;
        framesPausa = pausaInicial;
    }

    public Enemigo GenerarEnemigo(Texture2D sprite, Vector2[] camino)
    {
        if (Completadas) return null;

        if (enPausa)
        {
            framesPausa--;
            if (framesPausa <= 0)
            {
                enPausa = false;
                generados = 0;
                contador = framesEntreEnemigos[Actual - 1];
            }
        }
        else if (generados < enemigosPorOleada[Actual - 1])
        {
            contador++;
            if (contador >= framesEntreEnemigos[Actual - 1])
            {
                generados++;
                contador = 0;
                return new Enemigo(sprite, 52, 60, velocidadPorOleada[Actual - 1], camino);
            }
        }

        return null;
    }

    public void VerificarFin(int enemigosEnMapa)
    {
        if (Completadas || enPausa) return;

        if (generados >= enemigosPorOleada[Actual - 1] && enemigosEnMapa == 0)
        {
            if (Actual >= Total)
            {
                Completadas = true;
            }
            else
            {
                Actual++;
                enPausa = true;
                framesPausa = pausaEntreOleadas;
            }
        }
    }
}
