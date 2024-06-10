namespace RecursosHumanosAPI.DTOs
{
    public class PuestoUpdateDTO
    {
        public required string Nombre { get; set; }
        public int PuestoId { get; internal set; }
    }
}
