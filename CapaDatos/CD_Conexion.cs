using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    internal class CD_Conexion
    {
        private SqlConnection Conexion = new SqlConnection("Server=DESKTOP-SG9LKAU\\MSSQLSERVER01; Database=AgendaDB;  Integrated Security=True; trustservercertificate=true");
        
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
            return Conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
            return Conexion;
        }
    }

}
