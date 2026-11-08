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
    }
}