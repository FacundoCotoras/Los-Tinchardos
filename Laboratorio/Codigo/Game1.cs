using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace TowerDefense
{
    
    
    public class Game1 : Game
    {
        static readonly Vector2[] camino =
        {
            new Vector2(91.49f, 130.154f),
            new Vector2(643.044f, 130.154f),
            new Vector2(643.044f, 334.209f),
            new Vector2(1117.485f, 334.209f),
            new Vector2(1117.485f, 608.856f),
            new Vector2(437.845f, 608.856f), 
            new Vector2(437.845f, 775.409f),
            new Vector2(1352.745f, 775.409f),
            new Vector2(1352.745f, 641.946f), 
            new Vector2(1516.12f, 641.946f)
        };

        private List<Enemigo> topos =
            new List<Enemigo>();

        private float ObtenerRango(TipoTorre tipo)
        {
            string nombre = "";

            switch (tipo)
            {
                case TipoTorre.Canion:
                    nombre = "Cañon";
                    break;

                case TipoTorre.Torreta:
                    nombre = "Torreta";
                    break;

                case TipoTorre.Lanzacohetes:
                    nombre = "Lanzacohetes";
                    break;
            }

            foreach (DatosDefensa d in defensas)
            {
                if (d.Nombre == nombre)
                {
                    return d.Rango;
                }
            }

            return 100f;
        }

        private float ObtenerCosto(TipoTorre tipo)
        {
            string nombre = "";

            switch (tipo)
            {
                case TipoTorre.Canion:
                    nombre = "Cañon";
                    break;

                case TipoTorre.Torreta:
                    nombre = "Torreta";
                    break;

                case TipoTorre.Lanzacohetes:
                    nombre = "Lanzacohetes";
                    break;
            }

            foreach (DatosDefensa d in defensas)
            {
                if (d.Nombre == nombre)
                {
                    return d.Costo;
                }
            }

            return 0;
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D mapa;
        private Texture2D canion;
        private Texture2D torreta;
        private Texture2D lanzacohetes;
        private Texture2D debugRect;
        private Texture2D rango;
        private Texture2D topo;
        private SpriteFont fuente;
        private Vector2 posicion;
        private TipoTorre torreSeleccionada = TipoTorre.Canion;
        private int slotSeleccionado = -1;
        private int dinero = 1000;
        private int contadorEnemigos = 0;
        private const int framesEntreEnemigos = 120;
        private float velocidad = 200f;

        private List<Slot> slots = new List<Slot>();
        private List<DatosDefensa> defensas = new List<DatosDefensa>();



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

            slots = Mapa.CrearSlots();

            defensas = BaseDatos.CargarDefensas();

            /*
            topos.Add(
            new Personaje(
                topo,
                52,
                60,
                2.5f,
                camino
             ));
            */

            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            mapa = Content.Load<Texture2D>("mapa");

            canion = Content.Load<Texture2D>("canion");

            torreta = Content.Load<Texture2D>("torreta");

            lanzacohetes = Content.Load<Texture2D>("lanzacohetes");

            topo = Content.Load<Texture2D>("topo");

            topos.Add(
            new Enemigo(
                topo,
                52,
                60,
                2.5f,
                camino
            ));

            rango = Content.Load<Texture2D>("rango");

            fuente = Content.Load<SpriteFont>("fuente");

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

            if (teclado.IsKeyDown(Keys.D1))
            {
                torreSeleccionada = TipoTorre.Canion;
            }

            if (teclado.IsKeyDown(Keys.D2))
            {
                torreSeleccionada = TipoTorre.Torreta;
            }

            if (teclado.IsKeyDown(Keys.D3))
            {
                torreSeleccionada = TipoTorre.Lanzacohetes;
            }

            for (int i = 0; i < slots.Count; i++)
            {
                if (mouse.LeftButton == ButtonState.Pressed && slots[i].AreaConstruccion.Contains(
                    mouse.X,
                    mouse.Y))
                {
                    float costo =
                        ObtenerCosto(
                            torreSeleccionada);

                    if (!slots[i].TorreColocada &&
                        dinero >= costo)
                    {
                        dinero -= (int)costo;

                        Slot temp = slots[i];

                        temp.TorreColocada = true;
                        temp.Tipo = torreSeleccionada;

                        slots[i] = temp;

                        System.Diagnostics.Debug.WriteLine(
                            "Dinero: " + dinero);
                    }
                }
            }

            if (mouse.RightButton == ButtonState.Pressed)
            {
                slotSeleccionado = -1;

                for (int i = 0; i < slots.Count; i++)
                {
                    if (slots[i].TorreColocada &&
                        slots[i].AreaConstruccion.Contains(
                            mouse.X,
                            mouse.Y))
                    {
                        slotSeleccionado = i;
                    }
                }
            }

            contadorEnemigos++;

            if (contadorEnemigos >= framesEntreEnemigos)
            {
                topos.Add(
                    new Enemigo(
                        topo,
                        52,
                        60,
                        2.5f,
                        camino
                    )
                );

                contadorEnemigos = 0;
            }


            foreach (Enemigo topo in topos)
            {
                topo.update();
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

            


            foreach (Enemigo topo in topos)
            {
                topo.draw(_spriteBatch);
            }

            // SISTEMA DEBUG PARA VERIFICAR EL AREA DE COLOCACION DE TORRES


            /*

            for (int i = 0; i < slots.Count; i++)
            {
                _spriteBatch.Draw(
                    debugRect,
                    slots[i].AreaConstruccion,
                    Color.Green * 0.4f
                );
            }

            */

            // SISTEMA DEBUG PARA VERIFICAR WAYPOINTS DEL CAMINO DE LOS ENEMIGOS


            /*
            for (int i = 0; i < camino.Length; i++)
            {
                _spriteBatch.Draw(
                    debugRect,
                    new Rectangle(
                        (int)camino[i].X - 10,
                        (int)camino[i].Y - 10,
                        20,
                        20),
                    Color.Red
                );
            }

            */


            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].TorreColocada)
                {
                    Texture2D textura;

                    switch (slots[i].Tipo)
                    {
                        case TipoTorre.Canion:
                            textura = canion;
                            break;

                        case TipoTorre.Torreta:
                            textura = torreta;
                            break;

                        case TipoTorre.Lanzacohetes:
                            textura = lanzacohetes;
                            break;

                        default:
                            textura = canion;
                            break;
                    }

                    _spriteBatch.Draw(
                        textura,
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

            if (slotSeleccionado != -1)
            {
                float radio =
                   ObtenerRango(
                        slots[slotSeleccionado].Tipo
                    );

                Rectangle areaRango =
                    new Rectangle(
                        (int)(slots[slotSeleccionado].PosicionTorre.X + 45 - radio),
                        (int)(slots[slotSeleccionado].PosicionTorre.Y + 45 - radio),
                        (int)(radio * 2),
                        (int)(radio * 2)
                    );

                _spriteBatch.Draw(
                    rango,
                    areaRango,
                    Color.Gray
                );
            }

            string nombreDefensa = torreSeleccionada.ToString().Replace("Canion", "Cañón");

            HUD.Dibujar(
                _spriteBatch,
                fuente,
                dinero,
                nombreDefensa,
                ObtenerCosto(torreSeleccionada)
            );

            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
