using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TowerDefense
{
    class Combate
    {
        public static void ActualizarObjetivos(
            List<Torre> torres,
            List<Enemigo> enemigos)
        {
            foreach (Torre torre in torres)
            {
                torre.Objetivo = null;

                foreach (Enemigo enemigo in enemigos)
                {
                    float distancia =
                        Vector2.Distance(
                            torre.Posicion,
                            enemigo.Posicion);

                    if (distancia <= torre.Rango)
                    {
                        torre.Objetivo = enemigo;
                        break;
                    }
                }
            }
        }

        public static void Disparar(
            List<Torre> torres,
            List<Proyectil> proyectiles)
        {
            foreach (Torre torre in torres)
            {
                if (torre.Cooldown > 0)
                {
                    torre.Cooldown--;
                }

                if (
                    torre.Objetivo != null &&
                    torre.Cooldown <= 0
                   )
                {
                    proyectiles.Add(
                        new Proyectil
                        {
                            Posicion = torre.Posicion,
                            Objetivo = torre.Objetivo
                        }
                    );

                    torre.Cooldown = 30;
                }
            }
        }

        public static void ActualizarProyectiles(
            List<Proyectil> proyectiles)
        {
            for (int i = proyectiles.Count - 1; i >= 0; i--)
            {
                proyectiles[i].Update();

                if (!proyectiles[i].Activo)
                {
                    proyectiles.RemoveAt(i);
                }
            }
        }
    }
}
