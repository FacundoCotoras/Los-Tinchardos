// CODIGO NO TERMINADO, ES PARA IR GUARDANDO
/*

HISTORIAL DEL PROYECTO

[1] Base del proyecto
- Instalación y configuración inicial de MonoGame.
- Ventana ampliada a 1600x900 para una mejor visualización.
- Mapa cargado y escalado al tamaño de la ventana.
- Pruebas iniciales de movimiento con personaje temporal.

[2] Sistema de construcción (primera versión)
- Incorporado sprite de cañón.
- Creado primer slot de construcción funcional.
- Detección de click sobre área válida.
- Colocación de torreta al construir.
- Sistema debug para visualizar zonas de construcción.

[3] Sistema de construcción mediante listas
- Reemplazado sistema de slot único por listas.
- Implementadas listas para:
    * Posiciones de torretas.
    * Áreas de construcción.
    * Estado de ocupación de cada slot.
- Adaptado sistema debug para múltiples slots.
- Primeros dos slots funcionales.
- Cada slot permite construir de forma independiente.

[4] Refactorización del sistema de construcción
- Reemplazadas las listas independientes de posiciones, áreas de construcción y estado de ocupación.
- Creado struct Slot para almacenar toda la información de una posición construible.
- Implementada lista de Slot para gestionar las posiciones de construcción del mapa.
- Sistema de detección de click adaptado al nuevo método.
- Sistema debug adaptado para visualizar múltiples slots.
- Verificado el funcionamiento correcto con múltiples posiciones de construcción.

PENDIENTE
- Completar todos los slots del mapa.
- Crear clase Torre.
- Implementar distintos tipos de defensas.
- Sistema de rango de ataque.
- Sistema de enemigos.
- Sistema de proyectiles.
- Personaje jugable.

*/

// ---------------------------------------------------------------------------------------------------------------\\
// ---------------------------------------------------------------------------------------------------------------\\
// ---------------------------------------------------------------------------------------------------------------\\

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TowerDefense
{
    struct Slot
    {
        public Vector2 PosicionTorre;

        public Rectangle AreaConstruccion;

        public bool TorreColocada;
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D mapa;
        private Texture2D canion;
        private Texture2D debugRect;
        private Vector2 posicion;
        private float velocidad = 200f;

        private List<Slot> slots = new List<Slot>();

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

            Slot slot1 = new Slot();

            slot1.PosicionTorre =
                new Vector2(235, 160);

            slot1.AreaConstruccion =
                new Rectangle(
                    235,
                    179,
                    90,
                    80
                );

            slot1.TorreColocada = false;
            slots.Add(slot1);


            Slot slot2 = new Slot();

            slot2.PosicionTorre =
                new Vector2(365, 160);

            slot2.AreaConstruccion =
                new Rectangle(
                    365,
                    179,
                    90,
                    80
                );

            slot2.TorreColocada = false;

            slots.Add(slot2);

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

            for (int i = 0; i < slots.Count; i++)
            {
                if (mouse.LeftButton == ButtonState.Pressed && slots[i].AreaConstruccion.Contains(
                        mouse.X,
                        mouse.Y))
                {
                    Slot temp = slots[i];

                    temp.TorreColocada = true;

                    slots[i] = temp;
                }
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

            for (int i = 0; i < slots.Count; i++)
            {
                _spriteBatch.Draw(
                    debugRect,
                    slots[i].AreaConstruccion,
                    Color.Green * 0.4f
                );
            }


            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].TorreColocada)
                {
                    _spriteBatch.Draw(
                        canion,
                        new Rectangle(
                            (int)slots[i].PosicionTorre.X,
                            (int)slots[i].PosicionTorre.Y,
                            90,
                            90
                        ),
                        Color.White
                    );
                }
            }

            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
