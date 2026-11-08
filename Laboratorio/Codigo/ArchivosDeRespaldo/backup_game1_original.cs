// ARCHIVO DE BACKUP, YA MUDE TODO A cs SEPARADOS, ESTE ARCHIVO DEJA DE RECIBIR ACTUALIZACIONES
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

[5] Sistema completo de posiciones construibles
- Añadidos todos los slots de construcción del mapa.
- Configuradas las posiciones visuales de las torretas.
- Ajustadas manualmente las áreas de construcción para cada slot.
- Verificado el funcionamiento correcto de los 38 slots disponibles.
- Comprobada la compatibilidad del sistema basado en struct Slot con todas las posiciones del mapa.
- Finalizado el sistema base de colocación de defensas.

[6] Sistema de tipos de defensa
- Incorporados nuevos sprites de defensas.
- Agregados los tipos Cañón, Torreta y Lanzacohetes.
- Creado enum TipoTorre para representar cada defensa.
- Modificado struct Slot para almacenar el tipo de defensa colocada.
- Sistema de dibujo adaptado para mostrar la textura correspondiente según el tipo de torre.
- Verificado el funcionamiento correcto de múltiples tipos de defensas dentro del mapa.

[7] Selección de tipo de defensa
- Implementado sistema de selección mediante teclado.
- Tecla 1: Cañón.
- Tecla 2: Torreta.
- Tecla 3: Lanzacohetes.
- Adaptado el sistema de construcción para colocar el tipo seleccionado por el jugador.
- Verificado el funcionamiento correcto de construcción y reemplazo de defensas en cualquier slot.

[8] Sistema de selección e inspección de defensas
- Implementada selección de defensas mediante click derecho.
- Incorporado sistema de deselección al hacer click fuera de una defensa.
- Agregado sistema de alcance visual para la defensa seleccionada.
- Implementados alcances distintos para cada tipo de defensa.
- Sustituido sistema temporal de depuración por anillo visual de alcance.
- Verificado el funcionamiento correcto de selección, deselección y visualización de alcance.

[9] Integración inicial con Base de Datos
- Instalado MySqlConnector.
- Implementada conexión entre MonoGame y MySQL.
- Ejecutada consulta mediante Stored Procedure.
- Lectura correcta de registros de DefenseTypes.
- Verificada la comunicación entre el juego y la base de datos.

[10] Integración funcional de estadísticas desde Base de Datos
- Creada la clase DatosDefensa.
- Implementada una colección en memoria para almacenar las defensas obtenidas desde la BD.
- Modificada la lectura del Stored Procedure Defensas() para cargar los atributos de cada defensa.
- Incorporado el campo Rango al procedimiento almacenado.
- Verificada la carga correcta de Nombre, Costo, Daño, Vida y Rango.
- Reemplazados los rangos hardcodeados por valores obtenidos desde MySQL.
- Comprobada la actualización dinámica del juego al modificar registros de DefenseTypes.
- Validada la utilización de datos de la BD dentro de la lógica de MonoGame.

[11] Sistema económico inicial
- Implementado dinero inicial de partida.
- Creada la función ObtenerCosto() utilizando los datos cargados desde la base de datos.
- Las defensas ahora consumen recursos al construirse.
- Bloqueada la construcción cuando el jugador no dispone de dinero suficiente.
- Agregado HUD mostrando dinero disponible en tiempo real.
- Agregado HUD mostrando la defensa seleccionada.
- Agregado HUD mostrando el costo de la defensa seleccionada.
- Configurada la SpriteFont para soportar caracteres especiales y acentos (ñ, á, etc.).


PENDIENTE
- Crear clase Torre.
- Sistema de enemigos.
- Sistema de proyectiles.
- Obtener dinero al eliminar enemigos.
- Mejoras, reparación y venta de defensas.
- Personaje jugable.

*/

// ---------------------------------------------------------------------------------------------------------------\\
// ---------------------------------------------------------------------------------------------------------------\\
// ---------------------------------------------------------------------------------------------------------------\\

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace TowerDefense
{
    struct Slot
    {
        public Vector2 PosicionTorre;
        public Rectangle AreaConstruccion;
        public bool TorreColocada;
        public TipoTorre Tipo;

    }
    enum TipoTorre
    {
        Canion,
        Torreta,
        Lanzacohetes
    }

    class DatosDefensa
    {
        public string Nombre;
        public float Costo;
        public float Danio;
        public float Vida;
        public float Rango;
    }


    public class Game1 : Game
    {
        private void ProbarConexion()
        {
            string cadena =
                "Server=127.0.0.1;" +
                "Database=IronBastion;" +
                "User ID=root;" +
                "Password=;";

            try
            {
                using var conexion =
                    new MySqlConnection(cadena);

                conexion.Open();

                System.Diagnostics.Debug.WriteLine("Conectado");

                using var comando =
                    new MySqlCommand(
                        "Defensas",
                        conexion);

                comando.CommandType =
                    CommandType.StoredProcedure;

                using var lector =
                    comando.ExecuteReader();

                while (lector.Read())
                {
                    DatosDefensa defensa =
                        new DatosDefensa();

                    defensa.Nombre =
                        lector["Nombre"].ToString();

                    defensa.Costo =
                        Convert.ToSingle(
                            lector["Costo"]);

                    defensa.Danio =
                        Convert.ToSingle(
                            lector["DañoBase"]);

                    defensa.Vida =
                        Convert.ToSingle(
                            lector["VidaBase"]);

                    defensa.Rango =
                        Convert.ToSingle(
                            lector["Rango"]);

                    defensas.Add(defensa);

                    System.Diagnostics.Debug.WriteLine(
                        defensa.Nombre +
                        " | $" +
                        defensa.Costo);
                }

                System.Diagnostics.Debug.WriteLine(
                    "Cantidad defensas: " + defensas.Count);

                foreach (DatosDefensa d in defensas)
                {
                    System.Diagnostics.Debug.WriteLine(
                        d.Nombre +
                        " rango: " +
                        d.Rango);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
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
        private SpriteFont fuente;
        private Vector2 posicion;
        private TipoTorre torreSeleccionada = TipoTorre.Canion;
        private int slotSeleccionado = -1;
        private int dinero = 1000;
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

            Slot slot3 = new Slot();

            slot3.PosicionTorre =
                new Vector2(490, 160);

            slot3.AreaConstruccion =
                new Rectangle(
                    492,
                    179,
                    90,
                    80
                );

            slot3.TorreColocada = false;

            slots.Add(slot3);

            Slot slot4 = new Slot();

            slot4.PosicionTorre =
                new Vector2(492, 260);

            slot4.AreaConstruccion =
                new Rectangle(
                    492,
                    280,
                    90,
                    80
                );

            slot4.TorreColocada = false;

            slots.Add(slot4);

            Slot slot5 = new Slot();

            slot5.PosicionTorre =
                new Vector2(320, -5);

            slot5.AreaConstruccion =
                new Rectangle(
                    320,
                    15,
                    90,
                    73
                );

            slot5.TorreColocada = false;

            slots.Add(slot5);

            Slot slot6 = new Slot();

            slot6.PosicionTorre =
                new Vector2(445, -5);

            slot6.AreaConstruccion =
                new Rectangle(
                    445,
                    15,
                    90,
                    73
                );

            slot6.TorreColocada = false;

            slots.Add(slot6);

            Slot slot7 = new Slot();

            slot7.PosicionTorre =
                new Vector2(565, -5);

            slot7.AreaConstruccion =
                new Rectangle(
                    565,
                    15,
                    90,
                    73
                );

            slot7.TorreColocada = false;

            slots.Add(slot7);

            Slot slot8 = new Slot();

            slot8.PosicionTorre =
                new Vector2(698, 23);

            slot8.AreaConstruccion =
                new Rectangle(
                    698,
                    38,
                    90,
                    80
                );

            slot8.TorreColocada = false;

            slots.Add(slot8);

            Slot slot9 = new Slot();

            slot9.PosicionTorre =
                new Vector2(698, 115);

            slot9.AreaConstruccion =
                new Rectangle(
                    700,
                    130,
                    90,
                    75
                );

            slot9.TorreColocada = false;

            slots.Add(slot9);

            Slot slot10 = new Slot();

            slot10.PosicionTorre =
                new Vector2(700, 200);

            slot10.AreaConstruccion =
                new Rectangle(
                    700,
                    218,
                    90,
                    75
                );

            slot10.TorreColocada = false;

            slots.Add(slot10);


            Slot slot11 = new Slot();

            slot11.PosicionTorre =
                new Vector2(822, 115);

            slot11.AreaConstruccion =
                new Rectangle(
                    822,
                    130,
                    90,
                    75
                );

            slot11.TorreColocada = false;

            slots.Add(slot11);


            Slot slot12 = new Slot();

            slot12.PosicionTorre =
                new Vector2(825, 200);

            slot12.AreaConstruccion =
                new Rectangle(
                    825,
                    220,
                    90,
                    75
                );

            slot12.TorreColocada = false;

            slots.Add(slot12);

            Slot slot13 = new Slot();

            slot13.PosicionTorre =
                new Vector2(940, 115);

            slot13.AreaConstruccion =
                new Rectangle(
                    940,
                    130,
                    90,
                    75
                );

            slot13.TorreColocada = false;

            slots.Add(slot13);

            Slot slot14 = new Slot();

            slot14.PosicionTorre =
                new Vector2(950, 200);

            slot14.AreaConstruccion =
                new Rectangle(
                    950,
                    215,
                    90,
                    75
                );

            slot14.TorreColocada = false;

            slots.Add(slot14);

            Slot slot15 = new Slot();

            slot15.PosicionTorre =
                new Vector2(1075, 200);

            slot15.AreaConstruccion =
                new Rectangle(
                    1075,
                    215,
                    90,
                    75
                );

            slot15.TorreColocada = false;

            slots.Add(slot15);

            Slot slot16 = new Slot();

            slot16.PosicionTorre =
                new Vector2(1185, 295);

            slot16.AreaConstruccion =
                new Rectangle(
                    1185,
                    310,
                    90,
                    75
                );

            slot16.TorreColocada = false;

            slots.Add(slot16);

            Slot slot17 = new Slot();

            slot17.PosicionTorre =
                new Vector2(1185, 400);

            slot17.AreaConstruccion =
                new Rectangle(
                    1185,
                    420,
                    90,
                    75
                );

            slot17.TorreColocada = false;

            slots.Add(slot17);

            Slot slot18 = new Slot();

            slot18.PosicionTorre =
                new Vector2(1315, 400);

            slot18.AreaConstruccion =
                new Rectangle(
                    1317,
                    420,
                    90,
                    75
                );

            slot18.TorreColocada = false;

            slots.Add(slot18);

            Slot slot19 = new Slot();

            slot19.PosicionTorre =
                new Vector2(1185, 495);

            slot19.AreaConstruccion =
                new Rectangle(
                    1185,
                    515,
                    90,
                    75
                );

            slot19.TorreColocada = false;

            slots.Add(slot19);

            Slot slot20 = new Slot();

            slot20.PosicionTorre =
                new Vector2(555, 368);

            slot20.AreaConstruccion =
                new Rectangle(
                    555,
                    387,
                    90,
                    73
                );

            slot20.TorreColocada = false;

            slots.Add(slot20);

            Slot slot21 = new Slot();

            slot21.PosicionTorre =
                new Vector2(680, 368);

            slot21.AreaConstruccion =
                new Rectangle(
                    680,
                    387,
                    90,
                    73
                );

            slot21.TorreColocada = false;

            slots.Add(slot21);

            Slot slot22 = new Slot();

            slot22.PosicionTorre =
                new Vector2(810, 368);

            slot22.AreaConstruccion =
                new Rectangle(
                    810,
                    387,
                    90,
                    73
                );

            slot22.TorreColocada = false;

            slots.Add(slot22);

            Slot slot23 = new Slot();

            slot23.PosicionTorre =
                new Vector2(947, 368);

            slot23.AreaConstruccion =
                new Rectangle(
                    947,
                    387,
                    90,
                    73
                );

            slot23.TorreColocada = false;

            slots.Add(slot23);

            Slot slot24 = new Slot();

            slot24.PosicionTorre =
                new Vector2(660, 470);

            slot24.AreaConstruccion =
                new Rectangle(
                    660,
                    487,
                    90,
                    73
                );

            slot24.TorreColocada = false;

            slots.Add(slot24);

            Slot slot25 = new Slot();

            slot25.PosicionTorre =
                new Vector2(800, 470);

            slot25.AreaConstruccion =
                new Rectangle(
                    800,
                    487,
                    90,
                    73
                );

            slot25.TorreColocada = false;

            slots.Add(slot25);

            Slot slot26 = new Slot();

            slot26.PosicionTorre =
                new Vector2(946, 470);

            slot26.AreaConstruccion =
                new Rectangle(
                    946,
                    487,
                    90,
                    73
                );

            slot26.TorreColocada = false;

            slots.Add(slot26);

            Slot slot27 = new Slot();

            slot27.PosicionTorre =
                new Vector2(295, 378);

            slot27.AreaConstruccion =
                new Rectangle(
                    295,
                    398,
                    90,
                    73
                );

            slot27.TorreColocada = false;

            slots.Add(slot27);

            Slot slot28 = new Slot();

            slot28.PosicionTorre =
                new Vector2(285, 475);

            slot28.AreaConstruccion =
                new Rectangle(
                    285,
                    490,
                    90,
                    73
                );

            slot28.TorreColocada = false;

            slots.Add(slot28);

            Slot slot29 = new Slot();

            slot29.PosicionTorre =
                new Vector2(405, 475);

            slot29.AreaConstruccion =
                new Rectangle(
                    405,
                    490,
                    90,
                    73
                );

            slot29.TorreColocada = false;

            slots.Add(slot29);

            Slot slot30 = new Slot();

            slot30.PosicionTorre =
                new Vector2(285, 560);

            slot30.AreaConstruccion =
                new Rectangle(
                    285,
                    578,
                    90,
                    73
                );

            slot30.TorreColocada = false;

            slots.Add(slot30);

            Slot slot31 = new Slot();

            slot31.PosicionTorre =
                new Vector2(508, 640);

            slot31.AreaConstruccion =
                new Rectangle(
                    508,
                    660,
                    90,
                    73
                );

            slot31.TorreColocada = false;

            slots.Add(slot31);

            Slot slot32 = new Slot();

            slot32.PosicionTorre =
                new Vector2(635, 640);

            slot32.AreaConstruccion =
                new Rectangle(
                    635,
                    660,
                    90,
                    73
                );

            slot32.TorreColocada = false;

            slots.Add(slot32);

            Slot slot33 = new Slot();

            slot33.PosicionTorre =
                new Vector2(752, 640);

            slot33.AreaConstruccion =
                new Rectangle(
                    752,
                    660,
                    90,
                    73
                );

            slot33.TorreColocada = false;

            slots.Add(slot33);

            Slot slot34 = new Slot();

            slot34.PosicionTorre =
                new Vector2(872, 640);

            slot34.AreaConstruccion =
                new Rectangle(
                    872,
                    660,
                    90,
                    73
                );

            slot34.TorreColocada = false;

            slots.Add(slot34);

            Slot slot35 = new Slot();

            slot35.PosicionTorre =
                new Vector2(992, 640);

            slot35.AreaConstruccion =
                new Rectangle(
                    992,
                    660,
                    90,
                    73
                );

            slot35.TorreColocada = false;

            slots.Add(slot35);

            Slot slot36 = new Slot();

            slot36.PosicionTorre =
                new Vector2(1192, 640);

            slot36.AreaConstruccion =
                new Rectangle(
                    1192,
                    660,
                    90,
                    73
                );

            slot36.TorreColocada = false;

            slots.Add(slot36);

            Slot slot37 = new Slot();

            slot37.PosicionTorre =
                new Vector2(1337, 500);

            slot37.AreaConstruccion =
                new Rectangle(
                    1337,
                    520,
                    90,
                    73
                );

            slot37.TorreColocada = false;

            slots.Add(slot37);

            Slot slot38 = new Slot();

            slot38.PosicionTorre =
                new Vector2(1415, 680);

            slot38.AreaConstruccion =
                new Rectangle(
                    1415,
                    700,
                    90,
                    73
                );

            slot38.TorreColocada = false;

            slots.Add(slot38);

            ProbarConexion();

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

            _spriteBatch.DrawString(
                fuente,
                "Dinero: $" + dinero,
                new Vector2(1430, 20),
                Color.Black
            );


            string nombreDefensa =
                torreSeleccionada.ToString()
                .Replace("Canion", "Cañón");


            _spriteBatch.DrawString(
            fuente,
            "Defensa: " + nombreDefensa,
            new Vector2(1430, 50),
            Color.Black
            );

            _spriteBatch.DrawString(
            fuente,
            "Costo: $" + ObtenerCosto(torreSeleccionada),
            new Vector2(1430, 80),
            Color.Black
            );

            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
