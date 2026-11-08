using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class HUD
    {
        public static void Dibujar(
            SpriteBatch spriteBatch,
            SpriteFont fuente,
            int dinero,
            string nombreDefensa,
            float costo)
        {
            spriteBatch.DrawString(
                fuente,
                "Dinero: $" + dinero,
                new Vector2(1430, 20),
                Color.Black
            );

            spriteBatch.DrawString(
                fuente,
                "Defensa: " + nombreDefensa,
                new Vector2(1430, 50),
                Color.Black
            );

            spriteBatch.DrawString(
                fuente,
                "Costo: $" + costo,
                new Vector2(1430, 80),
                Color.Black
            );
        }
    }
}