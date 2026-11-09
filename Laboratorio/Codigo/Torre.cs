using Microsoft.Xna.Framework;

namespace TowerDefense
{
    class Torre
    {
        public Vector2 Posicion { get; set; }

        public TipoTorre Tipo { get; set; }

        public float Rango { get; set; }

        public Enemigo Objetivo { get; set; }
    }
}
