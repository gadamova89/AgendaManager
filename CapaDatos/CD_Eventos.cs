using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public  class CD_Eventos
    {
        private CD_Conexion conexion = new CD_Conexion();

        // 1. MOSTRAR
        public DataTable MostrarEventos()
        {
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarEventos";
            comando.CommandType = CommandType.StoredProcedure;

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();

            return tabla;
        }

        // 2. INSERTAR (RETORNA BOOL)
        public bool InsertarEventos(string titulo, string descripcion, DateTime fechaHora, string ubicacion)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarEventos";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@Titulo", titulo);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);
            comando.Parameters.AddWithValue("@FechaHora", fechaHora);
            comando.Parameters.AddWithValue("@Ubicacion", ubicacion);

            int filasAfectadas = comando.ExecuteNonQuery();
            conexion.CerrarConexion();

            bool resultado = false;
            if (filasAfectadas > 0)
                resultado = true;

            return resultado;
        }

        // 3. EDITAR (RETORNA BOOL)
        public bool EditarEventos(string titulo, string descripcion, DateTime fechaHora, string ubicacion, int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarEventos";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@Titulo", titulo);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);
            comando.Parameters.AddWithValue("@FechaHora", fechaHora);
            comando.Parameters.AddWithValue("@Ubicacion", ubicacion);
            comando.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = comando.ExecuteNonQuery();
            conexion.CerrarConexion();

            bool resultado = false;
            if (filasAfectadas > 0)
                resultado = true;

            return resultado;
        }

        // 4. ELIMINAR (RETORNA BOOL)
        public bool EliminarEventos(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarEvento";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = comando.ExecuteNonQuery();
            conexion.CerrarConexion();

            bool resultado = false;
            if (filasAfectadas > 0)
                resultado = true;

            return resultado;
        }
    }
}
