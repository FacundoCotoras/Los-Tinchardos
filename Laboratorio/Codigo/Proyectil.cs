using Microsoft.Xna.Framework;

namespace TowerDefense
{
    class Proyectil
    {
        public Vector2 Posicion { get; set; }

        public Enemigo Objetivo { get; set; }

        public bool Activo { get; set; } = true;
        public float Velocidad { get; set; } = 6f;
        public void Update()
        {
            if (!Activo)
                return;

            if (Objetivo == null)
            {
                Activo = false;
                return;
            }

            Vector2 direccion =
                Objetivo.Posicion - Posicion;

            if (direccion.Length() < 5)
            {
                Objetivo.Vida -= 25;
                Activo = false;
                return;
            }

            direccion.Normalize();

            Posicion +=
                direccion * Velocidad;
        }
    }
}
