using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TopoCamino;

class HUD
{
    private Texture2D texCorazon, texCorazonVacio;
    private Texture2D texGameOver, texVictoria, texReiniciar;
    private Texture2D texPixel;
    private Texture2D[] texOleada = new Texture2D[Oleadas.Total];

    public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
    {
        texCorazon = content.Load<Texture2D>("corazon");
        texCorazonVacio = content.Load<Texture2D>("corazonVacio");
        texGameOver = content.Load<Texture2D>("gameover");
        texVictoria = content.Load<Texture2D>("victoria");
        texReiniciar = content.Load<Texture2D>("reiniciar");

        for (int i = 0; i < Oleadas.Total; i++)
        {
            texOleada[i] = content.Load<Texture2D>("oleada" + (i + 1));
        }

        texPixel = new Texture2D(graphicsDevice, 1, 1);
        texPixel.SetData(new Color[] { Color.White });
    }

    public void draw(SpriteBatch sb, int vidas, int vidasMaximas, int oleada, bool gameOver, bool victoria)
    {
        for (int i = 0; i < vidasMaximas; i++)
        {
            Texture2D corazon = (i < vidas) ? texCorazon : texCorazonVacio;
            sb.Draw(corazon, new Vector2(15 + i * 50, 15), Color.White);
        }

        Texture2D cartelOleada = texOleada[oleada - 1];
        sb.Draw(cartelOleada, new Vector2((Mapa.Ancho - cartelOleada.Width) / 2, 10), Color.White);

        if (gameOver || victoria)
        {
            sb.Draw(texPixel, new Rectangle(0, 0, Mapa.Ancho, Mapa.Alto), Color.Black * 0.6f);

            Texture2D cartel = gameOver ? texGameOver : texVictoria;
            float escala = gameOver ? 1.5f : 1f;
            int anchoCartel = (int)(cartel.Width * escala);
            int altoCartel = (int)(cartel.Height * escala);
            Rectangle recCartel = new Rectangle((Mapa.Ancho - anchoCartel) / 2,
                                                (Mapa.Alto - altoCartel) / 2,
                                                anchoCartel, altoCartel);
            sb.Draw(cartel, recCartel, Color.White);

            sb.Draw(texReiniciar,
                new Vector2((Mapa.Ancho - texReiniciar.Width) / 2, recCartel.Bottom + 25), Color.White);
        }
    }
}
