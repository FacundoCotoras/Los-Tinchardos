using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace TowerDefense
{
    class BaseDatos
    {
        public static List<DatosDefensa> CargarDefensas()
        {
            List<DatosDefensa> defensas =
                new List<DatosDefensa>();

            string cadena =
                "Server=127.0.0.1;" +
                "Database=IronBastion;" +
                "User ID=root;" +
                "Password=;";

            try
            {
                using var conexion =
                    new MySqlConnection(cadena);

                conexion.Open();

                System.Diagnostics.Debug.WriteLine(
                    "Conectado");

                using var comando =
                    new MySqlCommand(
                        "Defensas",
                        conexion);

                comando.CommandType =
                    CommandType.StoredProcedure;

                using var lector =
                    comando.ExecuteReader();

                while (lector.Read())
                {
                    DatosDefensa defensa =
                        new DatosDefensa();

                    defensa.Nombre =
                        lector["Nombre"].ToString();

                    defensa.Costo =
                        Convert.ToSingle(
                            lector["Costo"]);

                    defensa.Danio =
                        Convert.ToSingle(
                            lector["DañoBase"]);

                    defensa.Vida =
                        Convert.ToSingle(
                            lector["VidaBase"]);

                    defensa.Rango =
                        Convert.ToSingle(
                            lector["Rango"]);

                    defensa.Cooldown =
                        Convert.ToInt32(
                            lector["CooldownBase"]);


                    defensas.Add(defensa);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    ex.Message);
            }

            return defensas;
        }

        public static List<DatosEnemigo> CargarEnemigos()
        {
            List<DatosEnemigo> enemigos =
                new List<DatosEnemigo>();

            string cadena =
                "Server=127.0.0.1;" +
                "Database=IronBastion;" +
                "User ID=root;" +
                "Password=;";

            try
            {
                using var conexion =
                    new MySqlConnection(cadena);

                conexion.Open();

                using var comando =
                    new MySqlCommand(
                        "Enemigos",
                        conexion);

                comando.CommandType =
                    CommandType.StoredProcedure;

                using var lector =
                    comando.ExecuteReader();

                while (lector.Read())
                {
                    DatosEnemigo enemigo =
                        new DatosEnemigo();

                    enemigo.Nombre =
                        lector["Nombre"].ToString();

                    enemigo.Vida =
                        Convert.ToSingle(
                            lector["VidaBase"]);

                    enemigo.Danio =
                        Convert.ToSingle(
                            lector["Daño"]);

                    enemigo.Velocidad =
                        Convert.ToSingle(
                            lector["Velocidad"]);

                    enemigo.Resistencia =
                        Convert.ToSingle(
                            lector["Resistencia"]);

                    enemigo.Recompensa =
                        Convert.ToInt32(
                            lector["Recompensa"]);

                    enemigos.Add(enemigo);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    ex.Message);
            }

            return enemigos;
        }

        public static DatosJugador BuscarJugador(
    string usuario)
        {
            DatosJugador jugador = null;

            string cadena =
                "Server=127.0.0.1;" +
                "Database=IronBastion;" +
                "User ID=root;" +
                "Password=;";

            try
            {
                using var conexion =
                    new MySqlConnection(cadena);

                conexion.Open();

                string sql =
                    "SELECT Usuario, NivelActual " +
                    "FROM Players " +
                    "WHERE Usuario = @usuario";

                using var comando =
                    new MySqlCommand(
                        sql,
                        conexion);

                comando.Parameters.AddWithValue(
                    "@usuario",
                    usuario);

                using var lector =
                    comando.ExecuteReader();

                if (lector.Read())
                {
                    jugador =
                        new DatosJugador();

                    jugador.Usuario =
                        lector["Usuario"].ToString();

                    jugador.Victorias =
                        Convert.ToInt32(
                            lector["NivelActual"]);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    ex.Message);
            }

            return jugador;
        }


        public static void RegistrarJugador(
    string usuario)
        {
            string cadena =
                "Server=127.0.0.1;" +
                "Database=IronBastion;" +
                "User ID=root;" +
                "Password=;";

            try
            {
                using var conexion =
                    new MySqlConnection(cadena);

                conexion.Open();

                string sql =
                    "INSERT INTO Players " +
                    "(Usuario, FechaRegistro, NivelActual) " +
                    "VALUES " +
                    "(@usuario, CURDATE(), 0)";

                using var comando =
                    new MySqlCommand(
                        sql,
                        conexion);

                comando.Parameters.AddWithValue(
                    "@usuario",
                    usuario);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    ex.Message);
            }
        }

        public static void SumarVictoria(
    string usuario)
        {
            string cadena =
                "Server=127.0.0.1;" +
                "Database=IronBastion;" +
                "User ID=root;" +
                "Password=;";

            try
            {
                using var conexion =
                    new MySqlConnection(cadena);

                conexion.Open();

                string sql =
                    "UPDATE Players " +
                    "SET NivelActual = NivelActual + 1 " +
                    "WHERE Usuario = @usuario";

                using var comando =
                    new MySqlCommand(
                        sql,
                        conexion);

                comando.Parameters.AddWithValue(
                    "@usuario",
                    usuario);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    ex.Message);
            }
        }


    }
}
