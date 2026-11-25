using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class HUD
    {
        public static void Dibujar(
            SpriteBatch spriteBatch,
            SpriteFont fuente,
            Texture2D pixel,
            int dinero,
            int vidas,
            int oleada,
            string nombreDefensa,
            float costo,
            int nivelDefensa,
            int costoMejora,
            int valorVenta)
        {
            Rectangle panel = new Rectangle(1250, 20, 330, 365);

            spriteBatch.Draw(
                pixel,
                panel,
                new Color(25, 30, 42)
            );

            spriteBatch.Draw(
                pixel,
                new Rectangle(1250, 20, 330, 5),
                Color.Gold
            );

            spriteBatch.DrawString(
                fuente,
                "INFORMACION DE PARTIDA",
                new Vector2(1270, 40),
                Color.Gold
            );

            spriteBatch.DrawString(
                fuente,
                "Dinero: $" + dinero,
                new Vector2(1270, 80),
                Color.White
            );

            spriteBatch.DrawString(
                fuente,
                "Vidas: " + vidas + " / 3",
                new Vector2(1270, 110),
                Color.White
            );

            spriteBatch.DrawString(
                fuente,
                "Oleada: " + oleada,
                new Vector2(1270, 140),
                Color.White
            );

            spriteBatch.Draw(
                pixel,
                new Rectangle(1270, 180, 290, 2),
                Color.Gray
            );

            spriteBatch.DrawString(
                fuente,
                "TORRETA SELECCIONADA",
                new Vector2(1270, 200),
                Color.Gold
            );

            spriteBatch.DrawString(
                fuente,
                nombreDefensa,
                new Vector2(1270, 235),
                Color.White
            );

            spriteBatch.DrawString(
                fuente,
                "Costo: $" + costo,
                new Vector2(1270, 265),
                Color.White
            );

            if (nivelDefensa > 0)
            {
                spriteBatch.DrawString(
                    fuente,
                    "Nivel: " + nivelDefensa + " / 3",
                    new Vector2(1270, 295),
                    Color.White
                );

                if (nivelDefensa < 3)
                {
                    spriteBatch.DrawString(
                        fuente,
                        "M - Mejorar: $" + costoMejora,
                        new Vector2(1270, 330),
                        Color.LightGreen
                    );
                }
                else
                {
                    spriteBatch.DrawString(
                        fuente,
                        "NIVEL MAXIMO",
                        new Vector2(1270, 330),
                        Color.Gold
                    );
                }

                spriteBatch.DrawString(
                    fuente,
                    "V - Vender: $" + valorVenta,
                    new Vector2(1270, 355),
                    Color.OrangeRed
                );
            }
            else
            {
                spriteBatch.DrawString(
                    fuente,
                    "Selecciona una torreta",
                    new Vector2(1270, 310),
                    Color.LightGray
                );

                spriteBatch.DrawString(
                    fuente,
                    "para construirla",
                    new Vector2(1270, 340),
                    Color.LightGray
                );
            }
        }
    }
}
