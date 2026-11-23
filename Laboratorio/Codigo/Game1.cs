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


        private string ObtenerNombreEnemigo()
        {
            switch (oleadas.Actual)
            {
                case 1:
                    return "Enemigo Rapido";

                case 2:

                    if (oleadas.Generados == 0)
                        return "Enemigo Rapido";

                    return "Enemigo Basico";

                case 3:

                    if (oleadas.Generados == 0)
                        return "Tanque";

                    return "Enemigo Basico";

                case 4:

                    if (oleadas.Generados < 2)
                        return "Enemigo Rapido";

                    if (oleadas.Generados < 4)
                        return "Enemigo Basico";

                    return "Tanque";

                case 5:

                    if (oleadas.Generados < 3)
                        return "Enemigo Rapido";

                    if (oleadas.Generados < 6)
                        return "Enemigo Basico";

                    return "Tanque";

                case 6:

                    if (oleadas.Generados < 5)
                        return "Enemigo Rapido";

                    return "Jefe";

                default:
                    return "Enemigo Basico";
            }
        }

        private Texture2D ObtenerSpriteEnemigo(string nombre)
        {
            switch (nombre)
            {
                case "Enemigo Rapido":
                    return topoNinja;

                case "Tanque":
                    return topoBlindado;

                case "Jefe":
                    return jefe;

                default:
                    return topo;
            }
        }

        private bool TeclaPresionada(
            KeyboardState actual,
        Keys tecla)
        {
            return
                actual.IsKeyDown(tecla) &&
                !tecladoAnterior.IsKeyDown(tecla);
        }

        private void ReiniciarJuego()
        {
            vidas = vidasMaximas;

            dinero = 1000;

            gameOver = false;
            victoria = false;

            slotSeleccionado = -1;

            topos.Clear();
            torres.Clear();
            proyectiles.Clear();

            slots = Mapa.CrearSlots();

            oleadas = new Oleadas();
        }


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D mapa;
        private Texture2D canion;
        private Texture2D canion2;
        private Texture2D canion3;
        private Texture2D torreta;
        private Texture2D torreta2;
        private Texture2D torreta3;
        private Texture2D lanzacohetes;
        private Texture2D lanzacohetes2;
        private Texture2D lanzacohetes3;
        Texture2D baseTorre;
        Texture2D proyectilCanion;
        Texture2D proyectilTorreta;
        Texture2D proyectilMisil;
        private Texture2D debugRect;
        private Texture2D rango;
        private Texture2D topo;
        private Texture2D topoNinja;
        private Texture2D topoBlindado;
        private Texture2D jefe;
        Texture2D texCorazon;
        Texture2D texCorazonVacio;
        Texture2D texGameOver;
        Texture2D texVictoria;
        Texture2D texReiniciar;
        Texture2D[] texOleada = new Texture2D[Oleadas.Total];
        bool victoria = false;
        Texture2D texPixel;
        private SpriteFont fuente;
        private Vector2 posicion;
        private TipoTorre torreSeleccionada = TipoTorre.Canion;
        private int slotSeleccionado = -1;
        private KeyboardState tecladoAnterior;

        private int dinero = 1000;
        const int vidasMaximas = 3;
        int vidas = vidasMaximas;
        bool gameOver = false;
        private float velocidad = 200f;
        private Oleadas oleadas = new Oleadas();
        private Random rnd = new Random();

        private List<Slot> slots = new List<Slot>();
        private List<DatosDefensa> defensas = new List<DatosDefensa>();
        private List<DatosEnemigo> enemigosBD = new List<DatosEnemigo>();

        private List<Enemigo> topos = new List<Enemigo>();
        private List<Torre> torres = new List<Torre>();
        private List<Proyectil> proyectiles =  new List<Proyectil>();


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
            enemigosBD = BaseDatos.CargarEnemigos();

            /*

            foreach (DatosEnemigo enemigo in enemigosBD)
            {
                System.Diagnostics.Debug.WriteLine(
                    enemigo.Nombre +
                    " $" +
                    enemigo.Recompensa
                );
            }

            */

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

            canion2 = Content.Load<Texture2D>("canion2");

            canion3 = Content.Load<Texture2D>("canion3");

            torreta = Content.Load<Texture2D>("torreta");

            torreta2 = Content.Load<Texture2D>("torreta2");

            torreta3 = Content.Load<Texture2D>("torreta3");

            lanzacohetes = Content.Load<Texture2D>("lanzacohetes");

            lanzacohetes2 = Content.Load<Texture2D>("lanzacohetes2");

            lanzacohetes3 = Content.Load<Texture2D>("lanzacohetes3");

            baseTorre = Content.Load<Texture2D>("base");

            proyectilCanion = Content.Load<Texture2D>("proyectilcanion");

            proyectilTorreta = Content.Load<Texture2D>("proyectiltorreta");

            proyectilMisil = Content.Load<Texture2D>("proyectilmisil");

            topo = Content.Load<Texture2D>("topo");

            topoNinja = Content.Load<Texture2D>("topoNinja");

            topoBlindado = Content.Load<Texture2D>("topoBlindado");

            jefe = Content.Load<Texture2D>("jefe");

            /*

            Enemigo enemigo =
               new Enemigo(
               topo,
               52,
               60,
               2.5f,
               camino
               );

            enemigo.Nombre = "Enemigo Basico";

            enemigo.ConfigurarVida(
                Economia.ObtenerVida(
                    enemigo.Nombre,
                    enemigosBD));

            enemigo.ConfigurarVelocidad(
                Economia.ObtenerVelocidad(
                    enemigo.Nombre,
                    enemigosBD));

            topos.Add(enemigo);


            */

            texCorazon = Content.Load<Texture2D>("corazon");
            texCorazonVacio = Content.Load<Texture2D>("corazonVacio");
            texGameOver = Content.Load<Texture2D>("gameover");
            texVictoria = Content.Load<Texture2D>("victoria");
            texReiniciar = Content.Load<Texture2D>("reiniciar");
            for (int i = 0; i < Oleadas.Total; i++)
            {
                texOleada[i] =
                    Content.Load<Texture2D>(
                        "oleada" + (i + 1));
            }

            texPixel = new Texture2D(GraphicsDevice, 1, 1);

            texPixel.SetData(
                new[] { Color.White }
            );

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

            if (gameOver || victoria)
            {
                if (
                    TeclaPresionada(
                        teclado,
                        Keys.R)
                   )
                {
                    ReiniciarJuego();
                }

                base.Update(gameTime);
                return;
            }

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

            if (slotSeleccionado != -1 && TeclaPresionada(teclado, Keys.V))
            {
                TipoTorre tipo =
                    slots[slotSeleccionado].Tipo;

                float costo =
                    Economia.ObtenerCosto(
                        tipo,
                        defensas);

                dinero +=
                    (int)(costo * 0.5f);

                Vector2 posicion =
                    slots[slotSeleccionado]
                    .PosicionTorre;

                for (int i = torres.Count - 1; i >= 0; i--)
                {
                    if (
                        torres[i].Posicion ==
                        posicion
                       )
                    {
                        torres.RemoveAt(i);
                        break;
                    }
                }

                Slot temp =
                    slots[slotSeleccionado];

                temp.TorreColocada = false;

                slots[slotSeleccionado] =
                    temp;

                slotSeleccionado = -1;
            }

            if (slotSeleccionado != -1 && TeclaPresionada(teclado, Keys.M))
            {
                Vector2 posicion =
                    slots[slotSeleccionado]
                    .PosicionTorre;

                foreach (Torre torre in torres)
                {
                    if (torre.Posicion == posicion)
                    {
                        if (torre.Nivel < 3)
                        {
                            float costoBase =
                                Economia.ObtenerCosto(
                                    torre.Tipo,
                                    defensas);

                            int costoMejora;

                            if (torre.Nivel == 1)
                            {
                                costoMejora =
                                    (int)(costoBase * 0.75f);
                            }
                            else
                            {
                                costoMejora =
                                    (int)(costoBase * 1.5f);
                            }

                            if (dinero >= costoMejora)
                            {
                                dinero -= costoMejora;

                                torre.Nivel++;

                                System.Diagnostics.Debug.WriteLine(
                                    "Nivel: " + torre.Nivel);
                            }
                        }

                        break;
                    }
                }
            }


            if (mouse.LeftButton == ButtonState.Pressed)
                {
                    slotSeleccionado = -1;

                    for (int i = 0; i < slots.Count; i++)
                    {
                        if (!slots[i].AreaConstruccion.Contains(
                            mouse.X,
                            mouse.Y))
                        {
                            continue;
                        }

                        if (slots[i].TorreColocada)
                        {
                            slotSeleccionado = i;
                        }
                        else
                        {
                            float costo =
                                Economia.ObtenerCosto(
                                    torreSeleccionada,
                                    defensas);

                            if (dinero >= costo)
                            {
                                dinero -= (int)costo;

                                Slot temp = slots[i];
                                temp.TorreColocada = true;
                                temp.Tipo = torreSeleccionada;
                                slots[i] = temp;

                                torres.Add(
                                    new Torre
                                    {
                                        Posicion = slots[i].PosicionTorre,
                                        Tipo = torreSeleccionada,
                                        Rango = ObtenerRango(
                                            torreSeleccionada),
                                        Cooldown = 0,
                                        Nivel = 1
                                    }
                                );
                            }
                        }

                        break;
                    }
                }
            

            
            /*
            Enemigo nuevo =
        oleadas.GenerarEnemigo(
            topo,
            camino);
            */
            string nombreEnemigo = ObtenerNombreEnemigo();

            Texture2D spriteEnemigo =
                ObtenerSpriteEnemigo(
                    nombreEnemigo);

            Enemigo nuevo =
                oleadas.GenerarEnemigo(
                    spriteEnemigo,
                    camino);

            if (nuevo != null)
            {
                nuevo.Nombre = nombreEnemigo;

                if (nuevo.Nombre == "Jefe")
                {
                    nuevo.CambiarTamanio(90, 100);
                }
                nuevo.ConfigurarVida(
                    Economia.ObtenerVida(
                        nuevo.Nombre,
                        enemigosBD));

                nuevo.ConfigurarVelocidad(
                    Economia.ObtenerVelocidad(
                        nuevo.Nombre,
                        enemigosBD));

                topos.Add(nuevo);
            }


            for (int i = topos.Count - 1; i >= 0; i--)
            {
                topos[i].update();

                if (topos[i].Nombre == "Jefe")
                {
                    topos[i].CooldownInvocacion++;

                    if (topos[i].CooldownInvocacion >= 150)
                    {
                        topos[i].CooldownInvocacion = 0;

                        Enemigo invocado =
                            new Enemigo(
                                topo,
                                52,
                                60,
                                2.5f,
                                camino);

                        invocado.Nombre =
                            "Enemigo Basico";

                        invocado.ConfigurarVida(
                            Economia.ObtenerVida(
                                "Enemigo Basico",
                                enemigosBD));

                        invocado.ConfigurarVelocidad(
                            Economia.ObtenerVelocidad(
                                "Enemigo Basico",
                                enemigosBD));

                        topos.Add(invocado);
                    }
                }



                if (topos[i].Vida <= 0)
                {
                    // System.Diagnostics.Debug.WriteLine(topos[i].Nombre); 
                    dinero += Economia.ObtenerRecompensa(topos[i].Nombre, enemigosBD);
                    topos.RemoveAt(i);
                    continue;
                }

                if (topos[i].LlegoAlFinal)
                {
                    vidas--;

                    topos.RemoveAt(i);
                }
            }

            oleadas.VerificarFin(topos.Count);

            if (oleadas.Completadas)
            {
                victoria = true;
            }


            foreach (Enemigo topo in topos)
            {
                topo.Seleccionado = false;
            }


            for (int i = 0; i < slots.Count; i++)
            {
                if (!slots[i].TorreColocada)
                    continue;

                float rangoTorre =
                    ObtenerRango(slots[i].Tipo);

            

                foreach (Enemigo topo in topos)
                {
                    float distancia =
                        Vector2.Distance(
                            slots[i].PosicionTorre,
                            topo.Posicion);

                    if (distancia <= rangoTorre)
                    {
                        topo.Seleccionado = true;
                        break;
                    }
                }
            }
            Combate.ActualizarObjetivos(
            torres,
            topos);

            Combate.Disparar(
            torres,
            proyectiles,
            defensas);


            /*

            int torresConObjetivo = 0;

            foreach (Torre torre in torres)
            {
                if (torre.Objetivo != null)
                {
                    torresConObjetivo++;
                }
            }

            System.Diagnostics.Debug.WriteLine(
                "Torres apuntando: " + torresConObjetivo);

            */

            if (vidas <= 0)
            {
                vidas = 0;
                gameOver = true;
            }

            Combate.ActualizarProyectiles(
                proyectiles);

            tecladoAnterior = teclado;

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

            foreach (Enemigo topo in topos)
            {
                float porcentajeVida =
                    (float)topo.Vida /
                    topo.VidaMaxima;

                int anchoTotal = 40;

                int anchoActual =
                    (int)(anchoTotal * porcentajeVida);

                // Fondo rojo
                _spriteBatch.Draw(
                    debugRect,
                    new Rectangle(
                        (int)topo.Posicion.X - 20,
                        (int)topo.Posicion.Y - 35,
                        anchoTotal,
                        5),
                    Color.Red
                );

                // Vida verde
                _spriteBatch.Draw(
                    debugRect,
                    new Rectangle(
                        (int)topo.Posicion.X - 20,
                        (int)topo.Posicion.Y - 35,
                        anchoActual,
                        5),
                    Color.LimeGreen
                );
            }

            foreach (Enemigo topo in topos)
            {
                if (topo.Seleccionado)
                {
                    _spriteBatch.Draw(
                        debugRect,
                        new Rectangle(
                            (int)topo.Posicion.X - 15,
                            (int)topo.Posicion.Y - 15,
                            30,
                            30
                        ),
                        Color.Red * 0.6f
                    );
                }
            }


            for (int i = 0; i < vidasMaximas; i++)
            {
                Texture2D texCorazonActual =
                    (i < vidas)
                    ? texCorazon
                    : texCorazonVacio;

                _spriteBatch.Draw(
                    texCorazonActual,
                    new Vector2(
                        15 + i * 50,
                        15),
                    Color.White
                );
            }


            _spriteBatch.Draw(
                texOleada[
                    oleadas.Actual - 1
                ],
                new Vector2(
                    (1600 -
                    texOleada[
                        oleadas.Actual - 1
                    ].Width) / 2,
                    10),
                Color.White
             );


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

                    Torre torreActual = null;

                    foreach (Torre torre in torres)
                    {
                        if (
                            torre.Posicion ==
                            slots[i].PosicionTorre
                           )
                        {
                            torreActual = torre;
                            break;
                        }
                    }

                    int nivel = 1;

                    if (torreActual != null)
                    {
                        nivel = torreActual.Nivel;
                    }

                    switch (slots[i].Tipo)
                    {
                        case TipoTorre.Canion:

                            if (nivel == 1)
                                textura = canion;
                            else if (nivel == 2)
                                textura = canion2;
                            else
                                textura = canion3;

                            break;

                        case TipoTorre.Torreta:

                            if (nivel == 1)
                                textura = torreta;
                            else if (nivel == 2)
                                textura = torreta2;
                            else
                                textura = torreta3;

                            break;

                        case TipoTorre.Lanzacohetes:

                            if (nivel == 1)
                                textura = lanzacohetes;
                            else if (nivel == 2)
                                textura = lanzacohetes2;
                            else
                                textura = lanzacohetes3;

                            break;

                        default:

                            textura = canion;
                            break;
                    }

                    Vector2 offsetDibujo = new Vector2(43, 55);

                    if (slots[i].Tipo ==
                        TipoTorre.Lanzacohetes)
                    {
                        offsetDibujo =
                            new Vector2(43, 60);
                    }

                    float rotacion = torreActual != null ? torreActual.Rotacion : 0f;

                    Vector2 origenTorre =
                        new Vector2(
                            textura.Width / 2f,
                            textura.Height * 0.75f);

                    if (
                        slots[i].Tipo == TipoTorre.Lanzacohetes &&
                        nivel == 1
                       )
                    {
                        origenTorre =
                            new Vector2(
                                textura.Width * 0.47f,
                                textura.Height * 0.68f);
                    }
                    if (torreActual != null && torreActual.Objetivo != null)
                    {
                        Vector2 direccion =
                            torreActual.Objetivo.Posicion -
                            (torreActual.Posicion +
                             new Vector2(45, 45));

                        rotacion =
                            (float)Math.Atan2(
                                direccion.Y,
                                direccion.X)
                            + MathHelper.PiOver2;

                        torreActual.Rotacion = rotacion;
                    }

                    _spriteBatch.Draw(
                        baseTorre,
                        new Rectangle(
                            (int)slots[i].PosicionTorre.X  + 15,
                            (int)slots[i].PosicionTorre.Y + 25,
                            55,
                            55
                        ),
                        Color.White
                    );

                    _spriteBatch.Draw(
                        textura,
                        slots[i].PosicionTorre +
                            offsetDibujo,
                        null,
                        Color.White,
                        rotacion,
                        origenTorre,
                        0.28f,
                        SpriteEffects.None,
                        0f
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
            int nivelDefensa = 0;
            int costoMejora = 0;
            int valorVenta = 0;


            if (slotSeleccionado != -1)
            {
                Torre torreActual = null;

                foreach (Torre torre in torres)
                {
                    if (
                        torre.Posicion ==
                        slots[slotSeleccionado]
                        .PosicionTorre
                       )
                    {
                        torreActual = torre;
                        break;
                    }
                }

                if (torreActual != null)
                {
                    nivelDefensa =
                        torreActual.Nivel;

                    float costoBase =
                        Economia.ObtenerCosto(
                            torreActual.Tipo,
                            defensas);

                    valorVenta =
                        (int)(costoBase * 0.5f);

                    if (torreActual.Nivel == 1)
                    {
                        costoMejora =
                            (int)(costoBase * 0.75f);
                    }
                    else if (
                        torreActual.Nivel == 2)
                    {
                        costoMejora =
                            (int)(costoBase * 1.5f);
                    }
                }
            }

            HUD.Dibujar(
                _spriteBatch,
                fuente,
                dinero,
                nombreDefensa,
                Economia.ObtenerCosto(torreSeleccionada,
                    defensas),
                nivelDefensa,
                costoMejora,
                valorVenta
);



            if (gameOver)
            {
                _spriteBatch.Draw(
                    texPixel,
                    new Rectangle(
                        0,
                        0,
                        GraphicsDevice.Viewport.Width,
                        GraphicsDevice.Viewport.Height),
                    Color.Black * 0.6f
                );

                int anchoCartel =
                    (int)(texGameOver.Width * 1.5f);

                int altoCartel =
                    (int)(texGameOver.Height * 1.5f);

                Rectangle cartel =
                    new Rectangle(
                        (1600 - anchoCartel) / 2,
                        (900 - altoCartel) / 2,
                        anchoCartel,
                        altoCartel
                    );

                _spriteBatch.Draw(
                    texGameOver,
                    cartel,
                    Color.White
                );

                _spriteBatch.Draw(
                    texReiniciar,
                    new Vector2(
                            (1600 - texReiniciar.Width) / 2,
                            cartel.Bottom + 25),
                    Color.White
                );
            }

            if (victoria)
            {
                _spriteBatch.Draw(
                    texPixel,
                    new Rectangle(
                        0,
                        0,
                        GraphicsDevice.Viewport.Width,
                        GraphicsDevice.Viewport.Height),
                    Color.Black * 0.6f
                );

                Rectangle cartel =
                    new Rectangle(
                        (1600 - texVictoria.Width) / 2,
                        (900 - texVictoria.Height) / 2,
                        texVictoria.Width,
                        texVictoria.Height
                    );

                _spriteBatch.Draw(
                    texVictoria,
                    cartel,
                    Color.White
                );

                _spriteBatch.Draw(
                    texReiniciar,
                    new Vector2(
                        (1600 - texReiniciar.Width) / 2,
                        cartel.Bottom + 25),
                    Color.White
                );
            }


            foreach (Proyectil proyectil in proyectiles)
            {
                Texture2D textura;
                int ancho;
                int alto;
                switch (proyectil.Tipo)
                {
                    case TipoTorre.Canion:
                        textura = proyectilCanion;
                        ancho = 10;
                        alto = 20;
                        break;

                    case TipoTorre.Torreta:
                        textura = proyectilTorreta;
                        ancho = 8;
                        alto = 28;
                        break;

                    case TipoTorre.Lanzacohetes:
                        textura = proyectilMisil;
                        ancho = 14;
                        alto = 25;
                        break;

                    default:
                        textura = proyectilCanion;
                        ancho = 10;
                        alto = 20;
                        break;
                }

                _spriteBatch.Draw(
                    textura,
                    proyectil.Posicion,
                    null,
                    Color.White,
                    proyectil.Rotacion,
                    new Vector2(
                        textura.Width / 2f,
                        textura.Height * 0.70f),
                    0.35f,
                    SpriteEffects.None,
                    0f
                );
            }

            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
