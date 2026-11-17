using System.Collections.Generic;

namespace TowerDefense
{
    class Economia
    {
        public static float ObtenerCosto(
            TipoTorre tipo,
            List<DatosDefensa> defensas)
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

        public static int ObtenerRecompensa(
            string nombre,
            List<DatosEnemigo> enemigos)
        {
            foreach (DatosEnemigo enemigo in enemigos)
            {
                if (enemigo.Nombre == nombre)
                {
                    return enemigo.Recompensa;
                }
            }

            return 0;
        }
    }
}
