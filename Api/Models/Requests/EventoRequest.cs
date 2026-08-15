namespace Api.Models.Requests
{
    public class EventoRequest
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }
        public string Ubicacion { get; set; }
    }
}
