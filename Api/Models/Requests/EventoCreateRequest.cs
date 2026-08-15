namespace Api.Models.Requests
{
    public class EventoCreateRequest
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }
        public string Ubicacion { get; set; }
    }
}
