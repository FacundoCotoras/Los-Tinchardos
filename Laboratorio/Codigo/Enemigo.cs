using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{

    /// <summary>
    /// Personaje grafico 2D que recorre un camino formado por puntos (waypoints).
    /// </summary>
    class Personaje
    {
        private Texture2D textura;
        private Rectangle rectangulo;      // donde se dibuja (hitbox)
        private Vector2 posicion;          // CENTRO del personaje (float para un movimiento suave)
        private float velocidad;           // pixeles por frame
        private bool activo;

        private Vector2[] camino;          // puntos por los que pasa el personaje
        private int objetivo;              // indice del proximo punto al que va
        private bool mirandoDerecha;       // para dar vuelta la imagen

        /// <summary>
        /// Es true cuando el personaje llego al final del camino
        /// </summary>
        public bool LlegoAlFinal { get; private set; }

        /// <summary>
        /// Constructor del personaje
        /// </summary>
        /// <param name="sprite">Imagen del personaje</param>
        /// <param name="ancho">Ancho con el que se dibuja</param>
        /// <param name="alto">Alto con el que se dibuja</param>
        /// <param name="velocidad">Pixeles que avanza por frame</param>
        /// <param name="camino">Lista de puntos (centro del camino) que recorre</param>
        public Personaje(Texture2D sprite, int ancho, int alto, float velocidad, Vector2[] camino)
        {
            textura = sprite;
            this.velocidad = velocidad;
            this.camino = camino;
            activo = true;
            rectangulo = new Rectangle(0, 0, ancho, alto);
            Reiniciar();
        }

        /// <summary>
        /// Pone al personaje en el primer punto del camino
        /// </summary>
        private void Reiniciar()
        {
            posicion = camino[0];
            objetivo = 1;
            mirandoDerecha = true;
            ActualizarRectangulo();
        }

        // El rectangulo se acomoda para que la posicion quede en el CENTRO del sprite
        private void ActualizarRectangulo()
        {
            rectangulo.X = (int)(posicion.X - rectangulo.Width / 2f);
            rectangulo.Y = (int)(posicion.Y - rectangulo.Height / 2f);
        }

        /// <summary>
        /// Mueve el personaje hacia el siguiente punto del camino
        /// </summary>
        public void update()
        {
            if (LlegoAlFinal)
            {
                return;
            }

            Vector2 hacia = camino[objetivo] - posicion;
            float distancia = hacia.Length();

            // Hacia donde mira (solo cambia con movimiento horizontal)
            if (hacia.X > 0.1f) mirandoDerecha = true;
            else if (hacia.X < -0.1f) mirandoDerecha = false;

            if (distancia <= velocidad)
            {
                // Llego al punto: se posiciona justo ahi y pasa al siguiente
                posicion = camino[objetivo];
                objetivo++;

                // Si termino el camino, avisa que llego al final y deja de dibujarse
                if (objetivo >= camino.Length)
                {
                    LlegoAlFinal = true;
                    activo = false;
                    return;
                }
            }
            else
            {
                // Avanza "velocidad" pixeles en la direccion del punto
                hacia.Normalize();
                posicion += hacia * velocidad;
            }

            ActualizarRectangulo();
        }

        /// <summary>
        /// Dibuja el personaje en la ventana
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        public void draw(SpriteBatch sb)
        {
            if (activo)
            {
                // El topo original mira hacia la izquierda: lo damos vuelta al ir a la derecha
                SpriteEffects efecto = mirandoDerecha ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                sb.Draw(textura, rectangulo, null, Color.White, 0f, Vector2.Zero, efecto, 0f);
            }
        }
    }

}