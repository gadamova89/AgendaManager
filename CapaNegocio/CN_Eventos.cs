using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Eventos
    {
        private CD_Eventos objetoCD = new CD_Eventos();

        //Metodo para obtener todos los eventos.
        public DataTable MostrarEventos()
        {
            return objetoCD.MostrarEventos();
        }

        // Metodo para insertar un evento.
        public bool InsertarEventos(string titulo, string descripcion, DateTime fechaHora, string ubicacion)
        {
            return objetoCD.InsertarEventos(titulo, descripcion, fechaHora, ubicacion);
        }

        // Metodo para editar un evento
        public bool EditarEventos(string titulo, string descripcion, DateTime fechaHora, string ubicacion, int id)
        {
            return objetoCD.EditarEventos(titulo, descripcion, fechaHora, ubicacion, id);
        }

        // Metodo para eliminar un evento.
        public bool EliminarEventos(int id)
        {
            return objetoCD.EliminarEventos(id);
        }

        public DataTable BuscarEventoPorTitulo(string titulo)
        {
            return objetoCD.BuscarEventoPorTitulo(titulo);
        }
    }
}
