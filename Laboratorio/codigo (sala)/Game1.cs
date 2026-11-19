using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopoCamino;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Mapa mapa;
    HUD hud = new HUD();
    Oleadas oleadas = new Oleadas();

    List<Enemigo> enemigos = new List<Enemigo>();
    Texture2D texEnemigo;

    KeyboardState teclaActual;

    const int vidasMaximas = 3;
    int vidas = vidasMaximas;
    bool gameOver = false;
    bool victoria = false;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = Mapa.Ancho;
        _graphics.PreferredBackBufferHeight = Mapa.Alto;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        mapa = new Mapa(Content.Load<Texture2D>("mapa"));
        texEnemigo = Content.Load<Texture2D>("topo");
        hud.LoadContent(Content, GraphicsDevice);

        ReiniciarJuego();
    }

    private void ReiniciarJuego()
    {
        vidas = vidasMaximas;
        gameOver = false;
        victoria = false;
        enemigos.Clear();
        oleadas.Reiniciar();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            Exit();

        teclaActual = Keyboard.GetState();

        if (teclaActual.IsKeyDown(Keys.Escape))
        {
            this.Exit();
        }

        if (gameOver || victoria)
        {
            if (teclaActual.IsKeyDown(Keys.R))
            {
                ReiniciarJuego();
            }
            base.Update(gameTime);
            return;
        }

        Enemigo nuevo = oleadas.GenerarEnemigo(texEnemigo, Mapa.Camino);
        if (nuevo != null)
        {
            enemigos.Add(nuevo);
        }

        for (int i = enemigos.Count - 1; i >= 0; i--)
        {
            enemigos[i].update();

            if (enemigos[i].LlegoAlFinal)
            {
                vidas--;
                enemigos.RemoveAt(i);
            }
        }

        if (vidas <= 0)
        {
            vidas = 0;
            gameOver = true;
        }
        else
        {
            oleadas.VerificarFin(enemigos.Count);
            if (oleadas.Completadas)
            {
                victoria = true;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        mapa.draw(_spriteBatch);
        foreach (Enemigo enemigo in enemigos)
        {
            enemigo.draw(_spriteBatch);
        }
        hud.draw(_spriteBatch, vidas, vidasMaximas, oleadas.Actual, gameOver, victoria);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
