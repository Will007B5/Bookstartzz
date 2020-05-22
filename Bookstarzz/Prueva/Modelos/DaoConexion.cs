﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Backend.Modelos
{
    public class DaoConexion
    {
        static MySqlConnection conexion;

        public static bool conectar()
        {
            try
            {

                if (conexion == null || conexion.State != ConnectionState.Open)
                {
                    conexion = new MySqlConnection();
                    conexion.ConnectionString = "Server=localhost;" +
                    "Database=bookstartzz;" +
                    "uid=root;" +
                    "pwd=root;";// sslmode=none";

                    conexion.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo estableser la conexion" +
                    "con el servidor");
            }
        }

        public static DataTable ejecutarConsulta(MySqlCommand consulta)
        {
            if (conectar())
            {
                consulta.Connection = conexion;
                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
            return null;
        }

        public static int ejecutarSentencia(MySqlCommand sentencia, bool esInsertar)
        {
            int valor = 0;
            if (conectar())
            {
                sentencia.Connection = conexion;
                if (esInsertar)
                {
                    valor = int.Parse(sentencia.ExecuteScalar().ToString());
                    int v = valor;
                }

                else
                {
                    valor = sentencia.ExecuteNonQuery();
                }
                    
            }
            return valor;
        }

        public static void desconectar()
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
                conexion.Close();
        }

    }

}




