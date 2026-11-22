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
            float costo,
            int nivelDefensa,
            int costoMejora,
            int valorVenta)
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

            if (nivelDefensa > 0)
            {
                spriteBatch.DrawString(
                    fuente,
                    "Nivel: " + nivelDefensa,
                    new Vector2(1430, 130),
                    Color.Black
                );

                if (nivelDefensa < 3)
                {
                    spriteBatch.DrawString(
                        fuente,
                        "M Mejorar: $" +
                        costoMejora,
                        new Vector2(1430, 160),
                        Color.Black
                    );
                }
                else
                {
                    spriteBatch.DrawString(
                        fuente,
                        "Nivel MAX",
                        new Vector2(1430, 160),
                        Color.Black
                    );
                }

                spriteBatch.DrawString(
                    fuente,
                    "V Vender: $" +
                    valorVenta,
                    new Vector2(1430, 190),
                    Color.Black
                );
            }
        }
    }
}
