using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopoCamino;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    //Lista de topos que estan recorriendo el camino en este momento
    List<Personaje> topos = new List<Personaje>();

    //Texturas: fondo, topo, corazones, cartel de game over y un pixel para oscurecer la pantalla
    Texture2D texMapa, texTopo, texCorazon, texCorazonVacio, texGameOver, texPixel;

    //Variable que toma el estado de la tecla
    KeyboardState teclaActual;

    //El tamaño de la ventana es el mismo que el de la imagen del mapa
    const int alto_pantalla = 816;
    const int ancho_pantalla = 1224;

    //Vidas
    const int vidasMaximas = 3;
    int vidas = vidasMaximas;
    bool gameOver = false;

    //Cada cuantos frames aparece un topo nuevo (60 frames = 1 segundo)
    const int framesEntreTopos = 100;
    int contadorTopos;

    //Puntos por el centro del camino, en pixeles del mapa.
    //El topo entra por la izquierda, pasa por cada punto y sale por la derecha.
    static readonly Vector2[] camino =
    {
        new Vector2(  70, 118), // entrada (izquierda)
        new Vector2( 492, 118),
        new Vector2( 492, 303),
        new Vector2( 855, 303),
        new Vector2( 855, 552),
        new Vector2( 335, 552),
        new Vector2( 335, 703),
        new Vector2(1035, 703),
        new Vector2(1035, 582),
        new Vector2(1160, 582)  // salida (derecha)
    };

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        //Definimos tamaño de la ventana
        _graphics.PreferredBackBufferWidth = ancho_pantalla;
        _graphics.PreferredBackBufferHeight = alto_pantalla;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        //Cargamos las imagenes que estan en Content
        texMapa = Content.Load<Texture2D>("mapa");
        texTopo = Content.Load<Texture2D>("topo");
        texCorazon = Content.Load<Texture2D>("corazon");
        texCorazonVacio = Content.Load<Texture2D>("corazonVacio");
        texGameOver = Content.Load<Texture2D>("gameover");

        //Textura de 1 pixel blanco, la usamos para oscurecer la pantalla en el game over
        texPixel = new Texture2D(GraphicsDevice, 1, 1);
        texPixel.SetData(new Color[] { Color.White });

        ReiniciarJuego();
    }

    //Deja todo como al principio: 3 vidas y sin topos
    private void ReiniciarJuego()
    {
        vidas = vidasMaximas;
        gameOver = false;
        topos.Clear();
        //Asi el primer topo aparece enseguida
        contadorTopos = framesEntreTopos;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            Exit();

        teclaActual = Keyboard.GetState();

        //si presionas la tecla esc cierra el juego
        if (teclaActual.IsKeyDown(Keys.Escape))
        {
            this.Exit();
        }

        if (gameOver)
        {
            //con R se vuelve a jugar
            if (teclaActual.IsKeyDown(Keys.R))
            {
                ReiniciarJuego();
            }
            base.Update(gameTime);
            return;
        }

        //Cada cierto tiempo aparece un topo nuevo en la entrada
        contadorTopos++;
        if (contadorTopos >= framesEntreTopos)
        {
            topos.Add(new Personaje(texTopo, 52, 60, 2.5f, camino));
            contadorTopos = 0;
        }

        //Movemos todos los topos. Recorremos de atras para adelante
        //porque vamos a borrar los que llegan al final
        for (int i = topos.Count - 1; i >= 0; i--)
        {
            topos[i].update();

            if (topos[i].LlegoAlFinal)
            {
                //Llego al final: se pierde una vida y el topo desaparece
                vidas--;
                topos.RemoveAt(i);
            }
        }

        //Si no quedan vidas, termina el juego
        if (vidas <= 0)
        {
            vidas = 0;
            gameOver = true;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        //PointClamp evita que los graficos pixelados se vean borrosos al agrandarlos
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        //Primero el fondo y despues los topos (quedan arriba del mapa)
        _spriteBatch.Draw(texMapa, new Rectangle(0, 0, ancho_pantalla, alto_pantalla), Color.White);
        foreach (Personaje topo in topos)
        {
            topo.draw(_spriteBatch);
        }

        //Corazones (vidas): rojo = vida que queda, gris = vida perdida
        for (int i = 0; i < vidasMaximas; i++)
        {
            Texture2D corazon = (i < vidas) ? texCorazon : texCorazonVacio;
            _spriteBatch.Draw(corazon, new Vector2(15 + i * 50, 15), Color.White);
        }

        //Pantalla de game over: oscurece el juego y muestra el cartel en el centro
        if (gameOver)
        {
            _spriteBatch.Draw(texPixel, new Rectangle(0, 0, ancho_pantalla, alto_pantalla), Color.Black * 0.6f);

            int anchoCartel = (int)(texGameOver.Width * 1.5f);
            int altoCartel = (int)(texGameOver.Height * 1.5f);
            Rectangle recCartel = new Rectangle((ancho_pantalla - anchoCartel) / 2,
                                                (alto_pantalla - altoCartel) / 2,
                                                anchoCartel, altoCartel);
            _spriteBatch.Draw(texGameOver, recCartel, Color.White);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
