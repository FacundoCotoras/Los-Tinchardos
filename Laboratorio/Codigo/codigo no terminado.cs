// CODIGO NO TERMINADO, ES PARA IR GUARDANDO
/*

HISTORIAL DEL PROYECTO

[1]
- Mapa cargado y escalado a la ventana.
- Ventana ampliada a 1600x900.
- Pruebas iniciales con personaje.

[2]
- Sistema básico de construcción.
- Torreta colocable mediante click.
- Primer slot funcional.
- Sistema debug para visualizar áreas de construcción.

PENDIENTE
- Agregar más slots.
- Sistema de listas para slots.
- Múltiples torres.
- Enemigos.

*/

// ---------------------------------------------------------------------------------------------------------------\\
// ---------------------------------------------------------------------------------------------------------------\\
// ---------------------------------------------------------------------------------------------------------------\\

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D mapa;
        private Texture2D canion;
        private Texture2D debugRect;
        private Vector2 posicion;
        private float velocidad = 200f;

        Vector2 slot = new Vector2(235, 160);
        Rectangle areaSlot = new Rectangle(
        235,
        179,
        90,
        80
        );

        private bool torreColocada = false;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            mapa = Content.Load<Texture2D>("mapa");

            canion = Content.Load<Texture2D>("canion");

            posicion = new Vector2(100, 100);

            debugRect = new Texture2D(GraphicsDevice, 1, 1);

            debugRect.SetData(new[] { Color.White });
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState teclado = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            float tiempo = (float)gameTime
                .ElapsedGameTime.TotalSeconds;

            if (teclado.IsKeyDown(Keys.Right))
            {
                posicion.X += velocidad * tiempo;
            }

            if (teclado.IsKeyDown(Keys.Left))
            {
                posicion.X -= velocidad * tiempo;
            }

            if (teclado.IsKeyDown(Keys.Up))
            {
                posicion.Y -= velocidad * tiempo;
            }

            if (teclado.IsKeyDown(Keys.Down))
            {
                posicion.Y += velocidad * tiempo;
            }

            if (mouse.LeftButton == ButtonState.Pressed && areaSlot.Contains(mouse.X, mouse.Y))
            {
                torreColocada = true;
            }





            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            Rectangle pantalla = new Rectangle(
             0,
             0,
             GraphicsDevice.Viewport.Width,
             GraphicsDevice.Viewport.Height
             );


            _spriteBatch.Draw(
                mapa,
                pantalla,
                Color.White
            );

            // SISTEMA DEBUG PARA VERIFICAR EL AREA DE COLOCACION DE TORRES
            /*  _spriteBatch.Draw(
                  debugRect,
                  areaSlot,
                  Color.Green * 0.4f
              ); */

            if (torreColocada)
            {
                _spriteBatch.Draw(
                    canion,
                    new Rectangle(
                        (int)slot.X,
                        (int)slot.Y,
                        90,
                        90
                    ),
                    Color.White
                );
            }

            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

