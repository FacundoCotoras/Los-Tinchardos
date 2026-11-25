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

        public static int ObtenerVida(
            string nombre,
            List<DatosEnemigo> enemigos)
        {
            foreach (DatosEnemigo enemigo in enemigos)
            {
                if (enemigo.Nombre == nombre)
                {
                    return (int)enemigo.Vida;
                }
            }

            return 100;
        }

        public static float ObtenerVelocidad(
            string nombre,
            List<DatosEnemigo> enemigos)
        {
            foreach (DatosEnemigo enemigo in enemigos)
            {
                if (enemigo.Nombre == nombre)
                {
                    return enemigo.Velocidad;
                }
            }

            return 2.5f;
        }

        public static float ObtenerDanio(
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

            foreach (DatosDefensa defensa in defensas)
            {
                if (defensa.Nombre == nombre)
                {
                    return defensa.Danio;
                }
            }

            return 25;
        }

        public static int ObtenerCooldown(
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

            foreach (DatosDefensa defensa in defensas)
            {
                if (defensa.Nombre == nombre)
                {
                    return defensa.Cooldown;
                }
            }

            return 30;
        }

    }
}
