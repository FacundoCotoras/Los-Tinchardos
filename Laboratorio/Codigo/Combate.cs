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
                    int cooldownDisparo = 30;

                    if (torre.Tipo == TipoTorre.Canion)
                    {
                        if (torre.Nivel == 2)
                        {
                            cantidadDisparos = 2;
                            danio *= 0.75f;
                        }
                        else if (torre.Nivel == 3)
                        {
                            cantidadDisparos = 1;
                            danio *= 2.5f;
                        }
                    }

                  
                    if (torre.Tipo == TipoTorre.Torreta)
                    {
                        if (torre.Nivel == 2)
                        {
                            cantidadDisparos = 2;
                            danio *= 0.60f;
                        }
                        else if (torre.Nivel == 3)
                        {
                            cantidadDisparos = 1;
                            cooldownDisparo = 10;
                            danio *= 0.75f;
                        }
                    }


                    if (torre.Tipo == TipoTorre.Lanzacohetes)
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

                    for (int i = 0; i < cantidadDisparos; i++)
                    {
                        float offsetX = 0;
                        if (cantidadDisparos == 2)
                        {
                            offsetX =
                                (i == 0)
                                ? -10
                                : 10;
                        }
                        else if (cantidadDisparos == 3)
                        {
                            if (i == 0)
                                offsetX = -15;
                            else if (i == 1)
                                offsetX = 0;
                            else
                                offsetX = 15;
                        }
                        proyectiles.Add(
                            new Proyectil
                            {
                                Posicion =
                                    torre.Posicion +
                                    new Vector2(
                                        45 + offsetX,
                                        45),
                                Objetivo =
                                    torre.Objetivo,

                                Danio =
                                    danio,

                                Tipo = torre.Tipo
                            }
                        );
                    }

                    torre.Cooldown = cooldownDisparo;
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
