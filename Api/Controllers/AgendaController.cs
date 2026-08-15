using Api.Models.Requests;
using Api.Models.Responses;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private CN_Eventos ObjetoCN = new CN_Eventos();

        // GET: api/Eventos
        [HttpGet("ObtenerEventos")]
        public IActionResult Get()
        {
            DataTable tabla = ObjetoCN.MostrarEventos();
            List<EventoResponse> lista = new List<EventoResponse>();

            foreach (DataRow row in tabla.Rows)
            {
                EventoResponse Evento = new EventoResponse();
                Evento.Id = Convert.ToInt32(row["Id"]);
                Evento.Titulo = Convert.ToString(row["Titulo"]);
                Evento.Descripcion = Convert.ToString(row["Descripcion"]);
                Evento.FechaHora = Convert.ToDateTime(row["FechaHora"]);
                Evento.Ubicacion = Convert.ToString(row["Ubicacion"]);

                lista.Add(Evento);
            }

            return Ok(lista);
        }

        // POST: api/Eventos
        [HttpPost("CrearEvento")]
        public IActionResult Post([FromBody] EventoRequest request)
        {
            bool resultado = ObjetoCN.InsertarEventos(request.Titulo, request.Descripcion, request.FechaHora,    request.Ubicacion
            );

            if (resultado)
                return Ok(new { 
                    mensaje = "Creado correctamente",
                    objeto = request
                });
            else
                return BadRequest(new
                {
                    mensaje = "No se ha podido crear el evento."
                });
        }

        // PUT: api/Eventos/5
        [HttpPut("ActualizarEvento")]
        public IActionResult Put([FromBody] EventoRequest request)
        {
            bool resultado = ObjetoCN.EditarEventos(request.Titulo, request.Descripcion, request.FechaHora, request.Ubicacion, request.Id
            );

            if (resultado)
                return Ok(new
                {
                    mensaje = "Actualizado correctamente."
                });
            else
                return NotFound();
        }

        // DELETE: api/Eventos/5
        [HttpDelete("EliminarEvento")]
        public IActionResult Delete(int id)
        {
            bool resultado = ObjetoCN.EliminarEventos(id);

            if (resultado)
                return Ok(new
                {
                    mensaje = "Eliminado correctamente."
                });
            else
                return NotFound();
        }
    }
}
