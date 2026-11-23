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
            List<Proyectil> proyectiles,
            List<DatosDefensa> defensas)
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
                    float danio =
                        Economia.ObtenerDanio(
                            torre.Tipo,
                            defensas);

                    int cantidadDisparos = 1;

                    if (torre.Tipo == TipoTorre.Canion && torre.Nivel == 2)
                    {
                        cantidadDisparos = 2;
                        danio *= 0.75f;
                    }

                    if (torre.Tipo ==TipoTorre.Torreta && torre.Nivel == 2
   )
                    {
                        cantidadDisparos = 2;
                        danio *= 0.60f;
                    }

                    if (
                        torre.Tipo ==
                        TipoTorre.Lanzacohetes
                       )
                    {
                        if (torre.Nivel == 2)
                        {
                            cantidadDisparos = 2;
                        }
                        else if (torre.Nivel == 3)
                        {
                            cantidadDisparos = 3;
                        }
                    }

                    for (int i = 0;
                         i < cantidadDisparos;
                         i++)
                    {
                        proyectiles.Add(
                            new Proyectil
                            {
                                Posicion =
                                    torre.Posicion,

                                Objetivo =
                                    torre.Objetivo,

                                Danio =
                                    danio
                            }
                        );
                    }

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
